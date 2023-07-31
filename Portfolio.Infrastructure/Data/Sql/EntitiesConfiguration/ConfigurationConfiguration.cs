using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Core.Entities.Sql;

namespace Portfolio.Infrastructure.Data.Sql.EntitiesConfiguration
{
    public class ConfigurationConfiguration : IEntityTypeConfiguration<Configuration>
    {
        public void Configure(EntityTypeBuilder<Configuration> builder)
        {
            builder.Property(x => x.Token).HasMaxLength(256).IsRequired();
            builder.Property(x => x.Value).HasMaxLength(256).IsRequired();
            builder.Property(x => x.Extra).HasMaxLength(256).IsRequired(false);
            builder.Property(x => x.CreatedAt).HasColumnType("timestamp").HasDefaultValue(DateTime.Now).IsRequired();
            builder.Property(x => x.UpdatedAt).HasColumnType("timestamp").HasDefaultValue(DateTime.Now).IsRequired();
            builder.Property(x => x.DisabledAt).HasColumnType("timestamp").IsRequired(false);
        }
    }
}
