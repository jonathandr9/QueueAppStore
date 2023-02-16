using QueueAppStore.Domain.Adapters;
using QueueAppStore.Domain.Models;
using RabbitMQ.Client;
using System.Text;

namespace QueueAppStore.RabbitMQAdapter
{
    public sealed class QueueAdapter : IQueueAdapter
    {
        public QueueAdapter()
        {

        }

        public async Task AddPaymentMessage(Payment payment)
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "hello",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            const string message = "Hello World!";

            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: string.Empty,
                                 routingKey: "hello",
                                 basicProperties: null,
                                 body: body);

        }
    }
}
