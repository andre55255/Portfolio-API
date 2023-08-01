using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Core.Entities.Sql
{
    [Table("contact_me")]
    public class ContactMe : BaseEntity
    {
        [Column("name")]
        public string Name { get; set; }

        [Column("contact")]
        public string Contact { get; set; }

        [Column("message")]
        public string Message { get; set; }

        [Column("portfolio_id")]
        public int PortfolioId { get; set; }

        //prop navigation
        public PortfolioConfig Portfolio { get; set; }
    }
}
