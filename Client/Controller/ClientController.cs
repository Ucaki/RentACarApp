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

            return _communication.SendRequest<Automobil>(req);
        }
        public List<KlasaAutomobila> GetClassCarForCmb() {
            return _communication.SendRequest<List<KlasaAutomobila>>(new Request() { 
                Operation= OperationType.GetCarClass,
                //Argumen?
            });

        }
    }
}
