using Common.Domain;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.AutomobilSO
{
    public class UpdateCarSO : BaseSO
    {
        public UpdateCarSO(IRepository<IEntity> repo, IConnectionFactory factory):base(repo,factory) { }
        protected override void ExecuteConcreteOperation(IEntity entity, IDbConnection connection, IDbTransaction transaction)
        {
            Automobil a = (Automobil)entity;
            Result = genericRepo.Update(a, connection, transaction);
        }
    }
}
