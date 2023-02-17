using ConsumerAppStore.Application.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace ConsumerAppStore
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly PaymentQueueObserver _paymentQueueObserver;

        public Worker(ILogger<Worker> logger,
            PaymentQueueObserver paymentQueueObserver)
        {
            _logger = logger;
            _paymentQueueObserver = paymentQueueObserver;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            while (!stoppingToken.IsCancellationRequested)
            {
                var factory = new ConnectionFactory() { HostName = "localhost" };
                var connection = factory.CreateConnection();
                var channel = connection.CreateModel();

                channel.QueueDeclare(queue: "payment",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    try
                    {
                        var body = ea.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);
                        var payment = JsonSerializer.Deserialize<Payment>(message);

                        _paymentQueueObserver.PaymentProcess(payment);

                        channel.BasicAck(ea.DeliveryTag, false);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogWarning($"Erro ao ler mensagem {ex}");

                        channel.BasicNack(ea.DeliveryTag, false, true);                        
                    }
                };

                channel.BasicConsume(queue: "payment",
                                     autoAck: false,
                                     consumer: consumer);

                _logger.LogInformation("Worker em execução: {time}", DateTimeOffset.Now);
                await Task.Delay(10000, stoppingToken);
            }

            _paymentQueueObserver.EndTransmission();
        }
    }
}