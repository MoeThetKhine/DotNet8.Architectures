using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.Architectures.ModularMonolithic.Modules.Application.Extensions
{
	public static class Extension
	{

		public static IServiceCollection AddMediatRService(this IServiceCollection services)
		{
			return services.AddMediatR(cf =>
		   cf.RegisterServicesFromAssembly(typeof(Extension).Assembly)
	   );
		}
		
	}
}
