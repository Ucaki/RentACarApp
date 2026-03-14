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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.GUIController
{
    public class RentGuiController
    {
        private ClientController _clientController;

        Korisnik korisnik;
        Automobil automobil;
        Radnik radnik;
        UCRent _ucRent;
        UCAddRent _ucAddRent;
        UCUpdateRent _uCUpdateRent;
        BindingList<Automobil> listCars;
        BindingList<Korisnik> listUsers;
        public Action<UserControl> OnPanelChangeRequested { get; internal set; }
        public RentGuiController(ClientController clientController)
        {
            _clientController = clientController;
        }

        internal void ShowUCRent(Radnik r)
        {
            radnik = r;
            _ucRent = new UCRent();

            List<KlasaAutomobila> classes = _clientController.GetClassCarForCmb();
            classes.Insert(0, new KlasaAutomobila { KlasaID = -1, Naziv = "All" });
            _ucRent.CmbClassCar.DataSource = classes;


            listUsers = new BindingList<Korisnik>(_clientController.GetAllUsers());
            _ucRent.DgvUser.DataSource = listUsers;
            _ucRent.TxtName.TextChanged += TxtName_TextChanged;


            listCars = new BindingList<Automobil>(_clientController.FilterCars(new Automobil { FilterQuerry = "1=1", Klasa = new KlasaAutomobila() }));
            _ucRent.DgvCar.DataSource = listCars;
            _ucRent.CmbClassCar.SelectedIndexChanged += CmbClassCar_SelectedIndexChanged;

            _ucRent.BtnAddRent.Click += BtnAddRent_click;
            //_ucRent.BtnShowUserRents+=


            OnPanelChangeRequested?.Invoke(_ucRent);
        }
        //dgvUsers + filter
        private void TxtName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                List<Korisnik> l = new List<Korisnik>();
                string filter = _ucRent.TxtName.Text;
                if (filter.Length > 0)
                {
                    Korisnik k = new Korisnik();
                    k.filter = $"Korisnik.ime like '{filter}%'";
                    k.Mesto = new Mesto();
                    //string fileterCondition = $"Korisnik.ime like '{filter}%'";
                    l = _clientController.GetFilteredUsers(k);
                }
                else
                {
                    l = _clientController.GetAllUsers();
                }
                listUsers.Clear();
                foreach (var k in l)
                {
                    listUsers.Add(k);
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
                _ucRent.TxtName.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error");
                Debug.WriteLine(">>>>" + ex.Message);
            }
        }

        //dgvCars + filter
        private void CmbClassCar_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var selectedClass = (KlasaAutomobila)_ucRent.CmbClassCar.SelectedItem;
                List<Automobil> updatedList;
                if (selectedClass.KlasaID == -1)
                {
                    updatedList = _clientController.FilterCars(new Automobil { FilterQuerry = "1=1", Klasa = new KlasaAutomobila() });
                }
                else
                {
                    updatedList = _clientController.FilterCars(new Automobil { FilterQuerry = "KlasaVozila.KlasaID=" + selectedClass.KlasaID, Klasa = new KlasaAutomobila() });
                }
                listCars.Clear();
                foreach (var car in updatedList)
                {
                    listCars.Add(car);
                }

            }
            catch (SystemOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (ServerCommunicationException ex)
            {
                MessageBox.Show(ex.Message);
                _clientController.CloseConnection();
                Form main = Application.OpenForms["FrmMain"];
                main.DialogResult = DialogResult.Retry;

            }
        }

        private void BtnAddRent_click(object sender, EventArgs e) {
            _ucAddRent = new UCAddRent();
            korisnik = (Korisnik)_ucRent.DgvUser.CurrentRow.DataBoundItem;
            automobil = (Automobil)_ucRent.DgvCar.CurrentRow.DataBoundItem;
            if (korisnik == null || automobil == null)
            {
                MessageBox.Show("Niste odabrali");
                return;
            }
            OnPanelChangeRequested?.Invoke(_ucAddRent);
        }
    }
}
