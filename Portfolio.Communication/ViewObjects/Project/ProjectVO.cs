using Portfolio.HandleFiles.Models;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Communication.ViewObjects.Project
{
    public class SaveProjectVO
    {
        [Required(ErrorMessage = "Título não informado")]
        [StringLength(32, ErrorMessage = "Títutlo deve ter no máximo 32 caracteres")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Descrição não informada")]
        [StringLength(320, ErrorMessage = "Descrição deve ter no máximo 320 caracteres")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Techs não informada")]
        [StringLength(128, ErrorMessage = "Techs deve ter no máximo 128 caracteres")]
        public string Techs { get; set; }

        [StringLength(512, ErrorMessage = "Link de preview deve ter no máximo 512 caracteres")]
        public string LinkPreview { get; set; }

        [Required(ErrorMessage = "Link de código fonte não informada")]
        [StringLength(512, ErrorMessage = "Link de código fonte deve ter no máximo 512 caracteres")]
        public string LinkViewCode { get; set; }

        [Required(ErrorMessage = "Id de portfolio não informada")]
        public int PortfolioId { get; set; }

        [Required(ErrorMessage = "Imagem de thumb de projeto não informada")]
        public FileBase64Model FileThumbImg { get; set; }
    }

    public class ProjectReturnVO : SaveProjectVO
    {
        public int Id { get; set; }
        public List<string> TechsList { get; set; }
        public string PortfolioTitle { get; set; }
    }
}
