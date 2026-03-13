using Common.Domain;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.KorisnikSO
{
    public class GetAllUsersSO : BaseSO
    {
        public GetAllUsersSO(IRepository<IEntity> repo, IConnectionFactory factory) : base(repo, factory) { }

        protected override void ExecuteConcreteOperation(IEntity entity, IDbConnection connection, IDbTransaction transaction)
        {
            Korisnik kor = (Korisnik)entity;
            Result = genericRepo.GetAll(kor, connection, transaction).Cast<Korisnik>().ToList(); 
        }
    }
}
