namespace DotNet8.Architectures.Presentation.Extensions;

public static class DependecyInjection
{

    #region AddDependencyInjection

    public static IServiceCollection AddDependencyInjection(this IServiceCollection services, WebApplicationBuilder builder)
    {
        return services
            .AddDbContextService(builder)
            .AddDataAccessService()
            .AddBusinessLogicService()
            .AddValidorService();
    }

    #endregion

    #region AddDbContextService

    private static IServiceCollection AddDbContextService(this IServiceCollection services, WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<AppDbContext>(opt =>
        {
            opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
        },
        ServiceLifetime.Transient
        );

        return services;
    }

    #endregion

    private static IServiceCollection AddDataAccessService(this IServiceCollection services)
    {
        return services.AddScoped<DA_Blog>();
    }

    private static IServiceCollection AddBusinessLogicService(this IServiceCollection services)
    {
        return services.AddScoped<BL_Blog>();
    }

    private static IServiceCollection AddValidorService(this IServiceCollection services)
    {
        return services.AddScoped<BlogValidator>();
    }
}
