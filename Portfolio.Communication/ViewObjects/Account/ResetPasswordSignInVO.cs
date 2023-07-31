using System.ComponentModel.DataAnnotations;

namespace Portfolio.Communication.ViewObjects.Account
{
    public class ResetPasswordSignInVO
    {
        [Required(ErrorMessage = "Informar senha antiga")]
        [StringLength(50, ErrorMessage = "A senha deve ter no máximo 50 caracteres e no mínimo 6", MinimumLength = 6)]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Nova senha não informada")]
        [StringLength(50, ErrorMessage = "A senha deve ter no máximo 50 caracteres e no mínimo 6", MinimumLength = 6)]
        public string NewPassword { get; set; }
    }
}
