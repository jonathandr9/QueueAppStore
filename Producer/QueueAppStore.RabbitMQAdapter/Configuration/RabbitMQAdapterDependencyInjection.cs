using QueueAppStore.Domain.Adapters;
using QueueAppStore.RabbitMQAdapter;
using QueueAppStore.RabbitMQAdapter.Configuration;
using RabbitMQ.Client;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class RabbitMQAdapterDependencyInjection
    {
        public static IServiceCollection AddRabbitMQAdapter(
            this IServiceCollection services,
            RabbitMQAdapterConfiguration configuration)
        {
            var factory = new ConnectionFactory { HostName = configuration.HostName };
            using var connection = factory.CreateConnection();
            using (IModel channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: configuration.QueuePaymentName,
                                durable: false,
                                exclusive: false,
                                autoDelete: false,
                                arguments: null);

            };

            services.AddSingleton<RabbitMQAdapterConfiguration>(configuration);
            services.AddSingleton<IConnectionFactory>(factory);
            services.AddScoped<IQueueAdapter, QueueAdapter>();

            return services;
        }
    }
}
