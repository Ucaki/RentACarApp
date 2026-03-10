using Common.Communication;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
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

                Debug.WriteLine("Connect>>>"+ex.Message );
                //throw new SocketException("Konekcija sa serverom nije uspela"); //ServerCommunicationExceptio("Konekcija sa serverom nije uspela") -> napravim ga sam, proveri da li treba i zasto
                    
            }
        }

        public void SendRequest(Request request)
        {
            _serializer.Send(request);
            Response res = _serializer.Receive<Response>();
            if (!res.IsSuccessful)
                throw new Exception(res.ErrorMessage);
        }
        public T SendRequest<T>(Request request) where T : class
        {
            _serializer.Send(request);
            Response res = _serializer.Receive<Response>();
            if (!res.IsSuccessful)
                throw new Exception(res.ErrorMessage);
            return _serializer.ReadType<T>(res.Result);
        }
    }
}
