using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Core.Entities.Sql;

namespace Portfolio.Infrastructure.Data.Sql.EntitiesConfiguration
{
    public class StackConfiguration : IEntityTypeConfiguration<Stack>
    {
        public void Configure(EntityTypeBuilder<Stack> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(64).IsRequired();
            builder.Property(x => x.Link).HasMaxLength(256).IsRequired();
            builder.Property(x => x.Color).HasMaxLength(32).IsRequired();
            builder.Property(x => x.PortfolioId).IsRequired();
            builder.Property(x => x.CreatedAt).HasColumnType("timestamp").HasDefaultValue(DateTime.Now).IsRequired();
            builder.Property(x => x.UpdatedAt).HasColumnType("timestamp").HasDefaultValue(DateTime.Now).IsRequired();
            builder.Property(x => x.DisabledAt).HasColumnType("timestamp").IsRequired(false);
        }
    }
}
