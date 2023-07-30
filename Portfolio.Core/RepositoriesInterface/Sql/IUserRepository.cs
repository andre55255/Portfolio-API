using Portfolio.Communication.ViewObjects.Utlis;
using Portfolio.Core.Entities.Identity;

namespace Portfolio.Core.RepositoriesInterface.Sql
{
    public interface IUserRepository
    {
        public Task<AspNetUser> CreateAsync(AspNetUser user, List<string> roles);
        public Task<AspNetUser> EditAsync(AspNetUser user, List<string> roles);
        public Task<AspNetUser> DeleteAsync(int idUser);
        public Task<ListAllEntityVO<AspNetUser>> GetAllAsync(int? limit = null, int? page = null);
        public Task<int> CountAsync();
        public Task<AspNetUser> GetByUserNameAsync(string userName);
        public Task<AspNetUser> GetByIdAsync(int id);
        public Task<AspNetUser> GetByEmailAsync(string email);
        public Task<List<string>> GetRolesByUserAsync(int userId);
        public Task SignInUserAsync(AspNetUser user, string password);
        public Task<string> GenerateRefreshTokenAsync(AspNetUser user);
        public Task<string> GetRefreshTokenAsync(AspNetUser userSave);
        public Task ResetPasswordUserSignInAsync(AspNetUser user, string newPassword);
        public Task ResetPasswordUserAsync(AspNetUser user, string newPassword, string code);
        public Task AuthenticationUserByUserNameByPassAsync(AspNetUser user, string password);
    }
}
