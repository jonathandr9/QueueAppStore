namespace QueueAppStore.Domain.Adapters
{
    public interface IQueueAdapter
    {
        Task AddPaymentMessage();
    }
}
