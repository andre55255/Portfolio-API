using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Core.Entities.Sql;

namespace Portfolio.Infrastructure.Data.Sql.EntitiesConfiguration
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.Property(x => x.Title).HasMaxLength(32).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(320).IsRequired();
            builder.Property(x => x.Techs).HasMaxLength(128).IsRequired();
            builder.Property(x => x.LinkPreview).HasMaxLength(512).IsRequired(false);
            builder.Property(x => x.LinkViewCode).HasMaxLength(512).IsRequired();
            builder.Property(x => x.PortfolioId).IsRequired();
            builder.Property(x => x.CreatedAt).HasColumnType("timestamp").HasDefaultValue(DateTime.Now).IsRequired();
            builder.Property(x => x.UpdatedAt).HasColumnType("timestamp").HasDefaultValue(DateTime.Now).IsRequired();
            builder.Property(x => x.DisabledAt).HasColumnType("timestamp").IsRequired(false);
        }
    }
}
