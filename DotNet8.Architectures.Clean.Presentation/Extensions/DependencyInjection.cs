using DotNet8.Architectures.Clean.Domain.Features.Blog;
using DotNet8.Architectures.Clean.Infrastructure.Features.Blog;
using Microsoft.EntityFrameworkCore;

namespace DotNet8.Architectures.Clean.Presentation.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(
       this IServiceCollection services,
       WebApplicationBuilder builder
        )
        {
            return services.AddDbContextService(builder).AddRepositoryService();
        }

      
        private static IServiceCollection AddRepositoryService(this IServiceCollection services)
        {
            return services.AddScoped<IBlogRepository, BlogRepository>();
        }

    }
}
