using QueueAppStore.Domain.Adapters;
using QueueAppStore.Domain.Services;

namespace QueueAppStore.Application
{
    public sealed class PaymentService : IPaymentService
    {
        private readonly IQueueAdapter _queueAdapter;
        public PaymentService(IQueueAdapter queueAdapter)
        {
            _queueAdapter = queueAdapter;
        }

        public async Task PaymentWithCard()
        {
            await _queueAdapter.AddPaymentMessage();
        }
    }
}
