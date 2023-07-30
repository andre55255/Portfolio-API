using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Core.Entities.Identity
{
    [Table("aspnetuser_claims")]
    public class AspNetUserClaim : IdentityUserClaim<int>
    {
        [Key]
        [Column("id")]
        public override int Id { get; set; }
        [Column("user_id")]
        public override int UserId { get; set; }
        [Column("claim_type")]
        public override string ClaimType { get; set; }
        [Column("claim_value")]
        public override string ClaimValue { get; set; }
    }
}
