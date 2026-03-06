using Common.Domain;
using Repository.Connection;

using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementation
{
    public class GenericDbRepository : IRepository<IEntity>
    {
       // private readonly string _connectionString;
        private readonly IConnectionFactory factory;
        public GenericDbRepository(IConnectionFactory factory)
        {
            //_connectionString = conn;
            this.factory = factory;
        }
        //public string GetConnectionString => _connectionString;

        
        private IDbCommand CreateDbCommand(string query, IDbConnection createdConnection, IDbTransaction transaction)
        {
            IDbCommand command = createdConnection.CreateCommand();
            command.CommandText = query;
            command.Transaction = transaction;
            return command;
        }
        public void Add(IEntity entity, IDbConnection createdConnection, IDbTransaction transaction)
        {
            using (var cmd = CreateDbCommand($"INSERT INTO {entity.TableName} OUTPUT inserted.{entity.IDName} VALUES(" +
                $"{entity.InsertValues})", createdConnection, transaction))
            {
                object primaryKeyValue = cmd.ExecuteScalar();
                entity.GetType().GetProperty(entity.IDName).SetValue(entity, (int)primaryKeyValue);
                
                Console.WriteLine($"Inserted row for table {entity.TableName}");
            }
        }

        public int Delete(IEntity entity, IDbConnection createdConnection, IDbTransaction transaction)
        {
            using (var cmd = CreateDbCommand($"DELETE FROM {entity.TableName} where {entity.IdCondition}", createdConnection, transaction))
            {
                int affectedRows = cmd.ExecuteNonQuery();
                if (affectedRows != 1) throw new Exception("Greška pri brisanju iz baze");
                return affectedRows;
            }
        }

        public IEntity Find(IEntity entity, string condition, IDbConnection createdConnection, IDbTransaction transaction)
        {
            using (var cmd = CreateDbCommand($"select {entity.SelectValues} from {entity.TableName} {entity.JoinCondition} WHERE {condition}", createdConnection, transaction))
            using (IDataReader reader = cmd.ExecuteReader())
            {
                return entity.GetReaderResult(reader);
            }
        }

        public List<IEntity> GetAll(IEntity entity, IDbConnection createdConnection, IDbTransaction transaction, string condition = "1=1")
        {
            using (var cmd = CreateDbCommand($"select {entity.SelectValues} from {entity.TableName} {entity.JoinCondition} where {condition}", createdConnection, transaction))
            using (IDataReader reader = cmd.ExecuteReader())
            {
                return entity.GetReaderResults(reader);
            }
        }

        public int Update(IEntity entity, string condition, IDbConnection createdConnection, IDbTransaction transaction)
        {
            using (var cmd = CreateDbCommand($"update {entity.TableName} set {entity.UpdateValues} where {condition}", createdConnection, transaction))
            {
                int affectedRows = cmd.ExecuteNonQuery();
                if (affectedRows != 1) throw new Exception("Greška pri ažuriranju baze");
                return affectedRows;
            }
        }

        //public void OpenConnection()
        //{
        //    _connection.OpenConnection();
        //}
        //public void BeginTransaction()
        //{
        //    _connection.BeginTransaction();
        //}

        //public void CloseConnection()
        //{
        //    _connection.CloseConnection();
        //}

        //public void Commit()
        //{
        //    _connection.Commit();
        //}

        //public void RollBack()
        //{
        //    _connection.Rollback();
        //}
    }
}
