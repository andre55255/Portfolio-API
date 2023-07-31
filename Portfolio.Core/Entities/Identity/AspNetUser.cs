using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Core.Entities.Identity
{
    [Table("aspnetusers")]
    public class AspNetUser : IdentityUser<int>
    {
        // Props personalized
        [Column("name")]
        public string FirstName { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
        [Column("disabled_at")]
        public DateTime? DisabledAt { get; set; }

        // Props identity
        [Key]
        [Column("id")]
        public override int Id { get; set; }
        [Column("lockout_end")]
        public override DateTimeOffset? LockoutEnd { get; set; }
        [Column("two_factor_enabled")]
        public override bool TwoFactorEnabled { get; set; }
        [Column("phone_number_confirmed")]
        public override bool PhoneNumberConfirmed { get; set; }
        [Column("phone_number")]
        public override string PhoneNumber { get; set; }
        [Column("concurrency_stamp")]
        public override string ConcurrencyStamp { get; set; }
        [Column("security_stamp")]
        public override string SecurityStamp { get; set; }
        [Column("password_hash")]
        public override string PasswordHash { get; set; }
        [Column("email_confirmed")]
        public override bool EmailConfirmed { get; set; }
        [Column("normalized_email")]
        public override string NormalizedEmail { get; set; }
        [Column("email")]
        public override string Email { get; set; }
        [Column("normalized_username")]
        public override string NormalizedUserName { get; set; }
        [Column("username")]
        public override string UserName { get; set; }
        [Column("lockout_enabled")]
        public override bool LockoutEnabled { get; set; }
        [Column("access_failed_count")]
        public override int AccessFailedCount { get; set; }
    }
}