namespace DotNet8.Architectures.Microservices.Blog.Extensions;

public static class DependencyInjection
{

	#region AddDependencyInjection

	public static IServiceCollection AddDependencyInjection(this IServiceCollection services , WebApplicationBuilder builder)
	{
		return services
			.AddDbContextService(builder)
			.AddDataAccessService()
			.AddBusinessLogicService();
	}

	#endregion

	#region AddDbContextService

	private static IServiceCollection AddDbContextService(this IServiceCollection services, WebApplicationBuilder builder)
	{
		builder.Services.AddDbContext<AppDbContext>(
			opt =>
			{
				opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
				opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
			},
			ServiceLifetime.Transient,
			ServiceLifetime.Transient
			);
		return services;
	}

	#endregion

	#region AddDataAccessService

	private static IServiceCollection AddDataAccessService(this  IServiceCollection services)
	{
		return services.AddScoped<DA_Blog>();
	}

	#endregion

	#region AddBusinessLogicService

	private static IServiceCollection AddBusinessLogicService(this IServiceCollection services)
	{
		return services.AddScoped<BL_Blog>();
	}

	#endregion
}
