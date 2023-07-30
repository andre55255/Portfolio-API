using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Core.Entities.Identity
{
    [Table("aspnetuser_logins")]
    public class AspNetUserLogin : IdentityUserLogin<int>
    {
        [Column("login_provider")]
        public override string LoginProvider { get; set; }
        [Column("provider_key")]
        public override string ProviderKey { get; set; }
        [Column("provider_display_name")]
        public override string ProviderDisplayName { get; set; }
        [Column("user_id")]
        public override int UserId { get; set; }
    }
}
