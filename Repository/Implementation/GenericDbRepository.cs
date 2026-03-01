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
                if (!string.IsNullOrEmpty(entity.IDName))
                {
                    object primaryKeyValue = cmd.ExecuteScalar();
                    entity.GetType().GetProperty(entity.IDName).SetValue(entity, (int)primaryKeyValue);
                }
                else
                {
                    int affectedRows = cmd.ExecuteNonQuery();
                    Console.WriteLine("Affected rows insert:"+ affectedRows);
                }
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

        public void Delete(IEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEntity Find(IEntity entity, string condition)
        {
            throw new NotImplementedException();
        }

        public List<IEntity> GetAll(IEntity entity)
        {
            throw new NotImplementedException();
        }

        public void RollBack()
        {
            DbConnectionFactory.Instance.GetDbConnection().Rollback();
        }

        public void Update(IEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
