using ConsumerAppStore;
using ConsumerAppStore.Application.Subscribers;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddSingleton<SaveCard>();
        services.AddSingleton<ValidPayment>();
        services.AddSingleton<PaymentQueueObserver>();
    })
    .Build();

await host.RunAsync();
