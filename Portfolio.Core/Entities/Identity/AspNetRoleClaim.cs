using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Core.Entities.Identity
{
    [Table("aspnetrole_claims")]
    public class AspNetRoleClaim : IdentityRoleClaim<int>
    {
        [Key]
        [Column("id")]
        public override int Id { get; set; }
        [Column("role_id")]
        public override int RoleId { get; set; }
        [Column("claim_type")]
        public override string ClaimType { get; set; }
        [Column("claim_value")]
        public override string ClaimValue { get; set; }
    }
}
