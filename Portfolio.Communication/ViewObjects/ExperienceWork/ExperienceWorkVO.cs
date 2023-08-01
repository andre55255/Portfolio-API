using System.ComponentModel.DataAnnotations;

namespace Portfolio.Communication.ViewObjects.ExperienceWork
{
    public class SaveExperienceWorkVO
    {
        [Required(ErrorMessage = "Cargo não informado")]
        [StringLength(256, ErrorMessage = "Cargo deve ter no máximo 256 caracteres")]
        public string OfficeName { get; set; }

        [Required(ErrorMessage = "Nome da empresa não informado")]
        [StringLength(256, ErrorMessage = "Nome da empresa deve ter no máximo 256 caracteres")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Localização da empresa não informado")]
        [StringLength(256, ErrorMessage = "Localização da empresa deve ter no máximo 256 caracteres")]
        public string CompanyLocalization { get; set; }

        [Required(ErrorMessage = "Data de inicio não informada")]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [Required(ErrorMessage = "Portfolio não informado")]
        public int PortfolioId { get; set; }

        [Required(ErrorMessage = "Status de jornada não informado")]
        public int JourneyWorkStatusId { get; set; }
    }

    public class ExperienceWorkReturnVO : SaveExperienceWorkVO
    {
        public int Id { get; set; }
        public string PortfolioTitle { get; set; }
        public string JourneyWorkStatusName { get; set; }
    }
}
