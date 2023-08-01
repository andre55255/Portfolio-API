using System.ComponentModel.DataAnnotations;

namespace Portfolio.Communication.ViewObjects.ExperienceEducation
{
    public class SaveExperienceEducationVO
    {
        [Required(ErrorMessage = "Cargo não informado")]
        [StringLength(256, ErrorMessage = "Cargo deve ter no máximo 256 caracteres")]
        public string EducationName { get; set; }

        [Required(ErrorMessage = "Nome da empresa não informado")]
        [StringLength(256, ErrorMessage = "Nome da empresa deve ter no máximo 256 caracteres")]
        public string InstituitionName { get; set; }

        [Required(ErrorMessage = "Localização da empresa não informado")]
        [StringLength(256, ErrorMessage = "Localização da empresa deve ter no máximo 256 caracteres")]
        public string InstituitionLocalization { get; set; }

        [Required(ErrorMessage = "Data de inicio não informada")]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [Required(ErrorMessage = "Portfolio não informado")]
        public int PortfolioId { get; set; }

        [Required(ErrorMessage = "Status de jornada não informado")]
        public int JourneyEducationStatusId { get; set; }
    }

    public class ExperienceEducationReturnVO : SaveExperienceEducationVO
    {
        public int Id { get; set; }
        public string PortfolioTitle { get; set; }
        public string JourneyWorkStatusName { get; set; }
    }
}
