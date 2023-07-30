using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Core.Entities.Identity
{
    [Table("SC_ASPNETROLE_CLAIMS")]
    public class AspNetRoleClaim : IdentityRoleClaim<int>
    {
        [Key]
        [Column("ID")]
        public override int Id { get; set; }
        [Column("ROLE_ID")]
        public override int RoleId { get; set; }
        [Column("CLAIM_TYPE")]
        public override string ClaimType { get; set; }
        [Column("CLAIM_VALUE")]
        public override string ClaimValue { get; set; }
    }
}
