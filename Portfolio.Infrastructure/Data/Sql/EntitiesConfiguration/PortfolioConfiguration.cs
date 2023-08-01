using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Core.Entities.Sql;

namespace Portfolio.Infrastructure.Data.Sql.EntitiesConfiguration
{
    public class PortfolioConfiguration : IEntityTypeConfiguration<PortfolioConfig>
    {
        public void Configure(EntityTypeBuilder<PortfolioConfig> builder)
        {
            builder.HasMany(x => x.UsersAssociates)
                   .WithMany(x => x.PortfoliosAssociates)
                   .UsingEntity<PortfolioConfigUsersAssociate>(
                        x => x.HasOne(x => x.User)
                              .WithMany(x => x.PortolioUsersAssociates)
                              .HasForeignKey(x => x.UserId)
                              .OnDelete(DeleteBehavior.NoAction),
                        x => x.HasOne(x => x.Portfolio)
                              .WithMany(x => x.PortolioUsersAssociates)
                              .HasForeignKey(x => x.PortfolioId)
                              .OnDelete(DeleteBehavior.NoAction)
                    );

            builder.Property(x => x.KeyAccess).HasMaxLength(256).IsRequired(true);
            builder.Property(x => x.Title).HasMaxLength(64).IsRequired(true);
            builder.Property(x => x.Firstname).HasMaxLength(128).IsRequired(true);
            builder.Property(x => x.Lastname).HasMaxLength(128).IsRequired(true);
            builder.Property(x => x.GithubLink).HasMaxLength(256).IsRequired(true);
            builder.Property(x => x.LinkedinLink).HasMaxLength(256).IsRequired(true);
            builder.Property(x => x.Email).HasMaxLength(256).IsRequired(true);
            builder.Property(x => x.PhoneNumber).HasMaxLength(64).IsRequired(true);
            builder.Property(x => x.AboutMe).HasMaxLength(512).IsRequired(true);
            builder.Property(x => x.CreatedAt).HasColumnType("timestamp").HasDefaultValue(DateTime.Now).IsRequired();
            builder.Property(x => x.UpdatedAt).HasColumnType("timestamp").HasDefaultValue(DateTime.Now).IsRequired();
            builder.Property(x => x.DisabledAt).HasColumnType("timestamp").IsRequired(false);
        }
    }
}
