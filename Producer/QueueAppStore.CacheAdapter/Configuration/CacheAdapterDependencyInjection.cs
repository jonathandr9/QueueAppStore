
using QueueAppStore.CacheAdapter;
using QueueAppStore.CacheAdapter.Configuration;
using QueueAppStore.Domain.Adapters;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class CacheAdapterDependencyInjection
    {
        public static IServiceCollection AddCacheAdapter
         (this IServiceCollection services,
         CacheAdapterConfiguration configuration)
        {
            if (services == null)
                throw new ArgumentNullException(
                    nameof(services));

            if (configuration == null)
                throw new ArgumentNullException(
                    nameof(configuration));

            services.AddScoped<
                ICachingAdapter,
                CachingAdapter>();

            services.AddSingleton(configuration);

            services.AddStackExchangeRedisCache(o =>
            {
                o.InstanceName = configuration.InstanceName;
                o.Configuration = configuration.Configuration;
            });

            return services;
        }
    }
}
