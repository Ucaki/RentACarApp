using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    [Serializable]
    public class KlasaAutomobila : IEntity
    {
        public int KlasaID { get; set; }
        public string Naziv { get; set; }
        public int OsnovnaCenaPoDanu { get; set; }

        /// <summary>
        //Implementacija interfejsa
        /// </summary>
        public string TableName => "KlasaAutomobila";

        public string IDName => "KlasaID";
        public string IdCondition => $"KlasaID = {KlasaID}";

        public string InsertValues => throw new NotImplementedException();

        public string SelectValues => "*";

        public string UpdateValues => throw new NotImplementedException();

        public string JoinCondition => throw new NotImplementedException();

        public IEntity GetReaderResult(IDataReader reader)
        {
            throw new NotImplementedException();
        }

        public List<IEntity> GetReaderResults(IDataReader reader)
        {
            List<IEntity> entityList = new List<IEntity>();
            while (reader.Read())
            {
                entityList.Add(new KlasaAutomobila()
                {
                    KlasaID= (int)reader["KlasaID"],
                    Naziv= (string)reader["Naziv"],
                    OsnovnaCenaPoDanu= (int)reader["OsnovnaCenaPoDanu"]
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
