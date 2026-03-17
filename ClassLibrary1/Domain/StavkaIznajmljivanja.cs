using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    [Serializable]
    public class StavkaIznajmljivanja : IEntity
    {
        [Browsable(false)]
        public int IznajmljivanjeID { get; set; }
        [Browsable(false)]
        public int RBr { get; set; }
        public DateTime DatumOd { get; set; }
        public DateTime DatumDo { get; set; }
        public int PocetnaKM { get; set; }
        public int? ZavrsnaKM {get;set;}
        public int CenaPoDanu { get; set; }
        public int UkupnaCenaStavke { get; set; }
        public StatusIznajmljivanja StatusStavke { get; set; }
        public Automobil Automobil { get; set; }
        [Browsable(false)]
        public string TableName =>"StavkaIznajmljivanja";
        [Browsable(false)]
        public string IDName => "IznajmljivanjeID";
        [Browsable(false)]
        public string IdCondition => $"IznajmljivanjeID={IznajmljivanjeID} and RBr={RBr}";
        [Browsable(false)]
        public string InsertValues => $"{IznajmljivanjeID},{RBr},'{DatumOd:yyyy-MM-dd}', '{DatumDo:yyyy-MM-dd}', {PocetnaKM},{(ZavrsnaKM.HasValue ? ZavrsnaKM.Value.ToString() : "NULL")},{CenaPoDanu},{UkupnaCenaStavke.ToString("F2", CultureInfo.InvariantCulture)},'{StatusStavke}', {Automobil.AutomobilID}";
        [Browsable(false)]
        public string SelectValues => "*";
        [Browsable(false)]
        public string UpdateValues => $"StatusStavke = '{StatusStavke}', datumDo = '{DatumDo:yyyy-MM-dd}', ZavrsnaKM={(ZavrsnaKM.HasValue ? ZavrsnaKM.Value.ToString() : "NULL")}";
        [Browsable(false)]
        public string JoinCondition => "join automobil on (automobil.automobilID = stavkaiznajmljivanja.automobilID)";

        public IEntity GetReaderResult(IDataReader reader)
        {
            if (!reader.Read()) return null;
            return new StavkaIznajmljivanja
            {
                IznajmljivanjeID = (int)reader["IznajmljivanjeID"],
                RBr = (int)reader["RBr"],
                DatumOd= (DateTime)reader["DatumOd"],
                DatumDo = Convert.ToDateTime(reader["DatumDo"]),
                PocetnaKM = (int)reader["PocetnaKM"],
                ZavrsnaKM = reader["ZavrsnaKM"] != DBNull.Value ? (int?)Convert.ToInt32(reader["ZavrsnaKM"]) : null,
                CenaPoDanu = (int) reader["CenaPoDanu"],
                UkupnaCenaStavke = (int)reader["UkupnaCenaStavke"],
                StatusStavke = (StatusIznajmljivanja)Enum.Parse(typeof(StatusIznajmljivanja), reader["StatusStavke"].ToString()),
                Automobil = new Automobil()
                {
                    AutomobilID = (int)reader["AutomobilID"],
                    RegistarskiBroj = Convert.ToString(reader["RegistarskiBroj"]),
                    Marka = Convert.ToString(reader["Marka"]),
                    Model = Convert.ToString(reader["Model"]),
                    Godiste = (int)reader["Godiste"],
                    Kilometraza = (int)reader["Kilometraza"],
                    Status = (StatusAutomobila)Enum.Parse(typeof(StatusAutomobila), reader["Status"].ToString()),
                    Klasa = new KlasaAutomobila()
                    {
                        KlasaID = (int)reader["KlasaID"],
                        Naziv = (string)reader["Naziv"],
                        OsnovnaCenaPoDanu = (int)reader["OsnovnaCenaPoDanu"]
                    }
                },
            };
        }

        public List<IEntity> GetReaderResults(IDataReader reader)
        {
            List<IEntity> rentItemList = new List<IEntity>();
            while (reader.Read())
            {
                rentItemList.Add(
                   new StavkaIznajmljivanja()
                   {
                       IznajmljivanjeID = (int)reader["IznajmljivanjeID"],
                       RBr = (int)reader["RBr"],
                       DatumOd = (DateTime)reader["DatumOd"],
                       DatumDo = Convert.ToDateTime(reader["DatumDo"]),
                       PocetnaKM = (int)reader["PocetnaKM"],
                       ZavrsnaKM = reader["ZavrsnaKM"] != DBNull.Value ? (int?)Convert.ToInt32(reader["ZavrsnaKM"]) : null,
                       CenaPoDanu = (int)reader["CenaPoDanu"],
                       UkupnaCenaStavke = (int)reader["UkupnaCenaStavke"],
                       StatusStavke = (StatusIznajmljivanja)Enum.Parse(typeof(StatusIznajmljivanja), reader["StatusStavke"].ToString()),
                       Automobil = new Automobil()
                       {
                           AutomobilID = (int)reader["AutomobilID"],
                           RegistarskiBroj = Convert.ToString(reader["RegistarskiBroj"]),
                           Marka = Convert.ToString(reader["Marka"]),
                           Model = Convert.ToString(reader["Model"]),
                           Godiste = (int)reader["Godiste"],
                           Kilometraza = (int)reader["Kilometraza"],
                           Status = (StatusAutomobila)Enum.Parse(typeof(StatusAutomobila), reader["Status"].ToString()),
                           Klasa = new KlasaAutomobila()
                           {
                               KlasaID = (int)reader["KlasaID"],
                               
                           }
                       }
                   });
            }
            return rentItemList;
        }
    }
}
