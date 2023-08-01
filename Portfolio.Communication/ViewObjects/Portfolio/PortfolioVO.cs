using Portfolio.Communication.CustomAnnotations;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Communication.ViewObjects.Portfolio
{
    public class SavePortfolioVO
    {
        [Required(ErrorMessage = "Key não informada")]
        [StringLength(256, ErrorMessage = "Key deve ter no máximo 256 caracteres")]
        public string KeyAccess { get; set; }

        [Required(ErrorMessage = "Título não informada")]
        [StringLength(64, ErrorMessage = "Título deve ter no máximo 64 caracteres")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Primeiro nome não informada")]
        [StringLength(128, ErrorMessage = "Primeiro nome deve ter no máximo 128 caracteres")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Sobrenome não informada")]
        [StringLength(128, ErrorMessage = "Sobrenome deve ter no máximo 128 caracteres")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Link do github não informada")]
        [StringLength(256, ErrorMessage = "Link do github deve ter no máximo 256 caracteres")]
        public string GithubLink { get; set; }

        [Required(ErrorMessage = "Link do linkedin não informada")]
        [StringLength(256, ErrorMessage = "Link do linkedin deve ter no máximo 256 caracteres")]
        public string LinkedinLink { get; set; }

        [Required(ErrorMessage = "Email não informada")]
        [EmailValid(ErrorMessage = "Email inválido")]
        [StringLength(256, ErrorMessage = "Email deve ter no máximo 256 caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Número de telefone de contato não informada")]
        [StringLength(64, ErrorMessage = "Número de telefone de contato deve ter no máximo 64 caracteres")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Sobre mim não informada")]
        [StringLength(512, ErrorMessage = "Sobre mim deve ter no máximo 512 caracteres")]
        public string AboutMe { get; set; }

        [Required(ErrorMessage = "Usuários associados a este portfolio não informados, verifique")]
        public List<int> UsersIds { get; set; }
    }

    public class PortfolioReturnVO : SavePortfolioVO
    {
        public int Id { get; set; } = 0;
        public List<string> UsersNameAssociates { get; set; }
    }
}
