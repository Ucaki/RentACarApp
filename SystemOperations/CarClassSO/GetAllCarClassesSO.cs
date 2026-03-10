using Common.Domain;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.CarClassSO
{
    public class GetAllCarClassesSO : BaseSO
    {
        public GetAllCarClassesSO(IRepository<IEntity> generic, IConnectionFactory factory) : base(generic, factory)
        {
        }

        protected override void ExecuteConcreteOperation(IEntity entity, IDbConnection connection, IDbTransaction transaction)
        {
            KlasaAutomobila klasa = (KlasaAutomobila)entity;
            Result = genericRepo.GetAll(klasa, connection, transaction).Cast<KlasaAutomobila>().ToList();
        }
    }
}
