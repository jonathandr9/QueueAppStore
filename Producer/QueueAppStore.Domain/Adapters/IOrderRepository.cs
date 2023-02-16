using QueueAppStore.Domain.Models;

namespace QueueAppStore.Domain.Adapters
{
    public interface IOrderRepository
    {
        Task<int> AddOrder(Order order);
    }
}
