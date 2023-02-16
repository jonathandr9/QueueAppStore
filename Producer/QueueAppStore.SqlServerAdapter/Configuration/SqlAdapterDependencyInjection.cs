using QueueAppStore.Domain.Adapters;
using QueueAppStore.SqlAdapter.Configuration;
using QueueAppStore.SqlServerAdapter;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class SqlAdapterDependencyInjection
    {
        public static IServiceCollection AddSqlAdapter
          (this IServiceCollection services,
          SqlAdapterConfiguration configuration)
        {
            if (services == null)
                throw new ArgumentNullException(
                    nameof(services));

            if (configuration == null)
                throw new ArgumentNullException(
                    nameof(configuration));

            services.AddScoped<
                IClientRepository,
                ClientRepository>();

            services.AddSingleton(configuration);

            services.AddScoped
                (d => new SqlAdapterContext
                (configuration.SqlConnectionString));

            return services;
        }
    }
}
