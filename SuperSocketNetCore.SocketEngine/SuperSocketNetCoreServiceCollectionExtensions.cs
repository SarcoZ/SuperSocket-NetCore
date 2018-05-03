using System;

#if NETSTANDARD2_0
using Microsoft.Extensions.Configuration;
#endif

namespace Microsoft.Extensions.DependencyInjection
{
    public static class SuperSocketNetCoreServiceCollectionExtensions
    {
        public static IServiceCollection AddSuperSocketNet(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }
#if !NETSTANDARD2_0
#else
            services.AddTransient<IConfigurationBuilder, ConfigurationBuilder>();
#endif
            return services;
        }
    }
}