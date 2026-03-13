using Client.Controller;
using Client.UserControls;
using Common.Domain;
using Common.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.GUIController
{
    public class CustomerGUIController
    {
        private ClientController _clientController;
        private Korisnik korisnik;
        private UCCustomer _ucCustomer;
        private UCShowCustomer _ucShowCustomer;
        private UCAddCustomer _ucAddCustomer;
        private BindingList<Korisnik> listUser;
       

        public CustomerGUIController(ClientController clientController)
        {
            _clientController = clientController;
        }

        public Action<UserControl> OnPanelChangeRequested { get; internal set; }
        //private UCAddCar _ucAddCar;

        internal void ShowUCCustomer()
        {
            _ucCustomer = new UCCustomer();
            listUser = new BindingList<Korisnik>(_clientController.GetAllUsers());
            _ucCustomer.DataGridView.DataSource = listUser;

            _ucCustomer.TxtName.TextChanged += TxtName_TextChanged;
            _ucCustomer.BtnShowUser.Click += BtnShowUser_click;
            _ucCustomer.BtnCreateNewUser.Click += BtnCreateUser_click;


            OnPanelChangeRequested?.Invoke(_ucCustomer);
        }

        private void BtnCreateUser_click(object sender, EventArgs e) => ShowUcSaveCustomer();
        private void BtnShowUser_click(object sender, EventArgs e) => ShowUCShowCustomer();

        private void ShowUcSaveCustomer()
        {
            _ucAddCustomer = new UCAddCustomer();
            _ucAddCustomer.CmbPlaces.DataSource = _clientController.GetAllPlaces();
            //_ucShowCar.CmbClassCar.DataSource = GetClassCarForCmb();
            //_ucShowCar.CmbClassCar.DisplayMember = "Naziv";
            //_ucShowCar.CmbClassCar.ValueMember = "KlasaID";
            //_ucShowCar.CmbClassCar.SelectedValue = auto.Klasa.KlasaID;

            _ucAddCustomer.BtnSaveCustomer.Click += BtnSaveCustomer_click;
            OnPanelChangeRequested?.Invoke(_ucAddCustomer);
        }

        private void BtnSaveCustomer_click(object sender, EventArgs e) => SaveCustomer();

        private void SaveCustomer()
        {
            try
            {
                korisnik = new Korisnik()
                {
                    Ime = _ucAddCustomer.TxtIme.Text,
                    Prezime = _ucAddCustomer.TxtPrezime.Text,
                    Email = _ucAddCustomer.TxtEmail.Text,
                    Adresa = _ucAddCustomer.TxtAdresa.Text,
                    Mesto = (Mesto)_ucAddCustomer.CmbPlaces.SelectedItem

                };
                if (string.IsNullOrEmpty(korisnik.Ime))
                {
                    MessageBox.Show("Niste uneli polje Ime");
                    return;
                }
                if (string.IsNullOrEmpty(korisnik.Prezime))
                {
                    MessageBox.Show("Niste uneli polje Prezime");
                    return;
                }
                if (string.IsNullOrEmpty(korisnik.Email))
                {
                    MessageBox.Show("Niste uneli polje email");
                    return;
                }
                if (string.IsNullOrEmpty(korisnik.Adresa))
                {
                    MessageBox.Show("Niste uneli polje Adresu");
                    return;
                }

                korisnik = _clientController.AddCustomer(korisnik);
                MessageBox.Show("Sistem je zapamtio novog korisnika!");


                listUser.Add(korisnik);
                OnPanelChangeRequested?.Invoke(_ucCustomer);

            }
            catch (ServerCommunicationException ex)
            {
                MessageBox.Show(ex.Message);
                _clientController.CloseConnection();
                Form main = Application.OpenForms["FrmMain"];
                main.DialogResult = DialogResult.Retry;

            }
            catch (SystemOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error");
                Debug.WriteLine(">>>>" + ex.Message);
            }
        }

        private void ShowUCShowCustomer()
        {
            korisnik = new Korisnik();
            korisnik = (Korisnik)_ucCustomer.DataGridView.CurrentRow.DataBoundItem;
            _ucShowCustomer = new UCShowCustomer();
            _ucShowCustomer.TxtIme.Text = korisnik.Ime;
            _ucShowCustomer.TxtPrezime.Text = korisnik.Prezime;
            _ucShowCustomer.TxtEmail.Text = korisnik.Email;
            _ucShowCustomer.TxtAdresa.Text = korisnik.Adresa;
            _ucShowCustomer.TxtMesto.Text = korisnik.Mesto.Naziv;
            OnPanelChangeRequested?.Invoke(_ucShowCustomer);
            _ucShowCustomer.BtnGoBack.Click += GoBack_click;
        }
        private void GoBack_click(object sender, EventArgs e)=> OnPanelChangeRequested?.Invoke(_ucCustomer);
        private void TxtName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                List<Korisnik> l = new List<Korisnik>();
                string filter = _ucCustomer.TxtName.Text;
                if (filter.Length > 0)
                {
                    Korisnik k = new Korisnik();
                    k.filter= $"Korisnik.ime like '{filter}%'";
                    k.Mesto = new Mesto();
                    //string fileterCondition = $"Korisnik.ime like '{filter}%'";
                    l = _clientController.GetFilteredUsers(k);
                }
                else {
                    l = _clientController.GetAllUsers();
                }
                listUser.Clear();
                foreach (var k in l) {
                    listUser.Add(k);
                }
            }
            catch (ServerCommunicationException ex)
            {
                MessageBox.Show(ex.Message);
                _clientController.CloseConnection();
                Form main = Application.OpenForms["FrmMain"];
                main.DialogResult = DialogResult.Retry;

            }
            catch (SystemOperationException ex)
            {
                MessageBox.Show(ex.Message);
                _ucCustomer.TxtName.Text="";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error");
                Debug.WriteLine(">>>>" + ex.Message);
            }
        }
    }
}
