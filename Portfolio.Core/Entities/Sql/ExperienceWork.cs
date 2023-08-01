using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Core.Entities.Sql
{
    [Table("experience_work")]
    public class ExperienceWork : BaseEntity
    {
        [Column("office_name")]
        public string OfficeName { get; set; }

        [Column("company_name")]
        public string CompanyName { get; set; }

        [Column("company_localization")]
        public string CompanyLocalization { get; set; }

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
