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
        public int RBr { get; set; }
        public DateTime DatumOd { get; set; }
        public DateTime DatumDo { get; set; }
        public int PocetnaKM { get; set; }
        public int? ZavrsnaKM {get;set;}
        public int CenaPoDanu { get; set; }
        public int UkupnaCenaStavke { get; set; }
        public StatusIznajmljivanja StatusStavke { get; set; }
        public Automobil Automobil { get; set; }

        public string TableName =>"StavkaIznajmljivanja";

        public string IDName => "IznajmljivanjeID";

        public string IdCondition => $"IznajmljivanjeID={IznajmljivanjeID}";

        public string InsertValues => $"{IznajmljivanjeID},{RBr},'{DatumOd:yyyy-MM-dd}', '{DatumDo:yyyy-MM-dd}', {PocetnaKM},{(ZavrsnaKM.HasValue ? ZavrsnaKM.Value.ToString() : "NULL")},{CenaPoDanu},{UkupnaCenaStavke.ToString("F2", CultureInfo.InvariantCulture)},'{StatusStavke}', {Automobil.AutomobilID}";

        public string SelectValues => "*";

        public string UpdateValues => $"status = '{StatusStavke}', datumDo = '{DatumDo:yyyy-MM-dd}', ZavrsnaKM={(ZavrsnaKM.HasValue ? ZavrsnaKM.Value.ToString() : "NULL")}";

        public string JoinCondition => "";

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
                    Klasa = new KlasaAutomobila()
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
                           Klasa = new KlasaAutomobila()
                       }
                   });
            }
            return rentItemList;
        }
    }
}
