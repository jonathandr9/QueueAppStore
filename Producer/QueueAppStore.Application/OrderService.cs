using QueueAppStore.Domain.Adapters;
using QueueAppStore.Domain.Enums;
using QueueAppStore.Domain.Models;
using QueueAppStore.Domain.Services;
using System.Transactions;

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
            using (var trxScope = new TransactionScope(
                TransactionScopeAsyncFlowOption.Enabled))
            {
                try
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

                    trxScope.Complete();

                    return idOfOrder;
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException(
                        $"Erro ao inserir Pedido: '{ex.Message}'");
                }
            };
        }

    }
}
