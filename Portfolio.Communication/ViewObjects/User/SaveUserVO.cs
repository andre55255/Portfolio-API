using System.ComponentModel.DataAnnotations;

namespace Portfolio.Communication.ViewObjects.User
{
    public class RegisterUserVO
    {
        [Required(ErrorMessage = "Primeiro nome não informado")]
        [StringLength(125, ErrorMessage = "Primeiro nome deve ter no máximo 125 caracteres", MinimumLength = 1)]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Sobrenome não informado")]
        [StringLength(125, ErrorMessage = "Sobrenome deve ter no máximo 125 caracteres", MinimumLength = 1)]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Nome de usuário não informado")]
        [StringLength(255, ErrorMessage = "Nome de usuário deve ter no máximo 255 caracteres", MinimumLength = 1)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email não informado")]
        [StringLength(255, ErrorMessage = "Email deve ter no máximo 255 caracteres", MinimumLength = 1)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Número de contato não informado")]
        [StringLength(120, ErrorMessage = "Número de contato deve ter no máximo 120 caracteres", MinimumLength = 1)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Senha não informada")]
        [StringLength(120, ErrorMessage = "Senha deve ter no máximo 120 caracteres", MinimumLength = 1)]
        public string Password { get; set; }
    }

    public class SaveUserVO : RegisterUserVO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Perfil não informado")]
        public List<string> Roles { get; set; }
    }
}
