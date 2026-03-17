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
    public class AddUserSO : BaseSO
    {
        public AddUserSO(IRepository<IEntity> repo, IConnectionFactory factory) : base(repo, factory) { }
        protected override void ExecuteConcreteOperation(IEntity entity, IDbConnection createdConnection, IDbTransaction transaction)
        {
            try
            {
                Korisnik kor = (Korisnik)entity;
                
                genericRepo.Add(kor, createdConnection, transaction);
                Result = kor;
            }
            catch (Exception)
            {
                throw new Exception("Sistem ne moze da zapamti korisnika!");
            }
        }
    }
}
