using Microsoft.Extensions.DependencyInjection;

namespace Plooto.Core.Extensions
{
    public static class CoreServiceCollectionExtensions 
    {
        public static IServiceCollection AddDefaultCoreServices(this IServiceCollection services)
        {
            services.AddTransient<ITodoService, DefaultTodoService>();

            return services;
        }
    }
}