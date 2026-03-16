using Client.Controller;
using Client.UserControls;
using Common.Domain;
using Common.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
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
        UCUpdateRent _ucUpdateRent;
        BindingList<Automobil> listCars;
        BindingList<Korisnik> listUsers;
        BindingList<Iznajmljivanje> listRents;
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
            _ucRent.BtnShowUserRents.Click += BtnShowUserRents_click;


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

        private void BtnAddRent_click(object sender, EventArgs e)
        {
            _ucAddRent = new UCAddRent();
            
            korisnik = (Korisnik)_ucRent.DgvUser.CurrentRow?.DataBoundItem as Korisnik;
            if (korisnik == null)
            {
                MessageBox.Show("Nema izabranih korisnika!");
                return;
            }
            automobil = (Automobil)_ucRent.DgvCar.CurrentRow?.DataBoundItem as Automobil;
            if (automobil == null)
            {
                MessageBox.Show("Nema izabranih korisnika!");
                return;
            }
            if (korisnik == null || automobil == null)
            {
                MessageBox.Show("Niste odabrali");
                return;
            }
            _ucAddRent.TxtUser.Text = korisnik.Ime + ", " + korisnik.Prezime + ", " + korisnik.Email;
            _ucAddRent.TxtCar.Text = automobil.Marka + ", " + automobil.Model + ", " + automobil.RegistarskiBroj;
            _ucAddRent.TxtKm.Text = automobil.Kilometraza.ToString();

            //   decimal dis = 0;
            //if (!decimal.TryParse(_ucAddRent.TxtDiscount.Text, out dis))
            //{
            //    MessageBox.Show("Popust mora biti broj!");
            //    return ;
            //}

            //if (dis < 0 || dis > 100)
            //{
            //    MessageBox.Show("Popust mora biti između 0 i 100%");
            //    return ;
            //}
            _ucAddRent.TxtDiscount.TextChanged += txtPopust_TextChanged;
            _ucAddRent.DateTimePicker.ValueChanged += dateTimePickerDo_ValueChanged;
            _ucAddRent.BtnSaveRent.Click += buttonSaveRent_click;
           // _ucAddRent.BtnDodajIznajmljivanjeUListu.Click += buttonDodajULustu_click;
            OnPanelChangeRequested?.Invoke(_ucAddRent);
        }


/*
        private void buttonDodajULustu_click(object sender, EventArgs e) {

            try
            {
                calculator();
                Iznajmljivanje rent = new Iznajmljivanje();
                rent.Status = StatusIznajmljivanja.aktivno;
                rent.DatumOd = DateTime.Now;
                if (_ucAddRent.DateTimePicker.Value < DateTime.Now)
                {
                    MessageBox.Show("Neispravcan datum");
                    return;
                }
                rent.DatumDo = _ucAddRent.DateTimePicker.Value;
                rent.PocetnaKM = automobil.Kilometraza;
                decimal dis = 0;
                if (!decimal.TryParse(_ucAddRent.TxtDiscount.Text, out dis))
                {
                    MessageBox.Show("Popust mora biti broj!");
                    return;
                }

                if (dis < 0 || dis > 100)
                {
                    MessageBox.Show("Popust mora biti između 0 i 100%");
                    return;
                }
                calculator();
                rent.Popust = (int)dis;
                decimal brojDecimal;
                if (decimal.TryParse(_ucAddRent.TxtUgovorenaCena.Text, out brojDecimal))
                {
                    rent.UgovorenaCena = brojDecimal;
                }
                //decimal brojDecimal;
                //if (decimal.TryParse(_ucAddRent.TxtUgovorenaCena.Text, out brojDecimal))
                //{ MessageBox.Show("Test"); }
                //rent.UgovorenaCena = brojDecimal;
                rent.Korisnik = korisnik;
                automobil.FilterQuerry = $"AutomobilID = {automobil.AutomobilID}";
                automobil = _clientController.FilterCars(automobil)[0];
                if (automobil.Status == StatusAutomobila.dostupan)
                {
                    rent.Automobil = automobil;
                }
                else
                {
                    MessageBox.Show("Sistem ne moze da zapamti novo iznajmljivanje!");
                    return;
                }
                rent.Radnik = radnik;
                //
                ////
                /////
                /////rent = _clientController.AddRent(rent);
                // MessageBox.Show("Sistem zapamtio novo iznajmljivanje");

                listRents.Add(rent);
                _ucAddRent.DgvListRents.DataSource = listRents;
                OnPanelChangeRequested?.Invoke(_ucRent);
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
        }*/
        private void buttonSaveRent_click(object sender, EventArgs e)
        {
            try
            {
                Iznajmljivanje iz = new Iznajmljivanje();
                // OVDE POPUNI IZNAJMLJIVANJE IZ FORME
                _clientController.AddRent(iz);
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

        private void dateTimePickerDo_ValueChanged(object sender, EventArgs e)
        {
            calculator();
        }
        private void txtPopust_TextChanged(object sender, EventArgs e)
        {
            calculator();
        }
        private void calculator()
        {
            int days = (_ucAddRent.DateTimePicker.Value - DateTime.Now.Date).Days;
            //decimal popust = 0;
            //decimal.TryParse(_ucAddRent.TxtDiscount.Text, out popust);
            decimal popust = 0;
            decimal.TryParse(_ucAddRent.TxtDiscount.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out popust);
            decimal cena = automobil.Klasa.OsnovnaCenaPoDanu * days;
            cena -= (popust / 100) * cena;
            _ucAddRent.TxtUgovorenaCena.Text = cena.ToString();

        }



        //razuzivanje
        private void BtnShowUserRents_click(object sender, EventArgs e)
        {
            _ucUpdateRent = new UCUpdateRent();
            korisnik = _ucRent.DgvUser.CurrentRow?.DataBoundItem as Korisnik;

            if (korisnik == null)
            {
                MessageBox.Show("Iznajmljivanja koja odgovaraju zadatoj vrednosti nisu pronadjena!");
                return;
            }
            Iznajmljivanje i = new Iznajmljivanje() { Korisnik = korisnik, Radnik = new Radnik(), Automobil = new Automobil() { Klasa = new KlasaAutomobila() } };
            listRents = new BindingList<Iznajmljivanje>(_clientController.getListRents(i));
            if (listRents.Count == 0) {
                MessageBox.Show("Iznajmljivanja koja odgovaraju zadatoj vrednosti nisu pronadjena!");
                return;
            }
            foreach (Iznajmljivanje izn in listRents)
            {
                izn.Korisnik = korisnik;
                izn.Radnik = radnik;
                izn.Automobil.FilterQuerry = "automobilID=" + izn.Automobil.AutomobilID;
                izn.Automobil = _clientController.FilterCars(izn.Automobil)[0];
            }
            _ucUpdateRent.DgvRentsForUser.DataSource = listRents;
            _ucUpdateRent.BtnUpdateRent.Click += BtnUpdateRent_click;
            OnPanelChangeRequested?.Invoke(_ucUpdateRent);
        }

        private void BtnUpdateRent_click(object sender, EventArgs e)
        {
            try
            {
                Iznajmljivanje iznajmljivanjeZaRazduzivanje = _ucUpdateRent.DgvRentsForUser.CurrentRow?.DataBoundItem as Iznajmljivanje;
               

                if (iznajmljivanjeZaRazduzivanje == null)
                {
                    MessageBox.Show("Sistem ne moze da razduzi iznajmljivanje!");
                    return;
                }
                if (iznajmljivanjeZaRazduzivanje.Status == StatusIznajmljivanja.zavrseno) {
                    MessageBox.Show("Sistem ne moze da razduzi iznajmljivanje!");
                    return;
                }
                int km;
                if (string.IsNullOrEmpty(_ucUpdateRent.TxtKm.Text)) {
                    MessageBox.Show("Niste uneli zavrsnu kilometrazu");
                    return;
                }
                int broj;

                if (!int.TryParse(_ucUpdateRent.TxtKm.Text, out broj))
                {
                    MessageBox.Show("Unesite ispravan broj!");
                    return;
                }
                else if (broj < iznajmljivanjeZaRazduzivanje.Automobil.Kilometraza) 
                {
                    MessageBox.Show("Mora da bude veca km nego pocetna");
                    return;
                }
                iznajmljivanjeZaRazduzivanje.ZavrsnaKM = broj;
                iznajmljivanjeZaRazduzivanje.DatumDo = DateTime.Now.Date;
                
                _clientController.ReleaseRent(iznajmljivanjeZaRazduzivanje);
                MessageBox.Show("Iznajmljivanje je uspesno razduzeno!");
                listRents.Clear();
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
    }
}
