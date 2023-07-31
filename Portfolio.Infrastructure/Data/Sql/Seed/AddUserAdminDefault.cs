using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Portfolio.Core.Entities.Identity;

namespace Portfolio.Infrastructure.Data.Sql.Seed
{
    public class AddUserAdminDefault : IEntityTypeConfiguration<AspNetUser>
    {
        public void Configure(EntityTypeBuilder<AspNetUser> builder)
        {
            AspNetUser admin = new AspNetUser
            {
                Id = 1,
                FirstName = "Admin",
                LastName = "ALB Portfolio",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "andre_luiz.b5@outlook.com",
                NormalizedEmail = "ANDRE_LUIZ.B5@OUTLOOK.COM",
                EmailConfirmed = true,
                AccessFailedCount = 0,
                PhoneNumber = "31 995600166",
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };
            PasswordHasher<AspNetUser> hasher = new PasswordHasher<AspNetUser>();
            admin.PasswordHash = hasher.HashPassword(admin, "abc123");

            builder.HasData(admin);
        }
    }

    public class AddRolesDefault : IEntityTypeConfiguration<AspNetRole>
    {
        public void Configure(EntityTypeBuilder<AspNetRole> builder)
        {
            builder.HasData(
                new AspNetRole
                {
                    Id = 1,
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
                new AspNetRole
                {
                    Id = 2,
                    Name = "User",
                    NormalizedName = "USER",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                }
            );
        }
    }

    public class AddRelationUserAdminToRoleDefault : IEntityTypeConfiguration<AspNetUserRole>
    {
        public void Configure(EntityTypeBuilder<AspNetUserRole> builder)
        {
            builder.HasData(new AspNetUserRole
            {
                UserId = 1,
                RoleId = 1
            });
            builder.HasData(new AspNetUserRole
            {
                UserId = 1,
                RoleId = 2
            });
        }
    }
}
