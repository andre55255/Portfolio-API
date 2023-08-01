using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Core.Entities.Sql
{
    [Table("experience_education")]
    public class ExperienceEducation : BaseEntity
    {
        [Column("education_name")]
        public string EducationName { get; set; }

        [Column("instituition_name")]
        public string InstituitionName { get; set; }

        [Column("instituition_localization")]
        public string InstituitionLocalization { get; set; }

        [Column("start_date")]
        public DateTime StartDate { get; set; }

        [Column("end_date")]
        public DateTime? EndDate { get; set; }

        [Column("portfolio_id")]
        public int PortfolioId { get; set; }

        [Column("journey_work_status_id")]
        public int JourneyWorkStatusId { get; set; }

        // Prop navigation
        public virtual PortfolioConfig Portfolio { get; set; }
        public virtual GenericType JourneyWorkStatus { get; set; }
    }
}
