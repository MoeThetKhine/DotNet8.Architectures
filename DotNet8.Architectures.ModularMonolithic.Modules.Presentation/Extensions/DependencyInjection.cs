using DotNet8.Architectures.Clean.Domain.Features.Blog;
using DotNet8.Architectures.Clean.Infrastructure.Features.Blog;
using DotNet8.Architectures.DbServices.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNet8.Architectures.ModularMonolithic.Modules.Presentation.Extensions
{
	public static class DependencyInjection
	{
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

		private static IServiceCollection AddRepositoryService(this IServiceCollection services)
		{
			return services.AddScoped<IBlogRepository, BlogRepository>();
		}

		public static IServiceCollection AddDependencyInjection(this IServiceCollection services, WebApplicationBuilder builder)
		{
			return services.AddDbContextService(builder)
				.AddRepositoryService();
		}
	}
}
