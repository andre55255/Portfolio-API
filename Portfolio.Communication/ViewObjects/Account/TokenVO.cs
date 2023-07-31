using Portfolio.Communication.ViewObjects.User;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Communication.ViewObjects.Account
{
    public class LoginVO
    {
        [Required(ErrorMessage = "Nome de usuário não informado")]
        [StringLength(50, ErrorMessage = "Nome de usuário deve ter entre 2 e 50 caracteres", MinimumLength = 2)]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Senha não informado")]
        [StringLength(50, ErrorMessage = "Senha deve ter entre 2 e 50 caracteres", MinimumLength = 2)]
        public string Password { get; set; }
    }

    public class RefreshTokenVO
    {
        [Required(ErrorMessage = "Token de acesso não informado")]
        public string AccessToken { get; set; }
        [Required(ErrorMessage = "Refresh token não informado")]
        public string RefreshToken { get; set; }
    }

    public class LoginResponseTokenVO
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime? ExpirationAt { get; set; } = null;
        public UserWithRolesVO User { get; set; }
    }

    public class TokenSettingsVO
    {
        public string JwtSecret { get; set; }
        public string JwtIssuer { get; set; }
        public string JwtAudience { get; set; }
        public int TimeExpiresInMinuntesAccessToken { get; set; }
        public int TimeExpiresInMinuntesRefreshToken { get; set; }
    }
}
