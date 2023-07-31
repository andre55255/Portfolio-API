using Portfolio.Communication.ViewObjects.User;
using Portfolio.Communication.ViewObjects.Utlis;

namespace Portfolio.Core.ServicesInterface
{
    public interface IUserService
    {
        public Task<UserWithRolesVO> GetUserWithRolesAsync(int? userId = null, string userName = null, string email = null);
        public Task<UserWithRolesVO> CreateUserAsync(SaveUserVO model);
        public Task<UserWithRolesVO> EditUserAsync(int? id, SaveUserVO model);
        public Task<UserWithRolesVO> DeleteUserAsync(int? idUser);
        public Task<ListAllEntityVO<UserWithRolesVO>> GetAllUsersAsync(int? limit = null, int? page = null);
    }
}
