using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sample.Common.Settings;

namespace Sample.Middleware
{
    internal static class ServiceCollectionExtensions
    {
        internal static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            // services.AddTransient<IEngine, Engine>();

            return services;
        }

        internal static IServiceCollection RegisterConfigs(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<SampleSettings>(config.GetSection(typeof(SampleSettings).Name));

            return services;
        }
    }
}
