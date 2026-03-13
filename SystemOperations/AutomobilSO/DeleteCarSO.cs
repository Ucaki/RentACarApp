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
    public class DeleteCarSO : BaseSO
    {
        public DeleteCarSO(IRepository<IEntity> repo, IConnectionFactory factory) : base(repo,factory) { }
        protected override void ExecuteConcreteOperation(IEntity entity, IDbConnection connection, IDbTransaction transaction)
        {
            Automobil auto = (Automobil)entity;
            genericRepo.Delete(auto, connection, transaction);
        }
    }
}
