using DotNet8.Architectures.DbServices.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNet8.Architectures.Microservices.Blog.Extensions
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddDependencyInjection(this IServiceCollection services , WebApplicationBuilder builder)
		{
			return services

		} 

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
	}
}
