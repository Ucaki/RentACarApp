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
        public StatusAutomobila Status { get; set; }

        /// <summary>
        //Implementacija interfejsa
        /// </summary>
        public string TableName => "Automobil";

        public string IDName => "AutomobilID";

        public string IdCondition => $"AutomobilID={AutomobilID}";

        public string InsertValues => $"'{RegistarskiBroj}', '{Marka}', '{Model}', {Godiste}, {Klasa.KlasaID}, '{Status}'";

        public string SelectValues => "*";

        public string UpdateValues => $"RegistarskiBroj = '{RegistarskiBroj}', Marka = '{Marka}', Model = '{Model}', Godiste = {Godiste}, KlasaID = {Klasa.KlasaID}, Status = '{Status}'";

        public string JoinCondition => "";

        public IEntity GetReaderResult(SqlDataReader reader)
        {

            if (!reader.Read())
                return null;

            Automobil automobil = new Automobil();
            automobil.AutomobilID = (int)reader["AutomobilID"];
            automobil.RegistarskiBroj = Convert.ToString(reader["RegistarskiBroj"]);
            automobil.Marka = Convert.ToString(reader["Marka"]);
            automobil.Model = Convert.ToString(reader["Model"]);
            automobil.Godiste = (int)reader["Godiste"];
            automobil.Klasa = new KlasaAutomobila() { KlasaID = (int)reader["KlasaID"] };

            return automobil;
        }

        public List<IEntity> GetReaderResults(SqlDataReader reader)
        {
            List<IEntity> autoList = new List<IEntity>();
            while (reader.Read())
            {
                autoList.Add(
                    new Automobil()
                    {
                        AutomobilID = (int)reader["AutomobilID"],
                        RegistarskiBroj = Convert.ToString(reader["RegistarskiBroj"]),
                        Marka = Convert.ToString(reader["Marka"]),
                        Model = Convert.ToString(reader["Model"]),
                        Godiste = (int)reader["Godiste"],
                        Klasa = new KlasaAutomobila() { KlasaID = (int)reader["KlasaID"] }
                    });


            }
            return autoList;
        }
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (!(obj is Automobil)) return false;
            Automobil other = (Automobil)obj;
            if (other.AutomobilID <= 0 || AutomobilID <= 0) return false;
            return AutomobilID.Equals(other.AutomobilID);

        }
    }
}
