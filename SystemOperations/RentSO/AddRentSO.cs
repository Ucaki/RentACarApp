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
                Automobil auto = rent.Automobil;
                auto.Status = StatusAutomobila.nedostupan;
                
                genericRepo.Add(rent, createdConnection, transaction);
                genericRepo.Update(auto, createdConnection, transaction);
                Result = rent;
            }
            catch (Exception ) 
            {
                throw new Exception("Sistem ne moze da zapamti novo iznajmljivanje!");
            }
        }
    }
}
