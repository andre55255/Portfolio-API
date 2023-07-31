using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Portfolio.Core.Entities.Sql;

namespace Portfolio.Infrastructure.Data.Sql.EntitiesConfiguration
{
    public class GenericTypeConfiguration : IEntityTypeConfiguration<GenericType>
    {
        public void Configure(EntityTypeBuilder<GenericType> builder)
        {
            builder.Property(x => x.Token).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Value).HasMaxLength(512).IsRequired(false);
            builder.Property(x => x.Description).HasMaxLength(1024).IsRequired();
            builder.Property(x => x.ValueBool).IsRequired(false);
            builder.Property(x => x.CreatedAt).HasColumnType("timestamp").HasDefaultValue(DateTime.Now).IsRequired();
            builder.Property(x => x.UpdatedAt).HasColumnType("timestamp").HasDefaultValue(DateTime.Now).IsRequired();
            builder.Property(x => x.DisabledAt).HasColumnType("timestamp").IsRequired(false);
        }
    }
}
