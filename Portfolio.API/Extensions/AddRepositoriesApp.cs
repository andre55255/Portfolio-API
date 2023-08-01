using Portfolio.Core.RepositoriesInterface.Sql;
using Portfolio.Infrastructure.RepositoriesImpl.Sql;

namespace Portfolio.API.Extensions
{
    public static class AddRepositoriesApp
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IConfigurationRepository, ConfigurationRepository>();
            services.AddScoped<IExperienceEducationRepository, ExperienceEducationRepository>();
            services.AddScoped<IExperienceWorkRepository, ExperienceWorkRepository>();
            services.AddScoped<IGenericTypeRepository, GenericTypeRepository>();
            services.AddScoped<IPortfolioConfigRepository, PortfolioConfigRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
