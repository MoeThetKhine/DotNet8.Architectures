using DotNet8.Architectures.DbServices.Models;
using DotNet8.Architectures.Hexgonal.Domain.Features.Blog;
using DotNet8.Architectures.Hexgonal.Infracture.Features.Blog;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace DotNet8.Architectures.Hexgonal.Api.Extensions
{
	public static class DependencyInjection
	{
		

		private static IServiceCollection AddDbContextService(this IServiceCollection services, WebApplicationBuilder builder)
		{
			builder.Services.AddDbContext<AppDbContext>(
				opt =>
				{
					opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnetion"));
					opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
				},
				ServiceLifetime.Transient,
				ServiceLifetime.Transient

			);

			return services;
		}

		private static IServiceCollection AddRepositoryService(this IServiceCollection services)
		{
			return services.AddScoped<IBlogPort, BlogAdapter>();
		}
		public static IServiceCollection AddDependencyInjection(this IServiceCollection services, WebApplicationBuilder builder)
		{
			return services.AddDbContextService(builder).AddRepositoryService();
		}
	}
}
