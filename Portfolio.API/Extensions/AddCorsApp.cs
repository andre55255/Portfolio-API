using Portfolio.Helpers;

namespace Portfolio.API.Extensions
{
    public static class AddCorsApp
    {
        public static IServiceCollection AddCors(this IServiceCollection services, IConfiguration configuration)
        {
            string[] originsUrls = configuration.GetSection(ConfigAppSettings.ConfigCors)
                                                .Get<string[]>();

            services.AddCors(opt =>
            {
                opt.AddPolicy(ConfigPolicy.Cors, policy =>
                {
                    policy.AllowAnyHeader()
                        .AllowAnyMethod()
                        .WithOrigins(originsUrls)
                        .AllowCredentials()
                        .WithExposedHeaders("Content-Disposition", "Content-FileName");
                });
            });

            return services;
        }
    }
}