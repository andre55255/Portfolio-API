using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Portfolio.Communication.CustomExceptions;
using Portfolio.Communication.ViewObjects.Utlis;
using Portfolio.Core.Entities.Identity;
using Portfolio.Core.Entities.Sql;
using Portfolio.Core.RepositoriesInterface.Sql;
using Portfolio.Core.ServicesInterface;
using Portfolio.Helpers;

namespace Portfolio.Infrastructure.RepositoriesImpl.Sql
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfigurationRepository _configRepo;
        private readonly SignInManager<AspNetUser> _signInManager;
        private readonly ILogService _logService;

        public UserRepository(IConfigurationRepository configRepo, SignInManager<AspNetUser> signInManager, ILogService logService)
        {
            _configRepo = configRepo;
            _signInManager = signInManager;
            _logService = logService;
        }

        public async Task<AspNetUser> GetByEmailAsync(string email)
        {
            try
            {
                AspNetUser? user =
                    await _signInManager
                                .UserManager
                                .Users
                                .Where(x => x.Email == email &&
                                            x.DisabledAt == null)
                                .FirstOrDefaultAsync();

                return user;
            }
            catch (RepositoryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao listar usuário: {email}", this.GetPlace(), ex);
                throw new RepositoryException($"Falha inesperada ao listar usuário: {email}");
            }
        }

        public async Task<AspNetUser> GetByIdAsync(int id)
        {
            try
            {
                AspNetUser? user =
                    await _signInManager
                                .UserManager
                                .Users
                                .Where(x => x.Id == id &&
                                            x.DisabledAt == null)
                                .FirstOrDefaultAsync();

                return user;
            }
            catch (RepositoryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao listar usuário: {id}", this.GetPlace(), ex);
                throw new RepositoryException($"Falha inesperada ao listar usuário: {id}", ex);
            }
        }

        public async Task<AspNetUser> GetByUserNameAsync(string userName)
        {
            try
            {
                AspNetUser? user =
                    await _signInManager
                                .UserManager
                                .Users
                                .Where(x => x.UserName == userName &&
                                            x.DisabledAt == null)
                                .FirstOrDefaultAsync();

                return user;
            }
            catch (RepositoryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao listar usuário: {userName}", this.GetPlace(), ex);
                throw new RepositoryException($"Falha inesperada ao listar usuário: {userName}", ex);
            }
        }

        public async Task<List<string>> GetRolesByUserAsync(int userId)
        {
            try
            {
                AspNetUser? user = 
                    await _signInManager
                            .UserManager
                            .Users
                            .Where(x => x.Id == userId)
                            .FirstOrDefaultAsync();

                if (user == null)
                    throw new RepositoryException($"Não foi encontrado um usuário com o identificador: {userId}");

                IList<string> roles =
                    await _signInManager
                                .UserManager
                                .GetRolesAsync(user);

                return roles.ToList();
            }
            catch (RepositoryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao listar perfis: {userId}", this.GetPlace(), ex);
                throw new RepositoryException($"Falha inesperada ao listar perfis: {userId}", ex);
            }
        }

        public async Task SignInUserAsync(AspNetUser user, string password)
        {
            try
            {
                await AuthenticationUserByUserNameByPassAsync(user, password);
                await UpdateUserBlockAttemptsFailedAsync(user.Id, false);
            }
            catch (RepositoryException ex)
            {
                throw ex;
            }
            catch (SignInException ex)
            {
                await UpdateUserBlockAttemptsFailedAsync(user.Id, true);

                Configuration attemptsLoginConfig = await _configRepo.GetByTokenAsync(ConfigurationTokens.AttemptsLoginFailed);
                int attemptsLoginFailed = (attemptsLoginConfig is null || string.IsNullOrEmpty(attemptsLoginConfig.Value)) ?
                                          7 :
                                          int.Parse(attemptsLoginConfig.Value);

                int accessFailedCount = user.AccessFailedCount;
                int attemptLoginCount = attemptsLoginFailed - accessFailedCount;

                if (attemptLoginCount <= 0)
                    throw new SignInException($"Credenciais incorretas - Tentativas de login excedidas, conta bloqueada. Resete a senha para realizar login novamente");
                else
                    throw new SignInException($"Credenciais incorretas - Tentativas restantes: {attemptLoginCount}");

                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha ao realizar rotina de login para usuário: {user.UserName}", this.GetPlace(), ex);
                throw new RepositoryException("Falha ao realizar rotina de login", ex);
            }
        }

        private async Task UpdateUserBlockAttemptsFailedAsync(int userId, bool isIncrement)
        {
            try
            {
                Configuration attemptsLoginConfig = await _configRepo.GetByTokenAsync(ConfigurationTokens.AttemptsLoginFailed);
                int attemptsLoginFailed = (attemptsLoginConfig is null || string.IsNullOrEmpty(attemptsLoginConfig.Value)) ?
                                          7 :
                                          int.Parse(attemptsLoginConfig.Value);

                Configuration attemptsLoginDaysBlockConfig = await _configRepo.GetByTokenAsync(ConfigurationTokens.AttemptsLoginFailedDaysBlock);
                int attemptsLoginDaysBlockFailed = (attemptsLoginDaysBlockConfig is null || string.IsNullOrEmpty(attemptsLoginDaysBlockConfig.Value)) ?
                                          14 :
                                          int.Parse(attemptsLoginDaysBlockConfig.Value);

                AspNetUser user = await GetByIdAsync(userId);
                if (isIncrement)
                {
                    user.AccessFailedCount += 1;
                    if (user.AccessFailedCount >= attemptsLoginFailed)
                    {
                        user.LockoutEnd = DateTime.Now.AddDays(attemptsLoginDaysBlockFailed);
                    }
                }
                else
                {
                    user.AccessFailedCount = 0;
                    user.LockoutEnd = null;
                }
                user.UpdatedAt = DateTime.Now;

                IdentityResult signInResult =
                    await _signInManager
                                .UserManager
                                .UpdateAsync(user);

                if (signInResult.Succeeded)
                    return;

                throw new SignInException($"Falha ao atualizar registro de usuário {user.UserName} na base de dados");
            }
            catch (RepositoryException ex)
            {
                throw new RepositoryException(ex.Message, ex);
            }
            catch (SignInException ex)
            {
                throw new SignInException(ex.Message);
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha ao atualizar tentativas de login do usuário: {userId}", this.GetPlace(), ex);
                throw new RepositoryException($"Falha ao atulizar tentativas de login", ex);
            }
        }

        public async Task AuthenticationUserByUserNameByPassAsync(AspNetUser user, string password)
        {
            try
            {
                SignInResult resultAuth =
                    await _signInManager
                                .PasswordSignInAsync(
                                    user,
                                    password,
                                    false,
                                    false
                                );

                if (resultAuth.Succeeded)
                    return;

                throw new SignInException($"Credenciais incorretas para usuário: {user.UserName}");
            }
            catch (RepositoryException ex)
            {
                throw ex;
            }
            catch (SignInException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha ao realizar login, usuário: {user.UserName}", this.GetPlace(), ex);
                throw new RepositoryException($"Falha ao realizar login, usuário: {user.UserName}", ex);
            }
        }

        public async Task<string> GenerateRefreshTokenAsync(AspNetUser user)
        {
            try
            {
                string refreshToken =
                    await _signInManager
                                .UserManager
                                .GenerateUserTokenAsync(user,
                                        ConfigJwt.LoginProviderWeb,
                                        ConfigJwt.LoginPurposeWeb);

                if (string.IsNullOrEmpty(refreshToken))
                    throw new RepositoryException($"Refresh token gerado inválido");

                IdentityResult resultInsertToken =
                    await _signInManager
                                .UserManager
                                .SetAuthenticationTokenAsync(user,
                                        ConfigJwt.LoginProviderWeb,
                                        ConfigJwt.LoginPurposeWeb,
                                        refreshToken);

                if (!resultInsertToken.Succeeded)
                    throw new RepositoryException($"Falha ao inserir refresh token na base de dados");

                return refreshToken;
            }
            catch (RepositoryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao gerar refresh token", this.GetPlace(), ex);
                throw new RepositoryException($"Falha inesperada ao gerar refresh token", ex);
            }
        }

        public async Task<string> GetRefreshTokenAsync(AspNetUser userSave)
        {
            try
            {
                string loginProvider = ConfigJwt.LoginProviderWeb;
                string purpose = ConfigJwt.LoginPurposeWeb;

                string refreshToken = await _signInManager
                                                .UserManager
                                                .GetAuthenticationTokenAsync(userSave, loginProvider, purpose);

                await UpdateSecurityStampUserAsync(userSave);
                return refreshToken;
            }
            catch (RepositoryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao listar refresh token do usuário {userSave.UserName}", this.GetPlace(), ex);
                throw new RepositoryException($"Falha inesperada ao listar refresh token do usuário {userSave.UserName}", ex);
            }
        }

        private async Task UpdateSecurityStampUserAsync(AspNetUser userEntity)
        {
            try
            {
                await _signInManager
                           .UserManager
                           .UpdateSecurityStampAsync(userEntity);
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha ao atualizar token de segurança do usuário {userEntity.UserName}", this.GetPlace(), ex);
                throw new RepositoryException($"Falha ao atualizar token de segurança do usuário {userEntity.UserName}");
            }
        }

        public async Task ResetPasswordUserSignInAsync(AspNetUser user, string newPassword)
        {
            try
            {
                PasswordHasher<AspNetUser> hasher = new PasswordHasher<AspNetUser>();
                user.PasswordHash = hasher.HashPassword(user, newPassword);
                user.UpdatedAt = DateTime.Now;

                IdentityResult result =
                    await _signInManager
                                .UserManager
                                .UpdateAsync(user);

                if (result.Succeeded)
                {
                    await UpdateUserBlockAttemptsFailedAsync(user.Id, false);
                    return;
                }

                throw new RepositoryException($"Falha ao redefinir a senha do usuário {user.UserName} na base de dados");
            }
            catch (RepositoryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao redefinir a senha do usuário {user.UserName}", this.GetPlace(), ex);
                throw new RepositoryException($"Falha inesperada ao redefinir a senha do usuário {user.UserName}", ex);
            }
        }

        public async Task ResetPasswordUserAsync(AspNetUser user, string newPassword, string code)
        {
            try
            {
                IdentityResult result =
                    await _signInManager
                                .UserManager
                                .ResetPasswordAsync(user, code, newPassword);

                if (result.Succeeded)
                    await UpdateUserBlockAttemptsFailedAsync(user.Id, false);

                throw new RepositoryException($"Falha ao redefinir a senha do usuário {user.UserName} na base de dados");
            }
            catch (RepositoryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao redefinir a senha do usuário {user.UserName}",  this.GetPlace(), ex);
                throw new RepositoryException($"Falha inesperada ao redefinir a senha do usuário {user.UserName}", ex);
            }
        }

        public async Task<string> GenerateTokenResetPasswordAsync(AspNetUser userEntity)
        {
            try
            {
                string codeResult =
                    await _signInManager
                                .UserManager
                                .GeneratePasswordResetTokenAsync(userEntity);

                if (string.IsNullOrEmpty(codeResult))
                    throw new RepositoryException($"Falha ao gerar token de redefinição de senha");

                return codeResult;
            }
            catch (RepositoryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha ao gerar token de redefinição de senha", this.GetPlace(), ex);
                throw new RepositoryException($"Falha ao gerar token de redefinição de senha", ex);
            }
        }

        public async Task<AspNetUser> CreateAsync(AspNetUser user, List<string> roles)
        {
            try
            {
                user.Id = 0;
                user.ConcurrencyStamp = Guid.NewGuid().ToString().ToLower();
                user.CreatedAt = DateTime.Now;
                user.UpdatedAt = DateTime.Now;

                IdentityResult resultCreateUser =
                    await _signInManager
                            .UserManager
                            .CreateAsync(user, user.PasswordHash);

                if (!resultCreateUser.Succeeded)
                    throw new RepositoryException($"Falha ao criar usuário na base de dados: {user.UserName}");

                await AssociateUserWithRoleAsync(user, roles);
                return user;
            }
            catch (RepositoryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao criar usuário na base de dados", this.GetPlace(), ex);
                throw new RepositoryException($"Falha inesperada ao criar usuário na base de dados", ex);
            }
        }

        private async Task AssociateUserWithRoleAsync(AspNetUser user, List<string> roles, bool isUpdate = false)
        {
            try
            {
                if (roles is null)
                    return;

                if (isUpdate)
                {
                    List<string> rolesUser = await GetRolesByUserAsync(user.Id);
                    IdentityResult resultResetRoles =
                        await _signInManager
                                .UserManager
                                .RemoveFromRolesAsync(user, rolesUser);

                    if (!resultResetRoles.Succeeded)
                        throw new RepositoryException($"Falha inesperada ao remover todos os perfis do usuário {user.UserName}");
                }
                IdentityResult resultAddRoleToUser = await _signInManager
                                                                   .UserManager
                                                                   .AddToRolesAsync(user, roles);

                if (!resultAddRoleToUser.Succeeded)
                    throw new RepositoryException($"Falha ao associar usuário {user.UserName} com os perfis {string.Join('-', roles)}");
            }
            catch (RepositoryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha ao associar perfis {string.Join('-', roles)}, com o usuário {user.UserName}", this.GetPlace(), ex);
                throw new RepositoryException($"Falha ao associar perfis {string.Join('-', roles)}, com o usuário {user.UserName}", ex);
            }
        }

        public async Task<AspNetUser> EditAsync(AspNetUser user, List<string> roles)
        {
            try
            {
                AspNetUser userSave = await GetByIdAsync(user.Id);
                if (userSave is null)
                    throw new RepositoryException($"Nenhum usuário encontrado com o id {user.Id}");

                userSave.FirstName = user.FirstName;
                userSave.LastName = user.LastName;
                userSave.Email = user.Email;
                userSave.NormalizedEmail = user.NormalizedEmail;
                userSave.UserName = user.UserName;
                userSave.NormalizedUserName = user.NormalizedUserName;
                userSave.UpdatedAt = DateTime.Now;

                IdentityResult resultUpdate =
                    await _signInManager
                                .UserManager
                                .UpdateAsync(userSave);

                if (!resultUpdate.Succeeded)
                    throw new RepositoryException($"Falha ao atualizar usuário {user.UserName} na base de dados");

                if (roles is null)
                    return user;

                await AssociateUserWithRoleAsync(userSave, roles, true);
                return user;
            }
            catch (NotFoundException ex)
            {
                throw ex;
            }
            catch (RepositoryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao editar usuário {user.UserName} na base de dados", this.GetPlace(), ex);
                throw new RepositoryException($"Falha inesperada ao editar usuário {user.UserName} na base de dados", ex);
            }
        }

        public async Task<AspNetUser> DeleteAsync(int idUser)
        {
            try
            {
                AspNetUser save = await GetByIdAsync(idUser);
                if (save is null)
                    throw new RepositoryException($"Nenhum usuário encontrado com o id {idUser}");

                save.DisabledAt = DateTime.Now;
                IdentityResult result = await _signInManager
                                                .UserManager
                                                .UpdateAsync(save);

                if (result.Succeeded)
                    return save;

                throw new RepositoryException($"Ocorreu um erro ao deletar o usuário {idUser} no banco");
            }
            catch (NotFoundException ex)
            {
                throw ex;
            }
            catch (RepositoryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao deletar o usuário {idUser} na base de dados", this.GetPlace(), ex);
                throw new RepositoryException($"Falha inesperada ao deletar o usuário {idUser} na base de dados", ex);
            }
        }

        public async Task<int> CountAsync()
        {
            try
            {
                int count =
                    await _signInManager
                            .UserManager
                            .Users
                            .CountAsync();

                return count;
            }
            catch (RepositoryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha ao pegar quantidade de itens na tabela de usuários", this.GetPlace(), ex);
                throw new RepositoryException($"Falha ao pegar quantidade de itens na tabela de usuários", ex);
            }
        }

        public async Task<ListAllEntityVO<AspNetUser>> GetAllAsync(int? limit = null, int? page = null)
        {
            try
            {
                ListAllEntityVO<AspNetUser> response = new ListAllEntityVO<AspNetUser>();
                response.TotalItems = await CountAsync();
                if (response.TotalItems.Value <= 0)
                    return response;

                StaticMethods.GetPaginationItems(ref response, ref limit, ref page);

                response.Items =
                    await _signInManager
                               .UserManager
                               .Users
                               .Where(x => x.DisabledAt == null)
                               .OrderBy(x => x.FirstName)
                               .ThenBy(x => x.LastName)
                               .Skip(limit.Value * page.Value)
                               .Take(limit.Value)
                               .AsNoTracking()
                               .ToListAsync();

                return response;
            }
            catch (RepositoryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao listar usuários no banco de dados", this.GetPlace(), ex);
                throw new RepositoryException($"Falha inesperada ao listar usuários no banco de dados", ex);
            }
        }
    }
}
