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
                int count = 0;
                Iznajmljivanje rent = (Iznajmljivanje)entity;
                genericRepo.Update(rent,createdConnection, transaction);
                foreach (StavkaIznajmljivanja item in rent.ListaStavki) { 
                    Automobil a = item.Automobil;
                    if (item.StatusStavke == StatusIznajmljivanja.zavrseno)
                    {
                        
                        a.Kilometraza = item.ZavrsnaKM ?? a.Kilometraza;
                        a.Status = StatusAutomobila.dostupan;
                    }
                    count += genericRepo.Update(a, createdConnection, transaction);
                    count += genericRepo.Update(item, createdConnection, transaction);
                }
                Result = count;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
