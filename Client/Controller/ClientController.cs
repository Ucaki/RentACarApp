using Client.Communication;
using Common.Communication;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Controller
{
    public class ClientController
    {
        private ClientCommunication _communication;

        public ClientController(ClientCommunication communication)
        {
            _communication = communication;
        }
        
        public Automobil AddCar(Automobil auto)
        {
            
            Request req = new Request
            {
                Operation = OperationType.AddNewCar,
                Argument = auto
            };

            ;
            return _communication.SendRequest<Automobil>(req);
        }

        internal List<Korisnik> GetAllUsers()
        {
            Request req = new Request
            {
                Operation = OperationType.GetAllUsers,
                
            };

            ;
            return _communication.SendRequest<List<Korisnik>>(req);

        }
        internal List<Korisnik> GetFilteredUsers(Korisnik k) {
            Request req = new Request
            {
                Operation = OperationType.GetFilteredUsers,
                Argument=k
            };

            ;
            return _communication.SendRequest<List<Korisnik>>(req);
        }

        public List<KlasaAutomobila> GetClassCarForCmb() {
            
            return _communication.SendRequest<List<KlasaAutomobila>>(new Request() { 
                Operation= OperationType.GetCarClass,
                //Argumen?
            });

        }
        public Radnik Login(Radnik r) {
            if (!_communication.IsConnected)
                _communication.Connect();

            Request req = new Request
            {
                Operation = OperationType.Login,
                Argument = r
            };


            return _communication.SendRequest<Radnik>(req);

        }

        internal List<Mesto> GetAllPlaces()
        {
            Request req = new Request
            {
                Operation = OperationType.GetAllPlaces
                
            };
            return _communication.SendRequest<List<Mesto>>(req);
        }

        internal void LogOut()
        {
            Request req = new Request
            {
                Operation = OperationType.LogOut
            };

            
            _communication.SendRequest(req);
        }


        public void CloseConnection()
        {
            _communication.Close();
        }

        internal List<Automobil> FilterCars(Automobil auto)
        {
            Request req = new Request
            {
                Operation = OperationType.FilterCars,
                Argument = auto
            };
            return  _communication.SendRequest<List<Automobil>>(req);
        }

        internal void DeleteCar(Automobil a)
        {
            Request req = new Request
            {
                Operation = OperationType.DeleteCar,
                Argument = a
            };
            _communication.SendRequest(req);
        }

        internal void UpdateCar(Automobil a)
        {
            Request req = new Request
            {
                Operation = OperationType.UpdateCar,
                Argument = a
            };
            _communication.SendRequest(req);
        }

        internal Korisnik AddCustomer(Korisnik korisnik)
        {
            Request req = new Request
            {
                Operation = OperationType.AddUsers,
                Argument = korisnik
            };
            return _communication.SendRequest<Korisnik>(req);
        }

        internal Iznajmljivanje AddRent(Iznajmljivanje rent)
        {
            Request req = new Request
            {
                Operation = OperationType.AddRent,
                Argument = rent
            };
            return _communication.SendRequest<Iznajmljivanje>(req);
        }

        internal List<Iznajmljivanje> getListRents(Iznajmljivanje i)
        {
            Request req = new Request
            {
                Operation = OperationType.GetListRents,
                Argument = i
            };
            return _communication.SendRequest<List<Iznajmljivanje>>(req);
        }

        internal void ReleaseRent(Iznajmljivanje iznajmljivanjeZaRazduzivanje)
        {
            Request req = new Request
            {
                Operation = OperationType.ReleaseRent,
                Argument = iznajmljivanjeZaRazduzivanje
            };
            _communication.SendRequest(req);
        }

        internal int addRentsSSS(BindingList<Iznajmljivanje> listRents)
        {
            Request req = new Request
            {
                Operation = OperationType.SlozeniKey1DodajListuIznajmljivanja,
                Argument = listRents
            };
            return _communication.SendRequest(req);
        }
    }
}
