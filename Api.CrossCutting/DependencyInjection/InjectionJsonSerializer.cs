using System;
using System.Text.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
	public static class InjectionJsonSerializer
	{
		public static void ConfigureDependencyJsonSerializer(IServiceCollection service)
		{
			service.AddControllers()
					.AddJsonOptions(options =>
						options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter())
					).AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling =
						Newtonsoft.Json.ReferenceLoopHandling.Ignore
					);
		}
	}
}

// configure Dependency cyclicle, document inside document