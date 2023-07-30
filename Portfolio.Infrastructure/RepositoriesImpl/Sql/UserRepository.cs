using Portfolio.Communication.ViewObjects.Utlis;
using Portfolio.Core.Entities.Identity;
using Portfolio.Core.RepositoriesInterface.Sql;

namespace Portfolio.Infrastructure.RepositoriesImpl.Sql
{
    public class UserRepository : IUserRepository
    {
        public Task AuthenticationUserByUserNameByPassAsync(AspNetUser user, string password)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AspNetUser> CreateAsync(AspNetUser user, List<string> roles)
        {
            throw new NotImplementedException();
        }

        public Task<AspNetUser> DeleteAsync(int idUser)
        {
            throw new NotImplementedException();
        }

        public Task<AspNetUser> EditAsync(AspNetUser user, List<string> roles)
        {
            throw new NotImplementedException();
        }

        public Task<string> GenerateRefreshTokenAsync(AspNetUser user)
        {
            throw new NotImplementedException();
        }

        public Task<ListAllEntityVO<AspNetUser>> GetAllAsync(int? limit = null, int? page = null)
        {
            throw new NotImplementedException();
        }

        public Task<AspNetUser> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<AspNetUser> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<AspNetUser> GetByUserNameAsync(string userName)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetRefreshTokenAsync(AspNetUser userSave)
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> GetRolesByUserAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task ResetPasswordUserAsync(AspNetUser user, string newPassword, string code)
        {
            throw new NotImplementedException();
        }

        public Task ResetPasswordUserSignInAsync(AspNetUser user, string newPassword)
        {
            throw new NotImplementedException();
        }

        public Task SignInUserAsync(AspNetUser user, string password)
        {
            throw new NotImplementedException();
        }
    }
}
