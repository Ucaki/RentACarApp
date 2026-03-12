using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    [Serializable]
    public class Radnik : IEntity
    {
        public int RadnikID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string KorisnickoIme { get; set; }
        public string Sifra { get; set; }

        public string TableName => "Radnik";

        public string IDName => "KorisnickoIme";

        public string IdCondition => "";

        public string InsertValues => "";

        public string SelectValues => "*";

        public string UpdateValues => "";

        public string JoinCondition => "";

        public IEntity GetReaderResult(IDataReader reader)
        {
            if (!reader.Read())
                return null;
            Radnik radnik = new Radnik()
            {
                RadnikID = (int)reader["RadnikID"],
                Ime = Convert.ToString(reader["Ime"]),
                Prezime = Convert.ToString(reader["Prezime"]),
                KorisnickoIme = Convert.ToString(reader["KorisnickoIme"]),
                Sifra = Convert.ToString(reader["Sifra"])
            };
            return radnik;
        }

        public List<IEntity> GetReaderResults(IDataReader reader)
        {
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            return Ime + " " + Prezime;
        }
        public override bool Equals(object obj)
        {
            return obj is Radnik r && KorisnickoIme == r.KorisnickoIme && Sifra == r.Sifra;

        }
        public override int GetHashCode()
        {
            return KorisnickoIme?.GetHashCode() ?? 0;
        }
    }
}
