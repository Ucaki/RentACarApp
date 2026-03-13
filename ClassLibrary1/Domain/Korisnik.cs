using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    [Serializable]
    public class Korisnik : IEntity
    {
        [Browsable(false)]
        public int KorisnikID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Adresa { get; set; }
        public string Email { get; set; }
        public Mesto Mesto { get; set; }


        [Browsable(false)]
        public string filter { get; set; }
        [Browsable(false)]
        public string TableName => "Korisnik";
        [Browsable(false)]
        public string IDName => "KorisnikID";
        [Browsable(false)]
        public string IdCondition => $"KorisnikID={KorisnikID}";
        [Browsable(false)]
        public string InsertValues => $"'{Ime}', '{Prezime}', '{Adresa}', '{Email}', {Mesto.MestoID}";
        [Browsable(false)]
        public string SelectValues => "*";
        [Browsable(false)]
        public string UpdateValues => "";
        [Browsable(false)]
        public string JoinCondition => "join Mesto on (Korisnik.MestoID=Mesto.mestoID)";

        public IEntity GetReaderResult(IDataReader reader)
        {
            if (!reader.Read())
                return null;

            Korisnik kor = new Korisnik()
            {
                KorisnikID = (int)reader["KorisnikID"],
                Ime = Convert.ToString(reader["Ime"]),
                Prezime = Convert.ToString(reader["Prezime"]),
                Adresa = Convert.ToString(reader["adresa"]),
                Email = Convert.ToString(reader["Email"]),
                Mesto = new Mesto()
                {
                    MestoID = (int)reader["MestoID"],
                    Naziv = (string)reader["Naziv"]
                }
            };
            return kor;
        }

        public List<IEntity> GetReaderResults(IDataReader reader)
        {
            List<IEntity> korisnikList = new List<IEntity>();
            while (reader.Read())
            {
                korisnikList.Add(
                    new Korisnik()
                    {
                        KorisnikID = (int)reader["KorisnikID"],
                        Ime = Convert.ToString(reader["Ime"]),
                        Prezime = Convert.ToString(reader["Prezime"]),
                        Adresa = Convert.ToString(reader["adresa"]),
                        Email = Convert.ToString(reader["Email"]),
                        Mesto = new Mesto()
                        {
                            MestoID = (int)reader["MestoID"],
                            Naziv = (string)reader["Naziv"]
                        }
                    });


            }
            return korisnikList;
        }
    }
}
