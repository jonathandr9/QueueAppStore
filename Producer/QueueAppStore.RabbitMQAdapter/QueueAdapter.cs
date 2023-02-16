using Newtonsoft.Json;
using QueueAppStore.Domain.Adapters;
using QueueAppStore.Domain.Models;
using QueueAppStore.RabbitMQAdapter.Configuration;
using RabbitMQ.Client;
using System.Text;

namespace QueueAppStore.RabbitMQAdapter
{
    public sealed class QueueAdapter : IQueueAdapter
    {
        private readonly IConnectionFactory _connectionFactory;
        private readonly RabbitMQAdapterConfiguration _configuration;
        public QueueAdapter(IConnectionFactory connectionFactory,
            RabbitMQAdapterConfiguration configuration)
        {
            _connectionFactory = connectionFactory;
            _configuration = configuration;
        }

        public async Task AddPaymentMessage(Payment payment)
        {
            try
            {
                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(payment));

                using var connection = _connectionFactory.CreateConnection();
                using (IModel channel = connection.CreateModel())
                {
                    channel.BasicPublish(exchange: string.Empty,
                                     routingKey: _configuration.QueuePaymentName,
                                     basicProperties: null,
                                     body: body);

                };
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
