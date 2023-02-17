using ConsumerAppStore.Application.Interfaces;
using ConsumerAppStore.Application.Models;
using ConsumerAppStore.Repository.Configuration;
using Dapper;
using System.Data;
using System.Transactions;

namespace ConsumerAppStore.Repository
{
    public class CardRepository : ICardRepository
    {
        private readonly SqlContext _context;

        static CardRepository() =>
            SqlMapper.AddTypeMap(typeof(string),
            DbType.AnsiString);

        public CardRepository(SqlContext context) =>
            _context = context ??
                throw new ArgumentNullException(nameof(context));

        public void Add(Card card)
        {
            using (var trxScope = new TransactionScope())
            {
                try
                {
                    var id = _context.Connection.QuerySingle<int>(
                     @"INSERT INTO [Card] 
                            (Number,
                             NameIn,
                             ValidThru,
                             CVC) 
                          OUTPUT INSERTED.Id
                          VALUES 
                             (@Number, 
                              @Name,
                              @ValidThru,
                              @CVC)",
                     card,
                     commandType: CommandType.Text);

                    trxScope.Complete();
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException(
                        $"Erro ao incluir: '{ex.Message}'");
                }
            };

        }
    }
}
