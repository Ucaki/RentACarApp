using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IRepository<T> where T: class 
    {
      //  string GetConnectionString { get; }
        void Add(T entity, IDbConnection createdConnection, IDbTransaction transaction);
        int Update(T entity, string condition, IDbConnection createdConnection, IDbTransaction transaction);
        int Delete(T entity, IDbConnection createdConnection, IDbTransaction transaction);
        T Find(T entity, string condition, IDbConnection createdConnection, IDbTransaction transaction);
        List<T> GetAll(T entity, IDbConnection createdConnection, IDbTransaction transaction, string condition = "1=1");
    }
}
