using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class FrmServer : Form
    {
        private Server _server;
        public FrmServer(Server server)
        {
            InitializeComponent();
            _server = server;
            btnStartServer.Enabled = true;
            btnStopServer.Enabled = false;
            dgvListClients.DataSource = _server._clientsList;
            _server.LoggedInClientsServer += Server_LoggedInClient;
            _server.LoggedOutClientsServer += Server_LoggedOutClient;
        }

        private void Server_LoggedInClient(object sender, EventArgs e) {
            Invoke(new Action(RefreshDataGridView));
        }

       

        private void Server_LoggedOutClient(object sender, EventArgs e) {
            Invoke(new Action(RefreshDataGridView));
        }
        private void RefreshDataGridView()
        {
            //add administrator object on clientHandler, so that you can fill list into dgv with proper data when you create common.Admin
            /*
             var clientInfoList = server.clients
                .Select(client => new
                {
                    IME = client._admin.Name,
                    PREZIME = client._admin.LastName,
                    User_NAME = client._admin.UserName                   
                })
                .ToList();
             */
            dgvListClients.DataSource = null;
            dgvListClients.DataSource = _server._clientsList;
        }

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            _server.Start();

            Thread acceptClientThread = new Thread(_server.Listen);
            acceptClientThread.IsBackground = true;
            acceptClientThread.Start();

            btnStartServer.Enabled = false;
            btnStopServer.Enabled = true;
        }

        private void btnStopServer_Click(object sender, EventArgs e)
        {
            _server.Stop();
            
            btnStartServer.Enabled = true;
            btnStopServer.Enabled = false;
        }
    }
}
