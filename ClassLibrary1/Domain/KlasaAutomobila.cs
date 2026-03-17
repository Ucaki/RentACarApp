using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
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
        public string TableName => "KlasaVozila";

        public string IDName => "KlasaID";
        public string IdCondition => $"KlasaID = {KlasaID}";

        [JsonIgnore]
        public string InsertValues => "";

        public string SelectValues => "*";

        [JsonIgnore]
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
