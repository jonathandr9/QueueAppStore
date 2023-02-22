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
        private readonly IAppRepository _appRepository;

        public OrderService(IQueueAdapter queueAdapter,
            IOrderRepository orderRepository,
            IAppRepository appRepository)
        {
            _queueAdapter = queueAdapter;
            _orderRepository = orderRepository;
            _appRepository = appRepository;
        }

        public async Task<int> AddNew(Order order)
        {
            using (var trxScope = new TransactionScope(
                TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    var app = await _appRepository.GetApp(order.IdApp);

                    order.PaymentStatus = (int)PaymentStatusEnum.Pending;
                    order.Value = app.Price;

                    var idOfOrder = await _orderRepository.AddOrder(order);

                    var payment = new Payment()
                    {
                        OrderId = idOfOrder,
                        Card = order.Card,
                        Amounts = order.Amounts,
                        Value = app.Price
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
