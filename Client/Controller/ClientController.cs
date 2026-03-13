using Client.Communication;
using Common.Communication;
using Common.Domain;
using System;
using System.Collections.Generic;
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
            //Treba da uhvatim exception koji se baca u communication.SendRequest
            Request req = new Request
            {
                Operation = OperationType.AddNewCar,
                Argument = auto
            };

            ;
            return _communication.SendRequest<Automobil>(req);
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

        
    }
}
