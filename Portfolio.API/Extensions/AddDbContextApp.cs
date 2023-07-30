using Microsoft.EntityFrameworkCore;
using Portfolio.Helpers;
using Portfolio.Infrastructure.Data.Sql.Context;

namespace Portfolio.API.Extensions
{
    public static class AddDbContextApp
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            string pgBManager = configuration.GetConnectionString(ConfigAppSettings.ConnectionPgBManager);
            services.AddDbContext<SqlDbContext>(opt =>
            {
                opt.UseNpgsql(pgBManager,
                    builder =>
                    {
                        builder.EnableRetryOnFailure();
                    });
            });
            return services;
        }
    }
}
