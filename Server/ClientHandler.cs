using Common.Communication;
using Common.Domain;
using Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class ClientHandler
    {
        private Socket _clientSocket;
        private readonly ServerController _controller;
        private JsonNetworkSerializer _serializer;
        public event EventHandler LoggedInClient;
        public event EventHandler LoggedOutClient;
        bool signal;

        //public Aministrator _logedAdmin
        public ClientHandler(Socket client, ServerController controller)
        {
            _clientSocket = client;
            _controller = controller;
            _serializer = new JsonNetworkSerializer(new NetworkStream(client));
            signal = true;
        }
        //internal?
        internal void HandleRequest()
        {
            try
            {
                while (signal)
                {
                    Request req = _serializer.Receive<Request>();
                    Response resp = ProcessRequest(req);
                    _serializer.Send(resp);
                }
            }
            catch (SocketException ex)
            {
                Debug.WriteLine("Communication with client stopped");
                Debug.WriteLine(">>>SOCKET>>>" + ex.Message);
            }
            catch (IOException ex)
            {
                Debug.WriteLine("Communication with client stopped");
                Debug.WriteLine(">>>IO>>>" + ex.Message);
            }
            finally
            {
                Stop();
                _serializer.Close();
            }
        }



        public Response ProcessRequest(Request req)
        {
            Response res = new Response();
            try
            {
                switch (req.Operation)
                {
                    case OperationType.Login:
                        break;
                    case OperationType.AddNewCar:
                        Automobil a=_controller.AddAutomobil(_serializer.ReadType<Automobil>(req.Argument));
                        if (a != null)
                        {
                            res.Result = a;
                            res.IsSuccessful = true;
                            res.Message = "Sistem created new car object.";
                        }
                        else {
                            res.IsSuccessful = false;
                            res.ErrorMessage = "Sistem cant create new car object";
                        }
                        break;
                    case OperationType.GetCarClass:
                        List<KlasaAutomobila> list = _controller.GetAllCarClass(new KlasaAutomobila());
                            res.Result = list;
                        if (res.Result != null)
                        {
                            res.IsSuccessful = true; 
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                res.IsSuccessful = false;
                res.ErrorMessage = ex.Message;
            }
            return res;
        }

        private readonly object _lockObj = new object();
        public void Stop()
        {
            lock (_lockObj)
            {
                if (_clientSocket != null)
                {
                    _clientSocket.Shutdown(SocketShutdown.Both);
                    _clientSocket.Close();
                    _clientSocket = null;
                    LoggedOutClient.Invoke(this, EventArgs.Empty);
                }
            }
        }
    }
}
