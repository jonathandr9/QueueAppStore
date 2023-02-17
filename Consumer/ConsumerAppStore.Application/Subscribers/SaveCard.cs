using ConsumerAppStore.Application.Models;
using Microsoft.Extensions.Logging;

namespace ConsumerAppStore.Application.Subscribers
{
    public class SaveCard : IObserver<Payment>
    {
        private IDisposable unsubscriber;
        private string instName;
        private readonly ILogger<SaveCard> _logger;
        public SaveCard(ILogger<SaveCard> logger)
        {
            _logger = logger;
        }

        public string Name
        { get { return this.instName; } }

        public virtual void Subscribe(IObservable<Payment> provider)
        {
            if (provider != null)
                unsubscriber = provider.Subscribe(this);
        }

        public virtual void OnCompleted()
        {
            //_logger.LogInformation("The Location Tracker has completed transmitting data to {0}.", this.Name);
            this.Unsubscribe();
        }

        public virtual void OnError(Exception e)
        {
            _logger.LogInformation(e.ToString());
            //_logger.LogInformation("{0}: The location cannot be determined.", this.Name);
        }

        public virtual void OnNext(Payment value)
        {
            _logger.LogInformation("Salvando cartão");
            //_logger.LogInformation("{2}: The current location is {0}, {1}", value.Latitude, value.Longitude, this.Name);
        }

        public virtual void Unsubscribe()
        {
            unsubscriber.Dispose();
        }
    }
}
