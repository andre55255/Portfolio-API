using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Portfolio.Core.Entities.Identity;
using Portfolio.Core.Entities.Sql;
using Portfolio.Infrastructure.Data.Sql.EntitiesConfiguration;
using Portfolio.Infrastructure.Data.Sql.Seed;

namespace Portfolio.Infrastructure.Data.Sql.Context
{
    public class SqlDbContext : IdentityDbContext<AspNetUser,
                                                 AspNetRole,
                                                 int,
                                                 AspNetUserClaim,
                                                 AspNetUserRole,
                                                 AspNetUserLogin,
                                                 AspNetRoleClaim,
                                                 AspNetUserToken>
    {
        public DbSet<Configuration> Configurations { get; set; }
        public DbSet<GenericType> GenericTypes { get; set; }

        public SqlDbContext(DbContextOptions<SqlDbContext> opt) : base(opt)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Config name tables identity
            builder.Entity<AspNetUser>()
                   .ToTable("aspnetusers");

            builder.Entity<AspNetRole>()
                   .ToTable("aspnetroles");

            builder.Entity<AspNetRoleClaim>()
                   .ToTable("aspnetrole_claims");

            builder.Entity<AspNetUserClaim>()
                   .ToTable("aspnetuser_claims");

            builder.Entity<AspNetUserRole>()
                   .ToTable("aspnetuser_roles");

            builder.Entity<AspNetUserLogin>()
                   .ToTable("aspnetuser_logins");

            builder.Entity<AspNetUserToken>()
                   .ToTable("aspnetuser_tokens");

            // Seed default entities
            builder.ApplyConfiguration(new AddUserAdminDefault())
                   .ApplyConfiguration(new AddRolesDefault())
                   .ApplyConfiguration(new AddRelationUserAdminToRoleDefault())
                   .ApplyConfiguration(new ConfigurationSeed())
                   .ApplyConfiguration(new GenericTypeSeed());

            // Configuration entities
            builder.ApplyConfiguration(new AspNetUserConfiguration())
                   .ApplyConfiguration(new ConfigurationConfiguration())
                   .ApplyConfiguration(new GenericTypeConfiguration());
        }
    }
}
