using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Core.Entities.Sql
{
    [Table("project")]
    public class Project : BaseEntity
    {
        [Column("title")]
        public string Title { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("techs")]
        public string Techs { get; set; }

        [Column("link_preview")]
        public string LinkPreview { get; set; }

        [Column("link_view_code")]
        public string LinkViewCode { get; set; }

        [Column("portfolio_id")]
        public int PortfolioId { get; set; }

        // Prop navigation
        public virtual PortfolioConfig Portfolio { get; set; }
    }
}
