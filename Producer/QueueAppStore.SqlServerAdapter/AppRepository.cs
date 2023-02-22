using Dapper;
using QueueAppStore.Domain.Adapters;
using QueueAppStore.Domain.Models;
using QueueAppStore.SqlAdapter.Configuration;
using System.Data;

namespace QueueAppStore.SqlAdapter
{
    public class AppRepository : IAppRepository
    {
        private readonly SqlAdapterContext _context;

        static AppRepository() =>
            SqlMapper.AddTypeMap(typeof(string), DbType.AnsiString);

        public AppRepository(SqlAdapterContext context) =>
            _context = context ??
                throw new ArgumentNullException(nameof(context));

        public async Task<IEnumerable<App>> GetAll()
        {
            return await _context.Connection.QueryAsync<App>(
                        @"SELECT Id,
                                 Name, 
                                 Category,
                                 Price
                          FROM Apps WITH (NOLOCK)",
                        commandType: CommandType.Text);
        }

        public async Task<App> GetApp(int appId)
        {
            return await _context.Connection.QueryFirstAsync<App>(
                        @"SELECT Id,
                                 Name, 
                                 Category,
                                 Price
                          FROM Apps WITH (NOLOCK)
                          WHERE ID = @appId",
                        new { appId },
                        commandType: CommandType.Text);
        }

    }
}
