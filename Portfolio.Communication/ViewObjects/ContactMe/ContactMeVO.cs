using Portfolio.HandleFiles.Models;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Communication.ViewObjects.ContactMe
{
    public class SaveContactMeVO
    {
        [Required(ErrorMessage = "Nome não informado")]
        [StringLength(64, ErrorMessage = "Nome deve ter no máximo 64 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Mensagem não informada")]
        [StringLength(1024, ErrorMessage = "Mensagem deve ter no máximo 1024 caracteres")]
        public string Message { get; set; }

        [Required(ErrorMessage = "Contato não informado")]
        [StringLength(64, ErrorMessage = "Contato deve ter no máximo 64 caracteres")]
        public string Contact { get; set; }

        public int? PortfolioId { get; set; }

        public FileBase64Model FileAttachment { get; set; }
    }

    public class ContactMeReturnVO : SaveContactMeVO
    {
        public int Id { get; set; }
        public string PortfolioTitle { get; set; }
    }
}
