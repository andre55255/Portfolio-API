using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Core.Entities.Identity
{
    [Table("aspnetuser_tokens")]
    public class AspNetUserToken : IdentityUserToken<int>
    {
        [Column("user_id")]
        public override int UserId { get; set; }
        [Column("login_provider")]
        public override string LoginProvider { get; set; }
        [Column("name")]
        public override string Name { get; set; }
        [Column("value")]
        public override string Value { get; set; }
    }
}
