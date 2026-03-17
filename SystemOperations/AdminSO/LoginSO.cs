using Common.Domain;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.AdminSO
{
    public class LoginSO : BaseSO
    {
        public LoginSO(IRepository<IEntity> generic, IConnectionFactory factory) : base(generic, factory)
        {
        }

        protected override void ExecuteConcreteOperation(IEntity entity, IDbConnection connection, IDbTransaction transaction)
        {
            try
            {
                Radnik r = (Radnik)entity;
                Result = genericRepo.Find(r, $"radnik.KorisnickoIme='{r.KorisnickoIme}' and radnik.Sifra='{r.Sifra}'", connection, transaction);
            }
            catch (Exception)
            {

                throw new Exception("Neuspešna prijava na sistem");
            }
        }
    }
}
