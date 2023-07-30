using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Portfolio.Core.Entities.Identity;
using Portfolio.Core.Entities.Sql;
using Portfolio.Infrastructure.Data.Sql.EntitiesConfiguration;

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

        public SqlDbContext(DbContextOptions<SqlDbContext> opt) : base(opt)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ConfigurationConfiguration());
        }
    }
}
