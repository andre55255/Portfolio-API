using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Core.Entities.Sql
{
    [Table("stack")]
    public class Stack : BaseEntity
    {
        [Column("name")]
        public string Name { get; set; }

        [Column("link")]
        public string Link { get; set; }

        [Column("color")]
        public string Color { get; set; }

        [Column("portfolio_id")]
        public int PortfolioId { get; set; }

        // Prop navigation
        public virtual PortfolioConfig Portfolio { get; set; }
    }
}
