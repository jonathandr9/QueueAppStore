using ConsumerAppStore;
using ConsumerAppStore.Application.Subscribers;
using ConsumerAppStore.Repository.Configuration;
using Microsoft.Extensions.DependencyInjection;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddHostedService<Worker>();

        services.AddSqlAdapter(
            hostContext.Configuration.GetSection("SqlConfiguration")
            .Get<RepositoryConfiguration>());

        services.AddSingleton<SaveCard>();
        services.AddSingleton<ValidPayment>();
        services.AddSingleton<PaymentQueueObserver>();

    })
    .Build();

await host.RunAsync();
