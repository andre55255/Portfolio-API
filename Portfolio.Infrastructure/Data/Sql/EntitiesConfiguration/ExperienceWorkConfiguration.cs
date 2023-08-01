using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Core.Entities.Sql;

namespace Portfolio.Infrastructure.Data.Sql.EntitiesConfiguration
{
    public class ExperienceWorkConfiguration : IEntityTypeConfiguration<ExperienceWork>
    {
        public void Configure(EntityTypeBuilder<ExperienceWork> builder)
        {
            builder.HasOne(x => x.Portfolio)
                   .WithMany(x => x.ExperiencesWorks)
                   .HasForeignKey(x => x.PortfolioId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.JourneyWorkStatus)
                   .WithMany(x => x.ExperiencesWorks)
                   .HasForeignKey(x => x.JourneyWorkStatusId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.OfficeName).HasMaxLength(256).IsRequired(true);
            builder.Property(x => x.CompanyName).HasMaxLength(256).IsRequired(true);
            builder.Property(x => x.CompanyLocalization).HasMaxLength(256).IsRequired(true);
            builder.Property(x => x.StartDate).IsRequired(true);
            builder.Property(x => x.EndDate).IsRequired(true);
            builder.Property(x => x.PortfolioId).IsRequired(true);
            builder.Property(x => x.JourneyWorkStatusId).IsRequired(true);
            builder.Property(x => x.CreatedAt).HasColumnType("timestamp").HasDefaultValue(DateTime.Now).IsRequired();
            builder.Property(x => x.UpdatedAt).HasColumnType("timestamp").HasDefaultValue(DateTime.Now).IsRequired();
            builder.Property(x => x.DisabledAt).HasColumnType("timestamp").IsRequired(false);
        }
    }
}
