using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Core.Entities.Identity
{
    [Table("SC_ASPNETUSER_ROLES")]
    public class AspNetUserRole : IdentityUserRole<int>
    {
        [Column("USER_ID")]
        public override int UserId { get; set; }
        [Column("ROLE_ID")]
        public override int RoleId { get; set; }
    }
}
