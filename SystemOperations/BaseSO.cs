using Common.Domain;
using Repository.Implementation;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations
{
    public abstract class BaseSO
    {
        protected readonly IDbRepository<IEntity> genericRepo;
        public object Result { get; protected set; }
        public BaseSO(IDbRepository<IEntity> generic)
        {
            genericRepo = generic;
        }
        public void ExecuteTemplate(IEntity entity) 
        {
            try
            {
                genericRepo.BeginTransaction();
                ExecuteConcreteOperation(entity);
                genericRepo.Commit();
            }
            catch (Exception ex)
            {
                genericRepo.RollBack();
                Debug.WriteLine(">>>" + ex.Message);
                throw;
            }
            finally { genericRepo.CloseConnection(); }
        }
        public abstract void ExecuteConcreteOperation(IEntity entity);
    }
}
