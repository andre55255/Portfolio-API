﻿using Portfolio.Core.ServicesInterface;
using Portfolio.Infrastructure.ServicesImpl;

namespace Portfolio.API.Extensions
{
    public static class AddServicesApp
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IApiInfoService, ApiInfoService>();
            services.AddScoped<IConfigurationService, ConfigurationService>();
            services.AddScoped<ISendMailService, SendMailService>();
            services.AddScoped<ILogService, LogService>();

            return services;
        }
    }
}
