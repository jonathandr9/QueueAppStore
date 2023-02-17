using ConsumerAppStore.Application.Models;

namespace ConsumerAppStore.Application.Interfaces
{
    public interface IOrderRepository
    {
        void UpdateStatus(EnumOrderStatus enumOrderStatus);
    }
}
