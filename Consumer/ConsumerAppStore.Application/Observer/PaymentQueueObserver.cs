using ConsumerAppStore.Application.Models;
using ConsumerAppStore.Application.Subscribers;

namespace ConsumerAppStore
{
    public class PaymentQueueObserver : IObservable<Payment>
    {
        public PaymentQueueObserver(
            SaveCard saveCard,
            ValidPayment validPayment)
        {
            observers = new List<IObserver<Payment>>();
            Subscribe(saveCard);
            Subscribe(validPayment);
        }

        private List<IObserver<Payment>> observers;

        public IDisposable Subscribe(IObserver<Payment> observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);
            return new Unsubscriber(observers, observer);
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<Payment>> _observers;
            private IObserver<Payment> _observer;

            public Unsubscriber(List<IObserver<Payment>> observers, IObserver<Payment> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }

            public void Dispose()
            {
                if (_observer != null && _observers.Contains(_observer))
                    _observers.Remove(_observer);
            }
        }

        public void PaymentProcess(Payment pay)
        {
            foreach (var observer in observers)
            {
                observer.OnNext(pay);
            }
        }

        public void EndTransmission()
        {
            foreach (var observer in observers.ToArray())
                if (observers.Contains(observer))
                    observer.OnCompleted();

            observers.Clear();
        }
    }
}
