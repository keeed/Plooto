using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Plooto.Core.Repositories;

namespace Plooto.Repositories.EFCore.Extensions
{
    public static class RepositoryServiceCollectionExtensions
    {
        public static IServiceCollection AddInMemoryDatabase(this IServiceCollection services)
        {
            services.AddDbContext<TodoDbContext>(options => {
                options.UseInMemoryDatabase("Todo");
            });

            services.AddTransient<ITodoCommandRepository, InMemoryTodoCommandRepository>();
            services.AddTransient<ITodoQueryRepository, InMemoryTodoQueryRepository>();

            return services;
        }
    }
}