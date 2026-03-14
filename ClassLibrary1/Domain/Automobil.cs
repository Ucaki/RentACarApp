    using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        [Browsable(false)]
        public int AutomobilID { get; set; }
        public string RegistarskiBroj { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public int Godiste { get; set; }
        public int Kilometraza { get; set; }
       // [Browsable(false)]
        public KlasaAutomobila Klasa { get; set; }
       // public string KlasaNaziv => Klasa?.Naziv;
        public StatusAutomobila Status { get; set; }

        /// <summary>
        //Implementacija interfejsa
        /// </summary>
        [Browsable(false)]
        public string TableName => "Automobil";
        [Browsable(false)]
        public string IDName => "AutomobilID";
        [Browsable(false)]
        public string IdCondition => $"AutomobilID={AutomobilID}";
        [Browsable(false)]
        public string InsertValues => $"'{RegistarskiBroj}', '{Marka}', '{Model}', {Kilometraza}, {Godiste}, {Klasa.KlasaID}, '{Status}'";
        [Browsable(false)]
        public string SelectValues => "*";
        [Browsable(false)]
        public string UpdateValues => $"RegistarskiBroj = '{RegistarskiBroj}', Marka = '{Marka}', Model = '{Model}', Godiste = {Godiste}, Kilometraza={Kilometraza}, KlasaID = {Klasa.KlasaID}, Status = '{Status}'";
        [Browsable(false)]
        public string FilterQuerry { get; set; }
        [Browsable(false)]
        public string JoinCondition => "join KlasaVozila on (Automobil.KlasaID=KlasaVozila.KlasaID)";

        public IEntity GetReaderResult(IDataReader reader)
        {

            if (!reader.Read())
                return null;

            Automobil automobil = new Automobil() {
                AutomobilID = (int)reader["AutomobilID"],
                RegistarskiBroj = Convert.ToString(reader["RegistarskiBroj"]),
                Marka = Convert.ToString(reader["Marka"]),
                Model = Convert.ToString(reader["Model"]),
                Godiste = (int)reader["Godiste"],
                Kilometraza=(int)reader["Kilometraza"],
                Status = (StatusAutomobila)Enum.Parse(typeof(StatusAutomobila), reader["Status"].ToString()),
            Klasa = new KlasaAutomobila() {
                    KlasaID = (int)reader["KlasaID"],
                    Naziv = (string)reader["Naziv"],
                    OsnovnaCenaPoDanu = (int)reader["OsnovnaCenaPoDanu"]
                }
            };
            

            return automobil;
        }

        public List<IEntity> GetReaderResults(IDataReader reader)
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
                        Kilometraza = (int)reader["Kilometraza"],
                        Status = (StatusAutomobila)Enum.Parse(typeof(StatusAutomobila), reader["Status"].ToString()),
                        Klasa = new KlasaAutomobila() { 
                            KlasaID = (int)reader["KlasaID"] ,
                            Naziv = (string)reader["Naziv"],
                            OsnovnaCenaPoDanu = (int)reader["OsnovnaCenaPoDanu"]
                        }
                    });


            }
            return autoList;
        }
        public override bool Equals(object obj)
        {
            if (!(obj is Automobil)) return false;
            Automobil other = (Automobil)obj;
            return AutomobilID == other.AutomobilID && RegistarskiBroj == other.RegistarskiBroj && Marka == other.Marka && Model == other.Model
                && Godiste == other.Godiste && Kilometraza==other.Kilometraza && (Klasa?.KlasaID?? 0) == (other.Klasa?.KlasaID?? 0) && Status == other.Status;
        }
        public override int GetHashCode()
        {
            return RegistarskiBroj?.GetHashCode() ?? 0;
        }
        public override string ToString()
        {
            return Marka + " " + Model;
        }
    }
}
