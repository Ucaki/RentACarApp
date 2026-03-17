using Client.Controller;
using Common.Domain;
using Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.GUIController
{
    public class LoginGUIController
    {
        private ClientController _clientController;
        public LoginGUIController(ClientController clientController)
        {
            _clientController = clientController;
        }

        internal Radnik LoginAdmin(string user, string pass)
        {
            try
            {
                Radnik r = new Radnik();
                r.KorisnickoIme = user;
                r.Sifra = pass;
                r = _clientController.Login(r);
                if (r != null) {
                    MessageBox.Show("Uspesno ste se prijavili!");
                    return r;
                }
                return null;
            }
            catch (ServerCommunicationException ex)
            {
                MessageBox.Show(ex.Message);
                _clientController.CloseConnection();
                throw;
                
            }
            catch (SystemOperationException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error");
                Debug.WriteLine(">>>>" + ex.Message);
                return null;
            }

        }
        internal void LogOutAdmin() {
            try
            {
                
                _clientController.LogOut();
                MessageBox.Show("Izlogovali ste se");
            }
            catch (ServerCommunicationException)
            {
                //server je vec diskonektovan i korisnik je automatski odjavljen
            }
            catch (Exception e) {
                MessageBox.Show(e.Message);
            }
        }
    }
}
