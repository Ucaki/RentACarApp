using Common.Domain;
using Repository.Implementation;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations
{
    public abstract class BaseSO
    {  
        protected readonly IRepository<IEntity> genericRepo;
        protected readonly IConnectionFactory factory;
        public object Result { get; protected set; }
        public BaseSO(IRepository<IEntity> generic, IConnectionFactory factory)
        {
            genericRepo = generic;
            this.factory = factory;
        }
        public void ExecuteTemplate(IEntity entity) 
        {
            using (var conn =factory.CreateConnection())
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        ExecuteConcreteOperation(entity, conn, transaction);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Debug.WriteLine(">>>" + ex.Message);
                        throw;
                    }
                }
            }
        }
        protected abstract void ExecuteConcreteOperation(IEntity entity, IDbConnection connection, IDbTransaction transaction);
    }
}
