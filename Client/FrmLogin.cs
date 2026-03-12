using Common.Domain;
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
    public partial class FrmLogin : Form
    {
        public Func<string,string,Radnik> onLoginClick;
        public Radnik radnik;
        public event EventHandler ProslediRadnika;
        public FrmLogin()
        {
            InitializeComponent();
        }
        
        public void btnLogin_Click(object sender, EventArgs e) //=> OnLoginRequest?.Invoke();
        {
            string user = txtUsername.Text;
            if (string.IsNullOrEmpty(user)) {
                MessageBox.Show("Niste uneli korisničko ime!");
                return;
            }
            string pass = txtPass.Text;
            if (string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Niste uneli šifru!");
                return;
            }

            radnik = onLoginClick?.Invoke(user,pass);
            if (radnik == null) return;
            DialogResult = DialogResult.OK;
            
            
        }
       
    }
}
