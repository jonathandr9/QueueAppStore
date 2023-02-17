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

            services.AddScoped<
                ICardRepository,
                CardRepository>();

            services.AddScoped<
                IOrderRepository,
                OrderRepository>();

            services.AddScoped
                (d => new SqlContext
                (configuration.SqlConnectionString));

            services.AddScoped
                (d => new SqlContext
                (configuration.SqlConnectionString));

            return services;
        }
    }
}
