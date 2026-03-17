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
    public class GetListUserRentsSO : BaseSO
    {
        public GetListUserRentsSO(IRepository<IEntity> generic, IConnectionFactory factory) : base(generic, factory)
        {
        }

        protected override void ExecuteConcreteOperation(IEntity entity, IDbConnection connection, IDbTransaction transaction)
        {
            
            Iznajmljivanje rent = (Iznajmljivanje)entity;
            string condition = $"Iznajmljivanje.korisnikID= {rent.Korisnik.KorisnikID}";
            Result = genericRepo.GetAll(rent, connection, transaction, condition).Cast<Iznajmljivanje>().ToList();
        }
    }

}
