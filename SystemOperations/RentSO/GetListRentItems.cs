using Common.Domain;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.RentSO
{
    public class GetListRentItems : BaseSO
    {
        public GetListRentItems(IRepository<IEntity> generic, IConnectionFactory factory) : base(generic, factory)
        {
        }

        protected override void ExecuteConcreteOperation(IEntity entity, IDbConnection connection, IDbTransaction transaction)
        {

            Iznajmljivanje rent = (Iznajmljivanje)entity;
            StavkaIznajmljivanja item = new StavkaIznajmljivanja() {
                IznajmljivanjeID = rent.IznajmljivanjeID
            };
            Result = genericRepo.GetAll(rent, connection, transaction).Cast<StavkaIznajmljivanja>().ToList();
        }
    }
}
