using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Connection
{
    public class SqlConnectionFactory : IConnectionFactory
    {
        private readonly string connectionString;
        public SqlConnectionFactory(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public IDbConnection CreateConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
