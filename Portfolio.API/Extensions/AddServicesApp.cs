using Portfolio.Core.ServicesInterface;
using Portfolio.Infrastructure.ServicesImpl;

namespace Portfolio.API.Extensions
{
    public static class AddServicesApp
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IApiInfoService, ApiInfoService>();

            return services;
        }
    }
}
