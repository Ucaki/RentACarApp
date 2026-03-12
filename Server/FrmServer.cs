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
            RefreshDataGridView();
            _server.LoggedInClientsServer += Server_LoggedInClient;
            _server.LoggedOutClientsServer += Server_LoggedOutClient;

            //dgvListClients.DataSource = Session.currentlyLoggedWorkers.Select(client => new
            //{
            //    IME = client.Ime,
            //    PREZIME = client.Prezime,
            //    Username = client.KorisnickoIme
            //})
            //   .ToList(); ;
        }

        private void Server_LoggedInClient(object sender, EventArgs e) {
            Invoke(new Action(RefreshDataGridView));
        }

       

        private void Server_LoggedOutClient(object sender, EventArgs e) {
            Invoke(new Action(RefreshDataGridView));
        }
        private void RefreshDataGridView()
        {

            var clientInfoList = Session.currentlyLoggedWorkers
                .Select(client => new
                {
                    IME = client.Ime,
                    PREZIME = client.Prezime,
                    Username = client.KorisnickoIme                   
                })
                .ToList();
             
            dgvListClients.DataSource = null;
            dgvListClients.DataSource = clientInfoList;
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
