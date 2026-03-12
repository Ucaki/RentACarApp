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

        public bool IsConnected => _socket != null && _socket.Connected;
        public void Connect()
        {

            try
            {
                Close();
                _socket = new Socket(AddressFamily.InterNetwork,
                                            SocketType.Stream,
                                            ProtocolType.Tcp);

                _socket.ReceiveTimeout = 5000;
                _socket.SendTimeout = 5000;

                _socket.Connect(
                    IPAddress.Parse(ConfigurationManager.AppSettings["ip"]),
                    int.Parse(ConfigurationManager.AppSettings["port"]));

                _serializer = new JsonNetworkSerializer(
                    new NetworkStream(_socket));
            }
            catch (SocketException)
            {

                throw new ServerCommunicationException("Server not reachable");
            }

        }
        public void Close()
        {
            try
            {
                _socket?.Shutdown(SocketShutdown.Both);
            }
            catch { }

            try
            {
                _socket?.Close();
            }
            catch { }

            _socket = null;
            _serializer = null;
        }

        public void SendRequest(Request request)
        {
            try
            {
                if (_serializer == null)
                    throw new ServerCommunicationException("Not connected to server");
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
            catch (Exception ex)
            {
                Debug.WriteLine(">>>IOExc>>>" + ex.Message);
                throw new ServerCommunicationException("Connection lost.");
            }
        }
        public T SendRequest<T>(Request request) where T : class
        {
            try
            {
                if (_serializer == null)
                    throw new ServerCommunicationException("Not connected to server");
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
            catch (Exception ex)
            {
                Debug.WriteLine(">>>IOExc>>>" + ex.Message);
                throw new ServerCommunicationException("Connection lost.");
            }
        }
    }
}
