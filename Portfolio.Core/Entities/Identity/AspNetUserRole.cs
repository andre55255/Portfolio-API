using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Core.Entities.Identity
{
    [Table("aspnetuser_roles")]
    public class AspNetUserRole : IdentityUserRole<int>
    {
        [Column("user_id")]
        public override int UserId { get; set; }
        [Column("role_id")]
        public override int RoleId { get; set; }
    }
}
