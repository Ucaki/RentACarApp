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
    public class ReleaseRentSO : BaseSO
    {
        public ReleaseRentSO(IRepository<IEntity> repo, IConnectionFactory factory) : base(repo, factory) { }
        protected override void ExecuteConcreteOperation(IEntity entity, IDbConnection createdConnection, IDbTransaction transaction)
        {
            try
            {
                Iznajmljivanje rent = (Iznajmljivanje)entity;
                rent.Status = StatusIznajmljivanja.zavrseno;

                Automobil auto = rent.Automobil;
                auto.Status = StatusAutomobila.dostupan;
                auto.Kilometraza = rent.ZavrsnaKM ?? 0;
                
                genericRepo.Update(rent, createdConnection, transaction);
                Result = genericRepo.Update(auto, createdConnection, transaction);
                //Result = rent;
            }
            catch (Exception )
            {
                throw new Exception("Sistem ne moze da razduzi");
            }
        }
    }
}
