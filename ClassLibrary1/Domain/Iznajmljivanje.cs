using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    public enum StatusIznajmljivanja { aktivno, zavrseno }
    public class Iznajmljivanje : IEntity
    {
        public int IznajmljivanjeID {get; set;}
        public StatusIznajmljivanja Status { get; set; }
        public DateTime DatumOd { get; set; }
        public DateTime DatumDo { get; set; }
        public int PocetnaKM { get; set; }
        public int ZavrsnaKM { get; set; }
        public int Popust { get; set; }
        public decimal UgovorenaCena { get; set; }
        public Korisnik Korisnik { get; set; }
        public Automobil Automobil { get; set; }
        public Radnik Radnik { get; set; }

        public string TableName => "Iznajmljivanje";

        public string IDName => "IznajmljivanjeID";

        public string IdCondition => $"IznajmljivanjeID={IznajmljivanjeID}";

        public string InsertValues => $"'{Status}', '{DatumOd:yyyy-MM-dd}', '{DatumDo:yyyy-MM-dd}', {PocetnaKM}, {Popust}, {UgovorenaCena.ToString("F2", CultureInfo.InvariantCulture)}, {Korisnik.KorisnikID}, {Radnik.RadnikID}, {Automobil.AutomobilID}"; 

        public string SelectValues => "*";

        public string UpdateValues => $""; //popuni

        public string JoinCondition => $"join Radnik on (radnik.RadnikID=Iznajmljivanje.RadnikID) join Korisnik on (iznajmljivanje.KorisnikID=Korisnik.KorisnikID) join automobil on (Automobil.AutomobilID = Iznajmljivanje.AutomobilID)"; //popuni

        public IEntity GetReaderResult(IDataReader reader)
        {
            throw new NotImplementedException();
        }

        public List<IEntity> GetReaderResults(IDataReader reader)
        {
            throw new NotImplementedException();
        }
    }
}
