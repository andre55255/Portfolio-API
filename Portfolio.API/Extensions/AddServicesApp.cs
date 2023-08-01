using Portfolio.Core.ServicesInterface;
using Portfolio.Infrastructure.ServicesImpl;

namespace Portfolio.API.Extensions
{
    public static class AddServicesApp
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IApiInfoService, ApiInfoService>();
            services.AddScoped<IConfigurationService, ConfigurationService>();
            services.AddScoped<IExperienceWorkService, ExperienceWorkService>();
            services.AddScoped<IGenericTypeService, GenericTypeService>();
            services.AddScoped<ISendMailService, SendMailService>();
            services.AddScoped<ILogService, LogService>();
            services.AddScoped<IPortfolioConfigService, PortfolioConfigService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
