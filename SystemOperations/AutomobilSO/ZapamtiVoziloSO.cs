using Common.Domain;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.AutomobilSO
{
    public class ZapamtiVoziloSO : BaseSO
    {
        public ZapamtiVoziloSO(IRepository<IEntity> repo, IConnectionFactory factory) :base(repo, factory) { }
        protected override void ExecuteConcreteOperation(IEntity entity, IDbConnection createdConnection, IDbTransaction transaction)
        {
            try
            {
                Automobil auto = (Automobil)entity;
                
                genericRepo.Add(auto, createdConnection, transaction);
                Result = auto;
            }
            catch (Exception)
            {
                throw new Exception("Vozilo nije sačuvano!");
            }
        }
    }
}
