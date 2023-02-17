using ConsumerAppStore.Application.Interfaces;
using ConsumerAppStore.Application.Models;
using ConsumerAppStore.Repository.Configuration;
using Dapper;
using System.Data;
using System.Transactions;

namespace ConsumerAppStore.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly SqlContext _context;

        static OrderRepository() =>
           SqlMapper.AddTypeMap(typeof(string),
           DbType.AnsiString);

        public OrderRepository(SqlContext context) =>
            _context = context ??
                throw new ArgumentNullException(nameof(context));

        public void UpdateStatus(
            EnumOrderStatus enumOrderStatus,
            int orderId)
        {
            using (var trxScope = new TransactionScope())
            {
                try
                {
                    _context.Connection.QuerySingle<int>(
                        @"UPDATE OrderSale
                            set PaymentStatus = @status
                         WHERE Id = @id",
                        new
                        {
                            id = orderId,
                            status = (int)enumOrderStatus
                        },
                        commandType: CommandType.Text);
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException(
                        $"Erro ao atualizar pedido: '{ex.Message}'");
                }
            };
        }

    }
}
