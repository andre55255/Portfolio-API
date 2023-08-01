using Portfolio.Core.ServicesInterface;
using Portfolio.HandleFiles.Services.Impl;
using Portfolio.HandleFiles.Services.Interfaces;
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
            services.AddScoped<IFileUniqueService, FileUniqueService>();
            services.AddScoped<IFileManyService, FileManyService>();
            services.AddScoped<ISendMailService, SendMailService>();
            services.AddScoped<ILogService, LogService>();
            services.AddScoped<IPortfolioConfigService, PortfolioConfigService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IPublicPageService, PublicPageService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
