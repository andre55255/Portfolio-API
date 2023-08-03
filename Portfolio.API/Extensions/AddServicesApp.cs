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
            services.AddScoped<IContactMeService, ContactMeService>();
            services.AddScoped<IExperienceEducationService, ExperienceEducationService>();
            services.AddScoped<IExperienceWorkService, ExperienceWorkService>();
            services.AddScoped<IGenericTypeService, GenericTypeService>();
            services.AddScoped<IHandleFileService, HandleFileService>();
            services.AddScoped<ISendMailService, SendMailService>();
            services.AddScoped<ILogService, LogService>();
            services.AddScoped<IPortfolioConfigService, PortfolioConfigService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IPublicPageService, PublicPageService>();
            services.AddScoped<IStackService, StackService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
