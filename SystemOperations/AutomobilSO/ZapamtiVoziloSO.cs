using Common.Domain;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.AutomobilSO
{
    public class ZapamtiVoziloSO : BaseSO
    {
        public ZapamtiVoziloSO(IDbRepository<IEntity> repo) :base(repo) { }
        public override void ExecuteConcreteOperation(IEntity entity)
        {
            try
            {
                Automobil auto = (Automobil)entity;
                //validate here
                genericRepo.Add(auto);
                Result = auto;
            }
            catch (Exception)
            {
                throw new Exception("Vozilo nije sačuvano!");
            }
        }
    }
}
