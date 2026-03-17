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
    public class AddRentSO : BaseSO
    {
        public AddRentSO(IRepository<IEntity> repo, IConnectionFactory factory) : base(repo, factory) { }
        protected override void ExecuteConcreteOperation(IEntity entity, IDbConnection createdConnection, IDbTransaction transaction)
        {
            try
            {
                Iznajmljivanje rent = (Iznajmljivanje)entity;
                genericRepo.Add(rent, createdConnection, transaction);
                for (int i = 1; i <= rent.ListaStavki.Count; i++)
                {
                    Automobil auto = rent.ListaStavki[i-1].Automobil;
                    auto.Status = StatusAutomobila.nedostupan;
                    genericRepo.Update(auto, createdConnection, transaction);

                    StavkaIznajmljivanja si = rent.ListaStavki[i-1];
                    si.IznajmljivanjeID = rent.IznajmljivanjeID;
                    si.RBr = i;
                    genericRepo.Add(si, createdConnection, transaction);

                }
                
                Result = rent;
            }
            catch (Exception ex) 
            {
                throw new Exception("Sistem ne moze da zapamti novo iznajmljivanje!");
            }
        }
    }
}
