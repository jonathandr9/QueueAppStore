using ConsumerAppStore.Application.Interfaces;
using ConsumerAppStore.Repository;
using ConsumerAppStore.Repository.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class RepositoryDependencyInjection
    {
        public static IServiceCollection AddSqlAdapter
        (this IServiceCollection services,
        RepositoryConfiguration configuration)
        {
            if (services == null)
                throw new ArgumentNullException(
                    nameof(services));

            if (String.IsNullOrEmpty(configuration.SqlConnectionString))
                throw new ArgumentNullException(
                    nameof(configuration.SqlConnectionString));

            services.AddSingleton<
                ICardRepository,
                CardRepository>();

            services.AddSingleton<
                IOrderRepository,
                OrderRepository>();

            services.AddSingleton
                (d => new SqlContext
                (configuration.SqlConnectionString));

            services.AddSingleton
                (d => new SqlContext
                (configuration.SqlConnectionString));

            return services;
        }
    }
}
