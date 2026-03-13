using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    public class Iznajmljivanje : IEntity
    {
        public string TableName => throw new NotImplementedException();

        public string IDName => throw new NotImplementedException();

        public string IdCondition => throw new NotImplementedException();

        public string InsertValues => throw new NotImplementedException();

        public string SelectValues => throw new NotImplementedException();

        public string UpdateValues => throw new NotImplementedException();

        public string JoinCondition => throw new NotImplementedException();

        public IEntity GetReaderResult(IDataReader reader)
        {
            throw new NotImplementedException();
        }

        public List<IEntity> GetReaderResults(IDataReader reader)
        {
            throw new NotImplementedException();
        }
    }
}
