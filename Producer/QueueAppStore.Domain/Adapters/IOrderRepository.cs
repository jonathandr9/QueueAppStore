using QueueAppStore.Domain.Models;
using System.Transactions;

namespace QueueAppStore.Domain.Adapters
{
    public interface IOrderRepository
    {
        Task<int> AddOrder(Order order);
        Task<Order> GetOrder(int idOrder);
    }
}
