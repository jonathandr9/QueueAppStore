using ConsumerAppStore.Application.Interfaces;
using ConsumerAppStore.Application.Models;
using ConsumerAppStore.Application.Utils;
using Microsoft.Extensions.Logging;

namespace ConsumerAppStore.Application.Subscribers
{
    public class ValidPayment : IObserver<Payment>
    {
        private IDisposable unsubscriber;
        private string instName;
        private readonly ILogger<ValidPayment> _logger;
        private readonly IOrderRepository _orderRepository;

        public ValidPayment(ILogger<ValidPayment> logger,
            IOrderRepository orderRepository)
        {
            _logger = logger;
            _orderRepository = orderRepository;
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
            _logger.LogInformation("The Location Tracker has completed transmitting data to {0}.", this.Name);
            this.Unsubscribe();
        }

        public virtual void OnError(Exception e)
        {
            _logger.LogInformation("{0}: The location cannot be determined.", this.Name);
        }

        public virtual void OnNext(Payment value)
        {
            _logger.LogInformation("Iniciando processamento para validar e salvar cartão");

            try
            {
                var card = value.Card;

                var isValid = ValidCard.IsCreditCardInfoValid(
                    card.Number.ToString(),
                    card.ValidThru.ToString("MM/yyyy"),
                    card.CVC.ToString());

                if (isValid)
                    _orderRepository.UpdateStatus(EnumOrderStatus.Approved, value.OrderId);
                else
                    _orderRepository.UpdateStatus(EnumOrderStatus.Disapproved, value.OrderId);

            }
            catch (Exception ex)
            {
                _logger.LogError("Erro ao processar validação e salvamento do cartão");

                throw;
            }
            finally
            {
                this.Unsubscribe();
            }
        }

        public virtual void Unsubscribe()
        {
            if (unsubscriber != null)
                unsubscriber.Dispose();
        }
    }
}
