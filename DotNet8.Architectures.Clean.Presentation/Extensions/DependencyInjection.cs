using DotNet8.Architectures.Clean.Domain.Features.Blog;
using DotNet8.Architectures.Clean.Infrastructure.Features.Blog;

namespace DotNet8.Architectures.Clean.Presentation.Extensions
{
    public static class DependencyInjection
    {
        private static IServiceCollection AddRepositoryService(this IServiceCollection services)
        {
            return services.AddScoped<IBlogRepository, BlogRepository>();
        }
    }
}
