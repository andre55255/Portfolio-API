using Portfolio.Communication.ViewObjects.Account;
using Portfolio.Communication.ViewObjects.User;

namespace Portfolio.Core.ServicesInterface
{
    public interface IAccountService
    {
        public Task<LoginResponseTokenVO> LoginAsync(LoginVO model);
        public Task<RefreshTokenVO> RefreshTokenAsync(RefreshTokenVO model);
        public Task<UserInfoVO> GetUserInfoAsync(int userId);
        public Task ResetPasswordSignInUserAsync(int userId, ResetPasswordSignInVO model);
        public Task<string> ForgotPasswordSendMailAsync(ForgotPasswordVO model);
        public Task<UserWithRolesVO> RegisterUserAsync(RegisterUserVO model);
    }
}
