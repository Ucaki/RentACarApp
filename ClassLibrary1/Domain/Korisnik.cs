using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    [Serializable]
    public class Korisnik : IEntity
    {
        public int KorisnikID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int Adresa { get; set; }
        public int Email { get; set; }
        public Mesto mesto { get; set; }



        public string TableName => "Korisnik";

        public string IDName => "KorisnikID";

        public string IdCondition => throw new NotImplementedException();

        public string InsertValues => throw new NotImplementedException();

        public string SelectValues => throw new NotImplementedException();

        public string UpdateValues => throw new NotImplementedException();

        public string JoinCondition => throw new NotImplementedException();

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
