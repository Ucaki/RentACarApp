using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    public class Server
    {
        private ServerController _controller;
        private Socket _socket;
        internal List<ClientHandler> _clientsList;
        public event EventHandler LoggedInClientsServer;
        public event EventHandler LoggedOutClientsServer;
        bool _running;
        public Server(ServerController controller)
        {
            this._controller = controller;
            _clientsList = new List<ClientHandler>();
            _running = true;
        }

        internal void Start()
        {
            try
            {
                _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                _socket.Bind(new IPEndPoint(IPAddress.Parse(ConfigurationManager.AppSettings["ip"]), int.Parse(ConfigurationManager.AppSettings["port"])));
                _socket.Listen(100);

               
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>" + ex.Message);
            }
        }
        internal void Listen()
        {
            try
            {
                while (_running)
                {
                    Socket clientSocket = _socket.Accept();
                    ClientHandler ch = new ClientHandler(clientSocket, _controller);
                    //_clientsList.Add(ch);
                    ch.LoggedInClient += handle_LoggedInClient;
                    ch.LoggedOutClient += handle_LoggedOutClient;

                    Thread clientThread = new Thread(ch.HandleRequest);
                    clientThread.IsBackground = true;
                    clientThread.Start();

                }
            }
            catch (SocketException se)
            {
                Debug.WriteLine(">>>" + se.Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        private readonly object _clientListLockObj = new object();
        public void handle_LoggedInClient(object sender, EventArgs e) {
            lock (_clientListLockObj)
            {
                _clientsList.Add((ClientHandler)sender);
            }
            LoggedInClientsServer?.Invoke(sender, EventArgs.Empty);
        }
        public void handle_LoggedOutClient(object sender, EventArgs e) {
            lock (_clientListLockObj)
            {
                _clientsList.Remove((ClientHandler)sender);
            }
            LoggedOutClientsServer?.Invoke(sender, EventArgs.Empty);
        }
        internal void Stop()
        {
            _running = false;
            _socket?.Close();
            lock (_clientListLockObj) {
                foreach (ClientHandler ch in _clientsList) {
                    ch.Stop();
                }
                _clientsList.Clear();
            }
                
        }
    }
}
