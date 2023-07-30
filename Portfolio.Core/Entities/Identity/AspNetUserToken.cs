using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Core.Entities.Identity
{
    [Table("SC_ASPNETUSER_TOKENS")]
    public class AspNetUserToken : IdentityUserToken<int>
    {
        [Column("USER_ID")]
        public override int UserId { get; set; }
        [Column("LOGIN_PROVIDER")]
        public override string LoginProvider { get; set; }
        [Column("NAME")]
        public override string Name { get; set; }
        [Column("VALUE")]
        public override string Value { get; set; }
    }
}
