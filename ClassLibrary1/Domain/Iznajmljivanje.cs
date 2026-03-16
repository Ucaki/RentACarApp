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
        public StatusIznajmljivanja StatusIznajmljivanja { get; set; }
        public int Popust { get; set; }
        public decimal UkupnaCena { get; set; }
        public DateTime DatumKreiranja { get; set; }
        public Korisnik Korisnik { get; set; }
        public Radnik Radnik { get; set; }
        public List<StavkaIznajmljivanja> listaStavki { get; set; }

        [Browsable(false)]
        public string TableName => "Iznajmljivanje";
        [Browsable(false)]
        public string IDName => "IznajmljivanjeID";
        [Browsable(false)]
        public string IdCondition => $"IznajmljivanjeID={IznajmljivanjeID}";


        [Browsable(false)]
        public string InsertValues => $"'{StatusIznajmljivanja}',{Popust}, {UkupnaCena.ToString("F2", CultureInfo.InvariantCulture)},'{DatumKreiranja:yyyy-MM-dd}', {Korisnik.KorisnikID}, {Radnik.RadnikID}";
        // public string InsertValues => $"'{Status}', '{DatumOd:yyyy-MM-dd}', '{DatumDo:yyyy-MM-dd}', {PocetnaKM},{(ZavrsnaKM.HasValue ? ZavrsnaKM.Value.ToString() : "NULL")}, {Popust}, {UgovorenaCena.ToString("F2", CultureInfo.InvariantCulture)}, {Korisnik.KorisnikID}, {Radnik.RadnikID}, {Automobil.AutomobilID}";
        [Browsable(false)]
        public string SelectValues => "*";
       
        [Browsable(false)]
        public string UpdateValues => $"status = '{StatusIznajmljivanja}'"; 

        [Browsable(false)]
        public string JoinCondition => "";

    

        public IEntity GetReaderResult(IDataReader reader)
        {
            if (!reader.Read()) {
                return null;
            }
            return new Iznajmljivanje
            {
                IznajmljivanjeID= (int)reader["IznajmljivanjeID"],
                StatusIznajmljivanja= (StatusIznajmljivanja)Enum.Parse(typeof(StatusIznajmljivanja), reader["statusIznajmljivanja"].ToString()),
                Popust = (int)reader["Popust"],
                UkupnaCena = Convert.ToDecimal(reader["UkupnaCena"]),
                DatumKreiranja = (DateTime)reader["DatumKreiranja"],
                Korisnik = new Korisnik { 
                    KorisnikID= (int)reader["KorisnikID"],
                    Mesto= new Mesto()
                },
                Radnik = new Radnik
                {
                    RadnikID= (int)reader["RadnikID"]
                }
            };
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
                       StatusIznajmljivanja = (StatusIznajmljivanja)Enum.Parse(typeof(StatusIznajmljivanja), reader["statusIznajmljivanja"].ToString()),
                       Popust = (int)reader["Popust"],
                       UkupnaCena = Convert.ToDecimal(reader["UkupnaCena"]),
                       DatumKreiranja = (DateTime)reader["DatumKreiranja"],
                       Korisnik = new Korisnik
                       {
                           KorisnikID = (int)reader["KorisnikID"],
                           Mesto = new Mesto()
                       },
                       Radnik = new Radnik
                       {
                           RadnikID = (int)reader["RadnikID"]
                       }
                   });
            }
            return rentList;
        }
        
    }
}
