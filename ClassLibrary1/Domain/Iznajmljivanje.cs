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
        //"Iznajmljivanje.IznajmljivanjeID, Iznajmljivanje.status as rentStatus, Iznajmljivanje.DatumOd,Iznajmljivanje.DatumDo,Iznajmljivanje.PocetnaKM, Iznajmljivanje.ZavrsnaKM,Iznajmljivanje.Popust, Iznajmljivanje.ugovorenaCena, Automobil.AutomobilID, Automobil.RegistarskiBroj, Automobil.Marka, Automobil.Model, Automobil.Godiste,Automobil.Kilometraza, Automobil.status as AutoStatus,KlasaID, Korisnik.KorisnikID, Korisnik.Ime as korisnikIme, Korisnik.prezime as KorisnikPrezime,Korisnik.adresa,Korisnik.Email, mestoID, Radnik.RadnikID, Radnik.ime as radnikIme, Radnik.prezime as radnikPrezime, Radnik.KorisnickoIme, Radnik.sifra";
        [Browsable(false)]
        public string UpdateValues => $"status = '{Status}', datumDo = '{DatumDo:yyyy-MM-dd}', ZavrsnaKM={(ZavrsnaKM.HasValue ? ZavrsnaKM.Value.ToString() : "NULL")}"; //popuni

        [Browsable(false)]
        public string JoinCondition => "";

        //$"join Radnik on (radnik.RadnikID=Iznajmljivanje.RadnikID) join Korisnik on (iznajmljivanje.KorisnikID=Korisnik.KorisnikID) join automobil on (Automobil.AutomobilID = Iznajmljivanje.AutomobilID)"; //popuni

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
                //rentList.Add(
                //    new Iznajmljivanje()
                //    {
                //        IznajmljivanjeID = (int)reader["Iznajmljivanje.IznajmljivanjeID"],
                //        Status = (StatusIznajmljivanja)Enum.Parse(typeof(StatusIznajmljivanja), reader["rentStatus"].ToString()),
                //        DatumOd = (DateTime)reader["Iznajmljivanje.DatumOd"],
                //        DatumDo = (DateTime)reader["Iznajmljivanje.DatumDo"],
                //        PocetnaKM = (int)reader["Iznajmljivanje.PocetnaKM"],
                //        ZavrsnaKM = (int)reader["Iznajmljivanje.ZavrsnaKM"],
                //        Popust = (int)reader["Iznajmljivanje.Popust"],
                //        UgovorenaCena = Convert.ToDecimal(reader["Iznajmljivanje.ugovorenaCena"]),
                //        Automobil = new Automobil()
                //        {
                //            AutomobilID = (int)reader["Automobil.AutomobilID"],
                //            RegistarskiBroj = Convert.ToString(reader["Automobil.RegistarskiBroj"]),
                //            Marka = Convert.ToString(reader["Automobil.Marka"]),
                //            Model = Convert.ToString(reader["Automobil.Model"]),
                //            Godiste = (int)reader["Automobil.Godiste"],
                //            Kilometraza = (int)reader["Automobil.Kilometraza"],
                //            Status = (StatusAutomobila)Enum.Parse(typeof(StatusAutomobila), reader["AutoStatus"].ToString()),
                //            Klasa = new KlasaAutomobila()
                //            {
                //                KlasaID = (int)reader["KlasaID"],
                //                //Naziv = (string)reader["KlasaNaziv"],
                //                //OsnovnaCenaPoDanu = (int)reader["OsnovnaCenaPoDanu"]
                //            }
                //        },
                //        Korisnik = new Korisnik()
                //        {
                //            KorisnikID = (int)reader["Korisnik.KorisnikID"],
                //            Ime = Convert.ToString(reader["korisnikIme"]),
                //            Prezime = Convert.ToString(reader["KorisnikPrezime"]),
                //            Adresa = Convert.ToString(reader["Korisnik.adresa"]),
                //            Email = Convert.ToString(reader["Korisnik.Email"]),
                //            Mesto = new Mesto()
                //            {
                //                MestoID = (int)reader["MestoID"],
                //                //Naziv = (string)reader["mestoNaziv"]
                //            }
                //        },
                //        Radnik = new Radnik()
                //        {
                //            RadnikID = (int)reader["Radnik.RadnikID"],
                //            Ime = Convert.ToString(reader["radnikIme"]),
                //            Prezime = Convert.ToString(reader["radnikPrezime"]),
                //            KorisnickoIme = Convert.ToString(reader["Radnik.KorisnickoIme"]),
                //            Sifra = Convert.ToString(reader["Radnik.Sifra"])
                //        }
                //    });


            }
            return rentList;
        }
        
    }
}
