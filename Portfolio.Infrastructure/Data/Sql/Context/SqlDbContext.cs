using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Portfolio.Core.Entities.Identity;

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
        public SqlDbContext(DbContextOptions<SqlDbContext> opt) : base(opt)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


        }
    }
}
