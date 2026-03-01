using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        IEntity GetReaderResult(SqlDataReader reader);
        List<IEntity> GetReaderResults(SqlDataReader reader);

    }
}
