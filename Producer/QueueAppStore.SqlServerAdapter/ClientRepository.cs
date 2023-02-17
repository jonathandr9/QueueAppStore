using Dapper;
using QueueAppStore.Domain.Adapters;
using QueueAppStore.Domain.Models;
using QueueAppStore.SqlAdapter.Configuration;
using System.Data;

namespace QueueAppStore.SqlServerAdapter
{
    public class ClientRepository : IClientRepository
    {
        private readonly SqlAdapterContext _context;

        static ClientRepository() =>
            SqlMapper.AddTypeMap(typeof(string), DbType.AnsiString);

        public ClientRepository(SqlAdapterContext context) =>
            _context = context ??
                throw new ArgumentNullException(nameof(context));

        public async Task<int> Add(Client client)
        {
            var id = await _context.Connection.QuerySingleAsync<int>(
                    @"INSERT INTO [Client] 
                            (Name,
                             Cpf,
                             Sex,
                             Address,
                             DateOfBirth,
                             IdentityId) 
                          OUTPUT INSERTED.Id
                          VALUES 
                             (@Name,
                              @Cpf,
                              @Sex,
                              @Address,
                              @DateOfBirth,
                              @IdentityId)",
                    client,
                    commandType: CommandType.Text);

            return id;
        }

        public async Task<Client> GetClient()
        {
            return await _context.Connection.QueryFirstOrDefaultAsync<Client>(
                        @"SELECT IdCarPhoto,
                                 FipeCode, 
                                 PhotoBase64,
                                 ModelYear
                          FROM CarPhoto WITH (NOLOCK)
                          WHERE FipeCode = @FipeCode
                          AND ModelYear = @ModelYear",
                        //param: new { FipeCode = fipeCode, ModelYear = year },
                        commandType: CommandType.Text);
        }
    }
}
