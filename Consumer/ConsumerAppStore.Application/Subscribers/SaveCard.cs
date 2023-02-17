using ConsumerAppStore.Application.Interfaces;
using ConsumerAppStore.Application.Models;
using ConsumerAppStore.Application.Utils;
using Microsoft.Extensions.Logging;

namespace ConsumerAppStore.Application.Subscribers
{
    public class SaveCard : IObserver<Payment>
    {
        private IDisposable unsubscriber;
        private string instName;
        private readonly ILogger<SaveCard> _logger;
        private readonly ICardRepository _cardRepository;

        public SaveCard(ILogger<SaveCard> logger,
            ICardRepository cardRepository)
        {
            _logger = logger;
            _cardRepository = cardRepository;
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

            _logger.LogInformation("Fim processamento para validar e salvar cartão");
        }

        public virtual void OnError(Exception e)
        {
            _logger.LogInformation(e.ToString());
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
                    _cardRepository.Add(card);
                else
                    _logger.LogWarning("Cartão Inválido");

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
            unsubscriber.Dispose();
        }
    }
}
