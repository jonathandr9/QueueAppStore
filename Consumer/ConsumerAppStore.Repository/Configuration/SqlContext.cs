using System.Data;
using System.Data.SqlClient;

namespace ConsumerAppStore.Repository.Configuration
{
    public class SqlContext
    {
        private readonly string connectionString;
        public SqlContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        private IDbConnection dbConnection;

        public IDbConnection Connection
        {
            get
            {
                if (dbConnection == null)
                    dbConnection = new SqlConnection(connectionString);

                return dbConnection;
            }
        }
    }
}
