using Common.Domain;
using Repository.DbConnection;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementation
{
    public class GenericDbRepository : IDbRepository<IEntity>
    {
        private SqlCommand CreateSqlCommand(string query)
        {
            SqlCommand command = DbConnectionFactory.Instance.GetDbConnection().CreateCommand(query);
            return command;
        }
        public void Add(IEntity entity)
        {
            using (SqlCommand cmd = CreateSqlCommand($"INSERT INTO {entity.TableName} OUTPUT inserted.{entity.IDName} VALUES(" +
                $"{entity.InsertValues})"))
            {
                object primaryKeyValue = cmd.ExecuteScalar();
                entity.GetType().GetProperty(entity.IDName).SetValue(entity, (int)primaryKeyValue);
                Console.WriteLine($"Inserted row for table {entity.TableName}");
            }
        }

        public void BeginTransaction()
        {
            DbConnectionFactory.Instance.GetDbConnection().BeginTransaction();
        }

        public void CloseConnection()
        {
            DbConnectionFactory.Instance.GetDbConnection().CloseConnection();
        }

        public void Commit()
        {
            DbConnectionFactory.Instance.GetDbConnection().Commit();
        }

        public int Delete(IEntity entity)
        {
            using (SqlCommand cmd=CreateSqlCommand($"DELETE FROM {entity.TableName} where {entity.IdCondition}") )
            {
                int affectedRows = cmd.ExecuteNonQuery();
                if (affectedRows != 1) throw new Exception("Greška pri brisanju iz baze");
                return affectedRows;
            }
        }

        public IEntity Find(IEntity entity, string condition)
        {
            using (SqlCommand cmd= CreateSqlCommand($"select {entity.SelectValues} from {entity.TableName} {entity.JoinCondition} WHERE {condition}") )
            using (SqlDataReader reader= cmd.ExecuteReader())
            {
                return entity.GetReaderResult(reader);
            }
        }

        public List<IEntity> GetAll(IEntity entity, string condition="1=1")
        {
            using (SqlCommand cmd = CreateSqlCommand($"select {entity.SelectValues} from {entity.TableName} {entity.JoinCondition} where {condition}"))
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                return entity.GetReaderResults(reader);
            }
        }

        public void RollBack()
        {
            DbConnectionFactory.Instance.GetDbConnection().Rollback();
        }

        public int Update(IEntity entity, string condition)
        {
            using (SqlCommand cmd = CreateSqlCommand($"update {entity.TableName} set {entity.UpdateValues} where {condition}") ) {
                int affectedRows = cmd.ExecuteNonQuery();
                if (affectedRows != 1) throw new Exception("Greška pri ažuriranju baze");
                return affectedRows;
            }
        }
    }
}
