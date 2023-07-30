using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Core.Entities.Identity
{
    [Table("SC_ASPNETUSER_LOGINS")]
    public class AspNetUserLogin : IdentityUserLogin<int>
    {
        [Column("LOGIN_PROVIDER")]
        public override string LoginProvider { get; set; }
        [Column("PROVIDER_KEY")]
        public override string ProviderKey { get; set; }
        [Column("PROVIDER_DISPLAY_NAME")]
        public override string ProviderDisplayName { get; set; }
        [Column("USER_ID")]
        public override int UserId { get; set; }
    }
}
