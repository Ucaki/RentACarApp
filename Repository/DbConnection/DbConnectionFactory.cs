using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DbConnection
{
    public class DbConnectionFactory
    {
        private static DbConnectionFactory _instance;
        private readonly DbConnection _connection;
        public static DbConnectionFactory Instance {
            get { if (_instance == null) _instance = new DbConnectionFactory(); return _instance; }
                }
        private DbConnectionFactory() {
            _connection = new DbConnection();
        }
        public DbConnection GetDbConnection() {
            if (!_connection.IsReady()) { _connection.OpenConnection(); }
            return _connection;
        }
    }
}
