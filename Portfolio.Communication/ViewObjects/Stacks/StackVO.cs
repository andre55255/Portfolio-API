using Portfolio.HandleFiles.Models;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Communication.ViewObjects.Stacks
{
    public class SaveStackVO
    {
        [Required(ErrorMessage = "Nome não informado")]
        [StringLength(64, ErrorMessage = "Nome deve ter no máximo 64 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Link não informado")]
        [StringLength(256, ErrorMessage = "Link deve ter no máximo 256 caracteres")]
        public string Link { get; set; }

        [Required(ErrorMessage = "Cor não informada")]
        [StringLength(32, ErrorMessage = "Cor deve ter no máximo 32 caracteres")]
        public string Color { get; set; }

        [Required(ErrorMessage = "Id de portfolio não informado")]
        public int PortfolioId { get; set; }

        [Required(ErrorMessage = "Não foi informada a imagem de icone da stack")]
        public FileBase64Model Image { get; set; }
    }

    public class StackReturnVO : SaveStackVO
    {
        public int Id { get; set; }
        public string PortfolioTitle { get; set; }
    }
}
