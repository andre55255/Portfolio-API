using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Core.Entities.Sql;

namespace Portfolio.Infrastructure.Data.Sql.EntitiesConfiguration
{
    public class ContactMeConfiguration : IEntityTypeConfiguration<ContactMe>
    {
        public void Configure(EntityTypeBuilder<ContactMe> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(256).IsRequired();
            builder.Property(x => x.Message).HasMaxLength(1024).IsRequired();
            builder.Property(x => x.Contact).HasMaxLength(256).IsRequired();
            builder.Property(x => x.CreatedAt).HasColumnType("timestamp").HasDefaultValue(DateTime.Now).IsRequired();
            builder.Property(x => x.UpdatedAt).HasColumnType("timestamp").HasDefaultValue(DateTime.Now).IsRequired();
            builder.Property(x => x.DisabledAt).HasColumnType("timestamp").IsRequired(false);
        }
    }
}
