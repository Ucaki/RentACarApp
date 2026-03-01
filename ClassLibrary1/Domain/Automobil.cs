using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    public enum StatusAutomobila
    {
        dostupan,
        nedostupan,
        rashodovan
    }
    [Serializable]
    public class Automobil : IEntity
    {
        public int AutomobilID { get; set; }
        public string RegistarskiBroj { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public int Godiste { get; set; }
        public KlasaAutomobila Klasa { get; set; }
        public StatusAutomobila Status{ get; set; }

        /// <summary>
        //Implementacija interfejsa
        /// </summary>
        public string TableName => "Automobil";

        public string IDName => "AutomobilID";

        public string IdCondition => $"AutomobilID={AutomobilID}";

        public string InsertValues => $"'{RegistarskiBroj}', '{Marka}', '{Model}', {Godiste}, {Klasa.KlasaID}, '{Status}'"; 

        public string SelectValues => throw new NotImplementedException();

        public string UpdateValues => throw new NotImplementedException();

        public string JoinCondition => "";

        public IEntity GetReaderResult(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        public List<IEntity> GetReaderResults(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }
    }
}
