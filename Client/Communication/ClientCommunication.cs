using Common.Communication;
using Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;


namespace Client.Communication
{
    public class ClientCommunication
    {
        private Socket _socket;
        private JsonNetworkSerializer _serializer;

        public void Connect()
        {
            try
            {
                _socket = new Socket(AddressFamily.InterNetwork,
                                         SocketType.Stream,
                                         ProtocolType.Tcp);

                _socket.Connect(
                    IPAddress.Parse(ConfigurationManager.AppSettings["ip"]),
                    int.Parse(ConfigurationManager.AppSettings["port"]));

                _serializer = new JsonNetworkSerializer(
                    new NetworkStream(_socket));
            }
            catch (Exception ex)
            {

                Debug.WriteLine(">>>Connect>>>"+ex.Message );
                throw new ServerCommunicationException("Konekcija sa serverom nije uspela");                   
            }
        }

        public void SendRequest(Request request)
        {
            try
            {
                _serializer.Send(request);
                Response res = _serializer.Receive<Response>();
                if (!res.IsSuccessful)
                    throw new Exception(res.ErrorMessage);
            }
            catch (SocketException ex)
            {
                Debug.WriteLine(">>>SocketExc>>>" + ex.Message);
                throw new ServerCommunicationException("Server not reachable.");
            }
            catch (IOException ex)
            {
                Debug.WriteLine(">>>IOExc>>>" + ex.Message);
                throw new ServerCommunicationException("Connection lost.");
            }
        }
        public T SendRequest<T>(Request request) where T : class
        {
            try
            {
                _serializer.Send(request);
                Response res = _serializer.Receive<Response>();
                if (!res.IsSuccessful)
                    throw new SystemOperationException(res.ErrorMessage);
                return _serializer.ReadType<T>(res.Result);
            }
            catch (SocketException ex)
            {
                Debug.WriteLine(">>>SocketExc>>>" + ex.Message);
                throw new ServerCommunicationException("Server not reachable.");
            }
            catch (IOException ex)
            {
                Debug.WriteLine(">>>IOExc>>>" + ex.Message);
                throw new ServerCommunicationException("Connection lost.");
            }
        }
    }
}
