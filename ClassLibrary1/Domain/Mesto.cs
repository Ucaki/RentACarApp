using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    [Serializable]
    public class Mesto : IEntity
    {
        int MestoID { get; set; }
        string Naziv { get; set; }


        public string TableName =>"Mesto";

        public string IDName => "MestoID";

        public string IdCondition => $"MestoID={MestoID}";

        public string InsertValues => "";

        public string SelectValues => "*";

        public string UpdateValues => "";

        public string JoinCondition => "";

        public IEntity GetReaderResult(IDataReader reader)
        {
            throw new NotImplementedException();
        }

        public List<IEntity> GetReaderResults(IDataReader reader)
        {
            List<IEntity> entityList = new List<IEntity>();
            while (reader.Read())
            {
                entityList.Add(new Mesto()
                {
                    MestoID = (int)reader["MestoID"],
                    Naziv = (string)reader["Naziv"]
                });
            }
            return entityList;
        }

        public override string ToString()
        {
            return this.Naziv;
        }
    }
}
