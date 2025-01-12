using DotNet8.Architectures.BusinessLogic.Features.Blog;
using DotNet8.Architectures.DataAccess.Features.Blog;
using DotNet8.Architectures.DbServices.Models;
using DotNet8.Architectures.Shared;
using Microsoft.EntityFrameworkCore;

namespace DotNet8.Architectures.Presentation.Extensions
{
    public static class DependecyInjection
    {
       
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

        private static IServiceCollection AddDataAccessService(this IServiceCollection services)
        {
            return services.AddScoped<DA_Blog>();
        }

        private static IServiceCollection AddBusinessLogicService(this IServiceCollection services)
        {
            return services.AddScoped<BL_Blog>();
        }
    }
}
