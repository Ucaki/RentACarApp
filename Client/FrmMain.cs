using Client.GUIController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class FrmMain : Form
    {
        public event Action OnCarsRequested;
        public event Action OnCustomerRequested;
        public event Action OnRentRequested;
        public FrmMain()
        {
            InitializeComponent();
        }
        public void SetUCPanel(UserControl uc) {
            panelContent.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelContent.Controls.Add(uc);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            StatusLabelDateTime.Text = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
        }

        private void btnCars_Click(object sender, EventArgs e) => OnCarsRequested?.Invoke();
        private void btnCustomers_Click(object sender, EventArgs e) => OnCustomerRequested?.Invoke();
        private void btnRentals_Click(object sender, EventArgs e) => OnRentRequested?.Invoke();

    }
}
