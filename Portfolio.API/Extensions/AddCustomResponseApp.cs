using Microsoft.AspNetCore.Mvc;
using Portfolio.Communication.ViewObjects.Utlis;

namespace Portfolio.API.Extensions
{
    public static class AddCustomResponseApp
    {
        public static IMvcBuilder AddCustomResponse(this IMvcBuilder builder)
        {
            builder.ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    APIResponseVO response = new APIResponseVO
                    {
                        Success = false,
                    };
                    foreach (var (key, value) in context.ModelState)
                    {
                        response.Message = value.Errors.Select(x => x.ErrorMessage).FirstOrDefault();
                    }
                    return new BadRequestObjectResult(response);
                };
            });
            return builder;
        }
    }
}