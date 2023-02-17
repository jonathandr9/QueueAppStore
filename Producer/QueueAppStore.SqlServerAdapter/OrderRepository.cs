using Dapper;
using QueueAppStore.Domain.Adapters;
using QueueAppStore.Domain.Models;
using QueueAppStore.SqlAdapter.Configuration;
using System.Data;

namespace QueueAppStore.SqlAdapter
{
    public class OrderRepository : IOrderRepository
    {
        private readonly SqlAdapterContext _context;

        static OrderRepository() =>
            SqlMapper.AddTypeMap(typeof(string),
            DbType.AnsiString);

        public OrderRepository(SqlAdapterContext context) =>
            _context = context ??
                throw new ArgumentNullException(nameof(context));

        public async Task<int> AddOrder(Order order)
        {
            var id = await _context.Connection.QuerySingleAsync<int>(
                    @"INSERT INTO [OrderSale] 
                            (IdClient,
                             IdApp,
                             Amounts,
                             LastCardDigits,
                             PaymentStatus,
                             Value) 
                          OUTPUT INSERTED.Id
                          VALUES 
                             (@IdClient, 
                              @IdApp,
                              @Amounts,
                              @LastCardDigits,
                              @PaymentStatus,
                              @Value)",
                    order,
                    commandType: CommandType.Text);


            return id;
        }
    }
}
