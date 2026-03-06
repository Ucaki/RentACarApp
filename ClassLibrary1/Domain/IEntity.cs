using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace Common.Domain
{
    public interface IEntity
    {
        string TableName { get; }
        string IDName { get; }
        string IdCondition { get; }
        string InsertValues { get; }
        string SelectValues { get; }
        string UpdateValues { get; }
        string JoinCondition { get; }
        IEntity GetReaderResult(IDataReader reader);
        List<IEntity> GetReaderResults(IDataReader reader);
        /*
        Add protection from sql injection with
        string 
         */
    }
}
