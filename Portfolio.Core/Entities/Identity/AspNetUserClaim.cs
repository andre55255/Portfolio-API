using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Core.Entities.Identity
{
    [Table("SC_ASPNETUSER_CLAIMS")]
    public class AspNetUserClaim : IdentityUserClaim<int>
    {
        [Key]
        [Column("ID")]
        public override int Id { get; set; }
        [Column("USER_ID")]
        public override int UserId { get; set; }
        [Column("CLAIM_TYPE")]
        public override string ClaimType { get; set; }
        [Column("CLAIM_VALUE")]
        public override string ClaimValue { get; set; }
    }
}
