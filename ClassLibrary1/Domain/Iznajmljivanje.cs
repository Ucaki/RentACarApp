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
    public enum StatusIznajmljivanja { aktivno, zavrseno }
    [Serializable]
    public class Iznajmljivanje : IEntity
    {
        [Browsable(false)]
        public int IznajmljivanjeID { get; set; }
        public StatusIznajmljivanja Status { get; set; }
        public DateTime DatumOd { get; set; }
        public DateTime DatumDo { get; set; }
        public int PocetnaKM { get; set; }
        public int? ZavrsnaKM { get; set; }
        public int Popust { get; set; }
        public decimal UgovorenaCena { get; set; }
        public Korisnik Korisnik { get; set; }
        public Automobil Automobil { get; set; }
        public Radnik Radnik { get; set; }
        [Browsable(false)]
        public string TableName => "Iznajmljivanje";
        [Browsable(false)]
        public string IDName => "IznajmljivanjeID";
        [Browsable(false)]
        public string IdCondition => $"IznajmljivanjeID={IznajmljivanjeID}";
        [Browsable(false)]
        public string InsertValues => $"'{Status}', '{DatumOd:yyyy-MM-dd}', '{DatumDo:yyyy-MM-dd}', {PocetnaKM},{(ZavrsnaKM.HasValue ? ZavrsnaKM.Value.ToString() : "NULL")}, {Popust}, {UgovorenaCena.ToString("F2", CultureInfo.InvariantCulture)}, {Korisnik.KorisnikID}, {Radnik.RadnikID}, {Automobil.AutomobilID}";
        [Browsable(false)]
        public string SelectValues => "*";
       
        [Browsable(false)]
        public string UpdateValues => $"status = '{Status}', datumDo = '{DatumDo:yyyy-MM-dd}', ZavrsnaKM={(ZavrsnaKM.HasValue ? ZavrsnaKM.Value.ToString() : "NULL")}"; //popuni

        [Browsable(false)]
        public string JoinCondition => "";

    

        public IEntity GetReaderResult(IDataReader reader)
        {
            throw new NotImplementedException();
        }

        public List<IEntity> GetReaderResults(IDataReader reader)
        {
            List<IEntity> rentList = new List<IEntity>();
            while (reader.Read())
            {



                rentList.Add(
                   new Iznajmljivanje()
                   {
                       IznajmljivanjeID = (int)reader["IznajmljivanjeID"],
                       Status = (StatusIznajmljivanja)Enum.Parse(typeof(StatusIznajmljivanja), reader["status"].ToString()),
                       DatumOd = (DateTime)reader["DatumOd"],
                       DatumDo = (DateTime)reader["DatumDo"],
                       PocetnaKM = (int)reader["PocetnaKM"],
                       ZavrsnaKM = reader["ZavrsnaKM"] != DBNull.Value ? (int?)Convert.ToInt32(reader["ZavrsnaKM"]) : null,
                       Popust = (int)reader["Popust"],
                       UgovorenaCena = Convert.ToDecimal(reader["ugovorenaCena"]),
                       Automobil = new Automobil()
                       {
                           AutomobilID = (int)reader["AutomobilID"],
                           Klasa = new KlasaAutomobila()
                       },
                       Radnik = new Radnik(),
                       Korisnik = new Korisnik()
                       {
                           Mesto = new Mesto()
                       }
                   });
            }
            return rentList;
        }
        
    }
}
