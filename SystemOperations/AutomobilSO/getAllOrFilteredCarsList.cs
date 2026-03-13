using Common.Domain;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.AutomobilSO
{
    public class GetAllOrFilteredCarsList : BaseSO
    {
        public GetAllOrFilteredCarsList(IRepository<IEntity> repo, IConnectionFactory factory) : base(repo, factory) 
        { }
        protected override void ExecuteConcreteOperation(IEntity entity, IDbConnection connection, IDbTransaction transaction)
        {
            Automobil auto = (Automobil)entity;
            Result=genericRepo.GetAll(auto, connection, transaction, auto.FilterQuerry).Cast<Automobil>().ToList();
        }
    }
}
