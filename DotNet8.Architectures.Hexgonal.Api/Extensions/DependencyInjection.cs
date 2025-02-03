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

	}
}
