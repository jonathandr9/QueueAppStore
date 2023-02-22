using QueueAppStore.Domain.Models;

namespace QueueAppStore.Domain.Services
{
    public interface IOrderService
    {
        Task<int> AddNew(Order order);
        Task<Order> GetOrder(int idOrder);
    }
}
