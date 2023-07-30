using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Portfolio.Communication.CustomExceptions;
using Portfolio.Communication.ViewObjects.Utlis;
using Portfolio.Core.ServicesInterface;
using Portfolio.Helpers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Portfolio.Infrastructure.ServicesImpl
{
    public class ApiInfoService : IApiInfoService
    {
        private readonly IConfiguration _configuration;

        public ApiInfoService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public RequestDataVO GetRequestData(HttpRequest request, bool hasAuth = true)
        {
            try
            {
                RequestDataVO response = new RequestDataVO { IsAuth = hasAuth };
                if (hasAuth)
                    response.User = GetDataUserAuth(request);

                response.Request = GetDataHeaderRequest(request);
                return response;
            }
            catch (AuthencationAppException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new AuthencationAppException($"Falha inesperada ao pegar dados de requisição", ex);
            }
        }

        public APISettingsVO GetAppSettingsData()
        {
            try
            {
                APISettingsVO response = new APISettingsVO();

                response.CorsUrls = _configuration.GetSection(ConfigAppSettings.ConfigCors)
                                                  .Get<string[]>();

                response.VersionAPI = _configuration[ConfigAppSettings.VersionApi];

                response.Auth = _configuration.GetSection(ConfigAppSettings.AuthSection)
                                              .Get<AuthSettingsVO>();

                response.Jwt = _configuration.GetSection(ConfigAppSettings.JwtSection)
                                             .Get<JwtSettingsVO>(); 

                return response;
            }
            catch (AuthencationAppException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ValidException($"Falha inesperada ao pegar dados de arquivo de configuração", ex);
            }
        }

        private RequestHeadersVO GetDataHeaderRequest(HttpRequest request)
        {
            try
            {
                RequestHeadersVO response = new RequestHeadersVO();
                
                response.BaseUrlFront =
                    request.
                        Headers
                        .Where(x => x.Key.ToUpper() == "ORIGIN")
                        .Select(x => x.Value)
                        .FirstOrDefault();

                return response;
            }
            catch (AuthencationAppException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new AuthencationAppException($"Falha inesperada ao pegar dados de requisição", ex);
            }
        }

        private ClaimsPrincipal ValidateTokenFunction(string token)
        {
            try
            {
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                ClaimsPrincipal userLogged = tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey =
                       new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration[ConfigAppSettings.JwtSecret])),
                    ClockSkew = TimeSpan.FromMinutes(30),
                    ValidIssuer = _configuration[ConfigAppSettings.JwtValidIssuer],
                    ValidAudience = _configuration[ConfigAppSettings.JwtValidAudience]
                }, out SecurityToken validatedToken);

                return userLogged;
            }
            catch (AuthencationAppException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new AuthencationAppException($"Falha inesperada ao validar token de usuário", ex);
            }
        }

        private UserAuthVO GetDataUserAuth(HttpRequest request)
        {
            try
            {
                string token = request
                                      .Headers
                                      .Where(x => x.Key == "Authorization" || 
                                                  x.Key == "authorization")
                                      .Select(x => x.Value)
                                      .FirstOrDefault()
                                      .ToString()
                                      .Split(" ")[1];

                if (string.IsNullOrEmpty(token))
                    throw new AuthencationAppException($"Não foi encontrado o token na requisição");

                ClaimsPrincipal userLogged = ValidateTokenFunction(token);
                if (userLogged.Identity == null || !userLogged.Identity.IsAuthenticated)
                    throw new AuthencationAppException($"Usuário não está autenticado, verifique e tente novamente");

                return new UserAuthVO
                {
                    Id = userLogged.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier) != null ?
                         int.Parse(userLogged.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value) :
                         throw new AuthencationAppException($"Não foi encontrado indentificador de usuário na requisição"),
                    Email = userLogged.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value,
                    Username = userLogged.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value,
                    Roles = userLogged.Claims.Where(x => x.Type == ClaimTypes.Role).Select(x => x.Value).ToList()
                };
            }
            catch (AuthencationAppException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new AuthencationAppException($"Falha inesperada ao pegar dados de usuário da requisição", ex);
            }
        }
    }
}
