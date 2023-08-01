using Portfolio.Core.Entities.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Core.Entities.Sql
{
    [Table("portfolio_users")]
    public class PortfolioConfigUsersAssociate
    {
        [Column("portfolio_id")]
        public int PortfolioId { get; set; }
        [Column("user_id")]
        public int UserId { get; set; }

        // Prop navigation
        public virtual AspNetUser User { get; set; }
        public virtual PortfolioConfig Portfolio { get; set; }
    }
}
