using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Portfolio.Communication.CustomExceptions;
using Portfolio.Communication.ViewObjects.Account;
using Portfolio.Communication.ViewObjects.Emails;
using Portfolio.Communication.ViewObjects.User;
using Portfolio.Core.Entities.Identity;
using Portfolio.Core.Entities.Sql;
using Portfolio.Core.RepositoriesInterface.Sql;
using Portfolio.Core.ServicesInterface;
using Portfolio.Helpers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;

namespace Portfolio.Infrastructure.ServicesImpl
{
    public class AccountService : IAccountService
    {
        private readonly IConfigurationRepository _configRepo;
        private readonly IApiInfoService _apiInfoService;
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepo;
        private readonly IUserService _userService;
        private readonly ILogService _logService;
        private readonly IMapper _mapper;
        private readonly ISendMailService _sendMailService;

        public AccountService(IConfigurationRepository configRepo, IApiInfoService apiInfoService, IConfiguration configuration, IUserRepository userRepo, IUserService userService, ILogService logService, IMapper mapper, ISendMailService sendMailService)
        {
            _configRepo = configRepo;
            _apiInfoService = apiInfoService;
            _configuration = configuration;
            _userRepo = userRepo;
            _userService = userService;
            _logService = logService;
            _mapper = mapper;
            _sendMailService = sendMailService;
        }

        public async Task<LoginResponseTokenVO> LoginAsync(LoginVO model)
        {
            try
            {
                AspNetUser user = await _userRepo.GetByUserNameAsync(model.UserName);
                if (user is null)
                    throw new NotFoundException($"Usuário não encontrado");

                await ValidateLoginData(user);
                await _userRepo.SignInUserAsync(user, model.Password);

                List<string> roles = await _userRepo.GetRolesByUserAsync(user.Id);

                LoginResponseTokenVO resultCreateJwt = await CreateTokenJwtAsync(user, roles);
                resultCreateJwt.User = await _userService.GetUserWithRolesAsync(userId: user.Id);
                
                return resultCreateJwt;
            }
            catch (RepositoryException ex)
            {
                throw new ValidException(ex.Message, ex);
            }
            catch (SignInException ex)
            {
                throw new ValidException(ex.Message, ex);
            }
            catch (ValidException ex)
            {
                throw new ValidException(ex.Message, ex);
            }
            catch (NotFoundException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao realizar login do usuário: {model.UserName}", this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada ao realizar login do usuário: {model.UserName}", ex);
            }
        }

        public async Task<RefreshTokenVO> RefreshTokenAsync(RefreshTokenVO model)
        {
            try
            {
                RefreshTokenVO response = new RefreshTokenVO();
                TokenSettingsVO tokenSettings = await GetTokenSettingsGenerateTokenJwtAsync();

                TokenValidationParameters validationToken = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey =
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSettings.JwtSecret)),
                    ValidateLifetime = false
                };
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                SecurityToken securityToken;
                ClaimsPrincipal principal =
                    tokenHandler.ValidateToken(model.AccessToken, validationToken, out securityToken);

                JwtSecurityToken jwtSecurityToken = securityToken as JwtSecurityToken;
                if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256Signature))
                    throw new SecurityTokenException($"Token informado inválido");

                string username = principal.Identity.Name;
                AspNetUser userSave = await _userRepo.GetByUserNameAsync(username);
                if (userSave == null)
                    throw new NotFoundException($"Usuário não encontrado: {username}");

                List<string> roles = await _userRepo.GetRolesByUserAsync(userSave.Id);
                if (roles is null || roles.Count <= 0)
                    throw new NotFoundException($"Perfis de usuário {username} não encontrados");

                List<Claim> authClaims = GetClaimsListToken(userSave, roles);
                string refreshToken = await _userRepo.GetRefreshTokenAsync(userSave);
                if (refreshToken != model.RefreshToken)
                    throw new ValidException($"Refresh token informado não corresponde ao cadastrado na base de dados, verifique");

                SymmetricSecurityKey authSigningKey =
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSettings.JwtSecret));

                SigningCredentials credentials =
                    new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256Signature);

                JwtSecurityToken newJwtToken = new JwtSecurityToken(
                    issuer: tokenSettings.JwtIssuer,
                    audience: tokenSettings.JwtAudience,
                    expires: DateTime.Now.AddMinutes(tokenSettings.TimeExpiresInMinuntesRefreshToken),
                    claims: authClaims,
                    signingCredentials: credentials
                );

                string refreshTokenNew = await _userRepo.GenerateRefreshTokenAsync(userSave);
                response.RefreshToken = refreshTokenNew;
                response.AccessToken = new JwtSecurityTokenHandler().WriteToken(newJwtToken);

                return response;
            }
            catch (SecurityTokenException ex)
            {
                throw new ValidException(ex.Message, ex);
            }
            catch (ValidException ex)
            {
                throw ex;
            }
            catch (RepositoryException ex)
            {
                throw new ValidException(ex.Message, ex);
            }
            catch (NotFoundException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao gerar refresh token", this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada ao gerar refresh token", ex);
            }
        }

        private async Task<LoginResponseTokenVO> CreateTokenJwtAsync(AspNetUser user, List<string> roles)
        {
            LoginResponseTokenVO response = new LoginResponseTokenVO();
            try
            {
                List<Claim> claims = GetClaimsListToken(user, roles);
                TokenSettingsVO tokenSettings = await GetTokenSettingsGenerateTokenJwtAsync();
                SymmetricSecurityKey securityKey =
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSettings.JwtSecret));

                SigningCredentials credentials =
                    new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

                JwtSecurityToken token = new JwtSecurityToken(
                   issuer: tokenSettings.JwtIssuer,
                   audience: tokenSettings.JwtAudience,
                   expires: DateTime.Now.AddMinutes(tokenSettings.TimeExpiresInMinuntesAccessToken),
                   claims: claims,
                   signingCredentials: credentials
                );
                string refreshToken = await _userRepo.GenerateRefreshTokenAsync(user);

                JwtSecurityTokenHandler handlerToken = new JwtSecurityTokenHandler();
                response.AccessToken = handlerToken.WriteToken(token);
                response.RefreshToken = refreshToken;
                response.ExpirationAt = token.ValidTo.AddHours(-3);

                return response;
            }
            catch (RepositoryException ex)
            {
                throw new ValidException(ex.Message, ex);
            }
            catch (SignInException ex)
            {
                throw new SignInException(ex.Message);
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao gerar token de acesso para usuário {user.UserName}", this.GetPlace(), ex);
                throw new SignInException($"Falha inesperada ao gerar token de acesso para usuário {user.UserName}", ex);
            }
        }

        private async Task<TokenSettingsVO> GetTokenSettingsGenerateTokenJwtAsync()
        {
            try
            {
                string secretKey = _configuration[ConfigAppSettings.JwtSecret];
                string issuer = _configuration[ConfigAppSettings.JwtValidIssuer];
                string audience = _configuration[ConfigAppSettings.JwtValidAudience];

                if (string.IsNullOrEmpty(secretKey))
                    throw new SignInException($"Não encontrado segredo para geração de token");
                if (string.IsNullOrEmpty(issuer))
                    throw new SignInException($"Não encontrado issuer para geração de token");
                if (string.IsNullOrEmpty(audience))
                    throw new SignInException($"Não encontrada audience para geração de token");

                Configuration timeExpiresAccessTokenConfig = await _configRepo.GetByTokenAsync(ConfigurationTokens.TimeExpiresAccessToken);
                int timeExpiresAccessToken = (timeExpiresAccessTokenConfig is null || string.IsNullOrEmpty(timeExpiresAccessTokenConfig.Value)) ?
                                          30 :
                                          int.Parse(timeExpiresAccessTokenConfig.Value);

                Configuration timeExpiresRefreshTokenConfig = await _configRepo.GetByTokenAsync(ConfigurationTokens.TimeExpiresRefreshToken);
                int timeExpiresRefreshToken = (timeExpiresRefreshTokenConfig is null || string.IsNullOrEmpty(timeExpiresRefreshTokenConfig.Value)) ?
                                          60 :
                                          int.Parse(timeExpiresRefreshTokenConfig.Value);

                TokenSettingsVO response = new TokenSettingsVO
                {
                    JwtSecret = secretKey,
                    JwtAudience = audience,
                    JwtIssuer = issuer,
                    TimeExpiresInMinuntesAccessToken = timeExpiresAccessToken,
                    TimeExpiresInMinuntesRefreshToken = timeExpiresRefreshToken
                };
                return response;
            }
            catch (SignInException ex)
            {
                _logService.Write(ex.Message, this.GetPlace(), ex);
                throw new SignInException(ex.Message);
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao pegar dados para geração de token", this.GetPlace(), ex);
                throw new SignInException($"Falha inesperada ao pegar dados para geração de token", ex);
            }
        }

        private List<Claim> GetClaimsListToken(AspNetUser user, List<string> roles)
        {
            try
            {
                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email)
                };
                foreach (string role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }
                return claims;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha ao gerar claims de token para usuário {user.UserName}", this.GetPlace(), ex);
                throw new SignInException($"Falha ao gerar claims de token para usuário {user.UserName}");
            }
        }

        private async Task ValidateLoginData(AspNetUser user)
        {
            try
            {
                Configuration attemptsLoginConfig = await _configRepo.GetByTokenAsync(ConfigurationTokens.AttemptsLoginFailed);
                int attemptsLoginFailed = (attemptsLoginConfig is null || string.IsNullOrEmpty(attemptsLoginConfig.Value)) ?
                                          7 :
                                          int.Parse(attemptsLoginConfig.Value);

                if (user.AccessFailedCount >= attemptsLoginFailed)
                    throw new ValidException($"Sua senha está bloqueada por excesso de tentivas erradas, recupere-a e tente novamente. Usuário: {user.UserName}");

                if (user.LockoutEnd.HasValue && user.LockoutEnd > DateTime.Now)
                    throw new ValidException($"Conta está bloqueada, recupere sua senha ou aguarda até a data de desbloqueio: {user.LockoutEnd.Value.ToString("dd/MM/yyyy HH:mm")}. Usuário: {user.UserName}");
            }
            catch (ValidException ex)
            {
                throw new ValidException(ex.Message);
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha na validação de dados de login do usuário", this.GetPlace(), ex);
                throw new ValidException($"Falha na validação de dados do login do usuário: {user.UserName}", ex);
            }
        }

        public async Task<UserInfoVO> GetUserInfoAsync(int userId)
        {
            try
            {
                AspNetUser user = await _userRepo.GetByIdAsync(userId);
                if (user is null)
                    throw new NotFoundException($"Usuário não encontrado");

                List<string> roles = await _userRepo.GetRolesByUserAsync(user.Id);
                if (roles is null || roles.Count <= 0)
                    throw new NotFoundException($"Perfis não encontrados");

                UserInfoVO response = _mapper.Map<UserInfoVO>(user);
                response.Roles = roles;

                return response;
            }
            catch (AuthenticationException ex)
            {
                throw ex;
            }
            catch (RepositoryException ex)
            {
                throw ex;
            }
            catch (ValidException ex)
            {
                throw new ValidException(ex.Message, ex);
            }
            catch (NotFoundException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao pegar dados do usuário logado", this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada ao realizar login do usuário", ex);
            }
        }

        public async Task ResetPasswordSignInUserAsync(int userId, ResetPasswordSignInVO model)
        {
            try
            {
                bool isPasswordEquals = model.NewPassword == model.OldPassword;
                if (isPasswordEquals)
                    throw new ValidException($"Senhas iguais, nenhuma alteração realizada");

                AspNetUser userExist = await _userRepo.GetByIdAsync(userId);
                if (userExist == null)
                    throw new ValidException($"Usuário não encontrado");

                await _userRepo.AuthenticationUserByUserNameByPassAsync(userExist, model.OldPassword);
                await _userRepo.ResetPasswordUserSignInAsync(userExist, model.NewPassword);
            }
            catch (AuthenticationException ex)
            {
                throw ex;
            }
            catch (ValidException ex)
            {
                throw ex;
            }
            catch (RepositoryException ex)
            {
                throw new ValidException(ex.Message, ex);
            }
            catch (NotFoundException ex)
            {
                throw new ValidException(ex.Message, ex);
            }
            catch (SignInException ex)
            {
                throw new ValidException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao redefinir a senha", this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada ao redefinir a senha", ex);
            }
        }

        public async Task<string> ForgotPasswordSendMailAsync(ForgotPasswordVO model)
        {
            try
            {
                AspNetUser user = await _userRepo.GetByUserNameAsync(model.UserName);
                if (user == null)
                    throw new ValidException($"Usuário não encontrado");

                string newPassword = StaticMethods.GenerateAlfaNumericRandom(8);
                EmailDataForgotPassVO emailData = new EmailDataForgotPassVO
                {
                    Recipients = new List<string> { user.Email },
                    NewPassword = newPassword,
                    EmailUser = user.Email,
                    NameUser = $"{user.FirstName} {user.LastName}",
                    Username = user.UserName
                };
                await _sendMailService.SendMailForgotPasswordAsync(emailData);
                await _userRepo.ResetPasswordUserSignInAsync(user, newPassword);

                return user.Email;
            }
            catch (EmailException ex)
            {
                throw new ValidException($"Falha inesperada ao enviar email de redefinição de senha. Causa: {ex.Message}", ex);
            }
            catch (AuthenticationException ex)
            {
                throw ex;
            }
            catch (ValidException ex)
            {
                throw ex;
            }
            catch (RepositoryException ex)
            {
                throw new ValidException(ex.Message, ex);
            }
            catch (NotFoundException ex)
            {
                throw new ValidException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao redefinir a senha", this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada ao redefinir a senha", ex);
            }
        }

        public async Task<UserWithRolesVO> RegisterUserAsync(RegisterUserVO model)
        {
            try
            {
                SaveUserVO save = _mapper.Map<SaveUserVO>(model);
                save.Id = 0;
                save.Roles = new List<string> { "User" };

                await _userService.ValidationDataSaveUserAsync(save);

                AspNetUser user = _mapper.Map<AspNetUser>(save);

                user = await _userRepo.CreateAsync(user, save.Roles);

                UserWithRolesVO resp = _mapper.Map<UserWithRolesVO>(user);
                resp.Roles = await _userRepo.GetRolesByUserAsync(user.Id);

                return resp;
            }
            catch (RepositoryException ex)
            {
                throw new ValidException(ex.Message, ex);
            }
            catch (ValidException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao registrar usuário", this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada ao registrar usuário", ex);
            }
        }
    }
}
