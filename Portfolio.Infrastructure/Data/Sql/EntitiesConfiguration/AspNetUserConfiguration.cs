using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Core.Entities.Identity;

namespace Portfolio.Infrastructure.Data.Sql.EntitiesConfiguration
{
    public class AspNetUserConfiguration : IEntityTypeConfiguration<AspNetUser>
    {
        public void Configure(EntityTypeBuilder<AspNetUser> builder)
        {
            builder.Property(x => x.FirstName).HasMaxLength(125).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(125).IsRequired();
            builder.Property(x => x.UserName).HasMaxLength(255).IsRequired();
            builder.Property(x => x.NormalizedUserName).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(255).IsRequired();
            builder.Property(x => x.NormalizedEmail).HasMaxLength(255).IsRequired();
            builder.Property(x => x.CreatedAt).HasColumnType("timestamp").HasDefaultValue(DateTime.Now).IsRequired();
            builder.Property(x => x.UpdatedAt).HasColumnType("timestamp").HasDefaultValue(DateTime.Now).IsRequired();
            builder.Property(x => x.DisabledAt).HasColumnType("timestamp").IsRequired(false);
        }
    }
}
