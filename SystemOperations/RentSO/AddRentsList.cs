
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
    public class AddRentsList: BaseSO
    {
        public AddRentsList(IRepository<IEntity> repo, IConnectionFactory factory) : base(repo, factory) { }
        protected override void ExecuteConcreteOperation(IEntity entity, IDbConnection createdConnection, IDbTransaction transaction)
        {
            try
            {
                int num=0;
                List<Iznajmljivanje> rentLis = (List<Iznajmljivanje>)entity;
                List<Automobil> carList = new List<Automobil>();
                foreach (Iznajmljivanje iz in rentLis)
                {
                    Automobil auto = iz.Automobil;
                    auto.Status = StatusAutomobila.nedostupan;
                    carList.Add(auto);
                }
                foreach (Automobil a in carList) {
                   num += genericRepo.Update(a, createdConnection, transaction);
                }
                foreach (Iznajmljivanje iz in rentLis)
                {
                     genericRepo.Add(iz, createdConnection, transaction);
                    num++;
                }
                
                Result = rent;
            }
            catch (Exception)
            {
                throw new Exception("Sistem ne moze da zapamti novo iznajmljivanje!");
            }
        }
    }
}
