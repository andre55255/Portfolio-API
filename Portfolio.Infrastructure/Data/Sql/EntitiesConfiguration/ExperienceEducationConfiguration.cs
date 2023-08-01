using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Core.Entities.Sql;

namespace Portfolio.Infrastructure.Data.Sql.EntitiesConfiguration
{
    public class ExperienceEducationConfiguration : IEntityTypeConfiguration<ExperienceEducation>
    {
        public void Configure(EntityTypeBuilder<ExperienceEducation> builder)
        {
            builder.HasOne(x => x.Portfolio)
                   .WithMany(x => x.ExperiencesEducations)
                   .HasForeignKey(x => x.PortfolioId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.JourneyWorkStatus)
                   .WithMany(x => x.ExperiencesEducations)
                   .HasForeignKey(x => x.JourneyWorkStatusId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.EducationName).HasMaxLength(256).IsRequired(true);
            builder.Property(x => x.InstituitionName).HasMaxLength(256).IsRequired(true);
            builder.Property(x => x.InstituitionLocalization).HasMaxLength(256).IsRequired(true);
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
