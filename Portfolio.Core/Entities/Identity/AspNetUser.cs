using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Core.Entities.Identity
{
    [Table("SC_ASPNETUSERS")]
    public class AspNetUser : IdentityUser<int>
    {
        // Props personalized
        [Column("NAME")]
        public string Name { get; set; }
        [Column("LAST_NAME")]
        public string LastName { get; set; }
        [Column("CREATED_AT")]
        public DateTime CreatedAt { get; set; }
        [Column("UPDATED_AT")]
        public DateTime UpdatedAt { get; set; }
        [Column("DISABLED_AT")]
        public DateTime? DisabledAt { get; set; }

        // Props identity
        [Key]
        [Column("ID")]
        public override int Id { get; set; }
        [Column("LOCKOUT_END")]
        public override DateTimeOffset? LockoutEnd { get; set; }
        [Column("TWO_FACTOR_ENABLED")]
        public override bool TwoFactorEnabled { get; set; }
        [Column("PHONE_NUMBER_CONFIRMED")]
        public override bool PhoneNumberConfirmed { get; set; }
        [Column("PHONE_NUMBER")]
        public override string PhoneNumber { get; set; }
        [Column("CONCURRENCY_STAMP")]
        public override string ConcurrencyStamp { get; set; }
        [Column("SECURITY_STAMP")]
        public override string SecurityStamp { get; set; }
        [Column("PASSWORD_HASH")]
        public override string PasswordHash { get; set; }
        [Column("EMAIL_CONFIRMED")]
        public override bool EmailConfirmed { get; set; }
        [Column("NORMALIZED_EMAIL")]
        public override string NormalizedEmail { get; set; }
        [Column("EMAIL")]
        public override string Email { get; set; }
        [Column("NORMALIZED_USERNAME")]
        public override string NormalizedUserName { get; set; }
        [Column("USERNAME")]
        public override string UserName { get; set; }
        [Column("LOCKOUT_ENABLED")]
        public override bool LockoutEnabled { get; set; }
        [Column("ACCESS_FAILED_COUNT")]
        public override int AccessFailedCount { get; set; }
    }
}
