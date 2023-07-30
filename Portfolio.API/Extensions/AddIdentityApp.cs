using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Portfolio.Core.Entities.Identity;
using Portfolio.Helpers;
using Portfolio.Infrastructure.Data.Sql.Context;

namespace Portfolio.API.Extensions
{
    public static class AddIdentityApp
    {
        public static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            services.AddIdentity<AspNetUser, AspNetRole>(opt =>
                       opt.SignIn.RequireConfirmedEmail = true
                   )
                   .AddEntityFrameworkStores<SqlDbContext>()
                   .AddDefaultTokenProviders()
                   .AddTokenProvider(ConfigJwt.LoginProviderWeb,
                                     typeof(DataProtectorTokenProvider<AspNetUser>));

            // Config accepts passwords
            services.Configure<IdentityOptions>(opt =>
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = false;
            });

            return services;
        }
    }
}
