using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IRepository<T> where T: class
    {
        void Add(T entity);
        int Update(T entity, string condition);
        int Delete(T entity);
        T Find(T entity, string condition);
        List<T> GetAll(T entity, string condition="1=1");
    }
}
