using QueueAppStore.Domain.Adapters;
using QueueAppStore.Domain.Enums;
using QueueAppStore.Domain.Models;
using QueueAppStore.Domain.Services;

namespace QueueAppStore.Application
{
    public sealed class OrderService : IOrderService
    {
        private readonly IQueueAdapter _queueAdapter;
        private readonly IOrderRepository _orderRepository;

        public OrderService(IQueueAdapter queueAdapter,
            IOrderRepository orderRepository)
        {
            _queueAdapter = queueAdapter;
            _orderRepository = orderRepository;
        }

        public async Task<int> AddNew(Order order)
        {
            order.PaymentStatus = (int)PaymentStatusEnum.Pending;

            var idOfOrder = await _orderRepository.AddOrder(order);

            var payment = new Payment()
            {
                OrderId = idOfOrder,
                Card = order.Card,
                Amounts = order.Amounts,
                Value = order.Value
            };

            await _queueAdapter.AddPaymentMessage(payment);

            return idOfOrder;
        }
    }
}
