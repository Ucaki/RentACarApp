using Common.Domain;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.MestoSO
{ 
    public class GetPlacesSO : BaseSO
    {
        public GetPlacesSO(IRepository<IEntity> generic, IConnectionFactory factory) : base(generic, factory)
        {
        }

        protected override void ExecuteConcreteOperation(IEntity entity, IDbConnection connection, IDbTransaction transaction)
        {
            Mesto mesto = (Mesto)entity;
            Result = genericRepo.GetAll(mesto, connection, transaction).Cast<Mesto>().ToList();
        }
    }
}
