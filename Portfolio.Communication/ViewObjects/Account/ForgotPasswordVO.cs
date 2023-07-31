using System.ComponentModel.DataAnnotations;

namespace Portfolio.Communication.ViewObjects.Account
{
    public class ForgotPasswordVO
    {
        [Required(ErrorMessage = "Nome de usuário não informado")]
        public string UserName { get; set; }
    }
}
