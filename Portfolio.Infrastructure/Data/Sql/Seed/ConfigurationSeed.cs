using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Core.Entities.Sql;
using Portfolio.Helpers;

namespace Portfolio.Infrastructure.Data.Sql.Seed
{
    public class ConfigurationSeed : IEntityTypeConfiguration<Configuration>
    {
        public void Configure(EntityTypeBuilder<Configuration> builder)
        {
            builder.HasData(new Configuration
                {
                    Id = 1,
                    Token = ConfigurationTokens.EmailLogin,
                    Value = "todo"
                },
                new Configuration
                {
                    Id = 2,
                    Token = ConfigurationTokens.EmailPass,
                    Value = "todo"
                },
                new Configuration
                {
                    Id = 3,
                    Token = ConfigurationTokens.EmailPort,
                    Value = "todo"
                },
                new Configuration
                {
                    Id = 4,
                    Token = ConfigurationTokens.EmailSmtp,
                    Value = "todo"
                },
                new Configuration
                {
                    Id = 5,
                    Token = ConfigurationTokens.AttemptsLoginFailed,
                    Value = "todo"
                },
                new Configuration
                {
                    Id = 6,
                    Token = ConfigurationTokens.AttemptsLoginFailedDaysBlock,
                    Value = "todo"
                },
                new Configuration
                {
                    Id = 7,
                    Token = ConfigurationTokens.TimeExpiresAccessToken,
                    Value = "todo"
                },
                new Configuration
                {
                    Id = 8,
                    Token = ConfigurationTokens.TimeExpiresRefreshToken,
                    Value = "todo"
                });
        }
    }
}
