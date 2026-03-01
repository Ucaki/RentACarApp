using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DbConnection
{
    public class DbConnection
    {
        private readonly SqlConnection _connection;
        private SqlTransaction _transaction;
        public DbConnection() {
            _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RentACar"].ConnectionString);
        }
        public void OpenConnection() {
            _connection?.Open();
        }
        public void CloseConnection() {
            if (_connection.State != ConnectionState.Closed) _connection?.Close();
        }
        public void BeginTransaction() {
            _transaction = _connection.BeginTransaction();
        }
        public void Commit() {
            _transaction.Commit();
        }
        public void Rollback() {
            _transaction?.Rollback();
        }
        public SqlCommand CreateCommand(string querry) {
            return new SqlCommand(querry,_connection, _transaction);
        }
        public bool IsReady() {
            return (_connection != null && _connection.State != ConnectionState.Closed);
        }
    }
}
