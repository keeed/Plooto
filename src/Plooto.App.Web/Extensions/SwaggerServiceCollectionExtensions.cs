using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Plooto.App.Web.Extensions
{
    public static class SwaggerServiceCollectionExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(
                    configuration["ApiVersionInfo:Version"],
                    new OpenApiInfo
                    {
                        Title = configuration["ApiVersionInfo:Name"],
                        Version = configuration["ApiVersionInfo:Version"]
                    });
            });

            return services;
        }
    }
}