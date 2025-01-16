using DotNet8.Architectures.Clean.Infrastructure.Features.Blog;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DotNet8.Architectures.Clean.Presentation.Extensions;

public static class DependencyInjection
{
    #region AddDependencyInjection

    public static IServiceCollection AddDependencyInjection(this IServiceCollection services, WebApplicationBuilder builder)
    {
        services.AddDbContextService(builder)
                .AddRepositoryService();

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetBlogListQueryHandler).Assembly));

        return services;
    }

    #endregion

    #region AddDbContextService

    private static IServiceCollection AddDbContextService(this IServiceCollection services, WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<BlogDbContext>(
        opt =>
        {
            opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")!);
            opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        },
        ServiceLifetime.Transient);

        return services;
    }

    #endregion

    #region AddRepositoryService

    private static IServiceCollection AddRepositoryService(this IServiceCollection services)
    {
        return services.AddScoped<IBlogRepository, BlogRepository>();
    }

    #endregion
}
