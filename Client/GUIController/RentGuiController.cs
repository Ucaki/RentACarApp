using Client.Controller;
using Client.UserControls;
using Common.Domain;
using Common.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
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
        UCUpdateRent _ucUpdateRent;

        BindingList<Korisnik> listUsers;
        BindingList<StavkaIznajmljivanja> listStavkaIznajmljivanja;
        public Action<UserControl> OnPanelChangeRequested { get; internal set; }

        Iznajmljivanje rent;
        public RentGuiController(ClientController clientController)
        {
            _clientController = clientController;
            listStavkaIznajmljivanja = new BindingList<StavkaIznajmljivanja>();
        }


        internal void ShowUCRent(Radnik r)
        {
            radnik = r;
            _ucRent = new UCRent();
            //get users list and filter
            listUsers = new BindingList<Korisnik>(_clientController.GetAllUsers());
            _ucRent.DgvUser.DataSource = listUsers;
            _ucRent.DgvStavke.DataSource = listStavkaIznajmljivanja;
            _ucRent.TxtName.TextChanged += TxtName_TextChanged;

            //dodaj iznajmljivanje u bazu
            _ucRent.BtnAddRent.Click += BtnAddRent_click;
            //prikazi iznajmljivanja korisnika
            _ucRent.BtnShowUserRents.Click += BtnShowUserRents_click;
            _ucRent.BtnDodajStavku.Click += BtnDodajStavku_click;
            _ucRent.BtnObrisiStavku.Click += BtnObrisiStavku_click;
            _ucRent.TxtPopust.TextChanged += txtPopust_TextChanged;
            listStavkaIznajmljivanja.ListChanged += BindingList_ListChanged;

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
        private void BtnAddRent_click(object sender, EventArgs e)
        {
            try
            {
                Iznajmljivanje iz = new Iznajmljivanje();
                decimal dis = 0;
                if (!decimal.TryParse(_ucRent.TxtPopust.Text, out dis))
                {
                    MessageBox.Show("Popust mora biti broj!");
                    return;
                }

                if (dis < 0 || dis > 100)
                {
                    MessageBox.Show("Popust mora biti između 0 i 100%");
                    return;
                }
                iz.ListaStavki = new List<StavkaIznajmljivanja>(listStavkaIznajmljivanja);
                iz.Popust = (int)dis;
                int sum = 0;
                foreach (StavkaIznajmljivanja item in listStavkaIznajmljivanja) {
                    sum+=item.UkupnaCenaStavke;
                }
                iz.UkupnaCena = sum * (1-dis/100);
                iz.DatumKreiranja = DateTime.Now;
                iz.Korisnik = korisnik;
                iz.Radnik = radnik;

                _clientController.AddRent(iz);
                MessageBox.Show("Uspešno sačuvano iznajmljivanje!");
                listStavkaIznajmljivanja.Clear();
                _ucRent.DateTimePicker.Enabled = true;
                _ucRent.DgvUser.Enabled = true;
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

        private void BtnDodajStavku_click(object sender, EventArgs e)
        {
            StavkaIznajmljivanja si = new StavkaIznajmljivanja();
            automobil = new Automobil() { Klasa=new KlasaAutomobila()};
            si.DatumOd = DateTime.Now;
            if (_ucRent.DateTimePicker.Value.Date <= DateTime.Now.Date)
            {
                MessageBox.Show("Neispravan datum");
                return;
            }
            si.DatumDo = _ucRent.DateTimePicker.Value;
            
            
            si.StatusStavke = StatusIznajmljivanja.aktivno;
            korisnik = (Korisnik)_ucRent.DgvUser.CurrentRow?.DataBoundItem as Korisnik;
            if (korisnik == null)
            {
                MessageBox.Show("Nema izabranih korisnika!");
                return;
            }
            automobil.RegistarskiBroj = _ucRent.TxtRegistration.Text;
            automobil.FilterQuerry = $"RegistarskiBroj='{automobil.RegistarskiBroj}'";
            try
            {
                automobil = _clientController.FilterCars(automobil)[0];
            }
            catch (SystemOperationException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            if (automobil.Status != StatusAutomobila.dostupan) {
                MessageBox.Show("Automobil sa registarskim brojem: "+automobil.RegistarskiBroj+ "nije trenutno dostupan za iznajmljivanje");
                return;
            }
            si.Automobil = automobil;
            si.PocetnaKM = automobil.Kilometraza;
            si.CenaPoDanu = automobil.Klasa.OsnovnaCenaPoDanu;
            si.UkupnaCenaStavke = si.CenaPoDanu * (si.DatumDo - DateTime.Now.Date).Days;

            //si.Automobil=
            //si.Automobil = automobil;
            foreach (var item in listStavkaIznajmljivanja)
            {
                if (item.Automobil.RegistarskiBroj==si.Automobil.RegistarskiBroj)
                {
                    MessageBox.Show("Vec imate stavku sa automobilom registarskih tablica" + si.Automobil.RegistarskiBroj + "!");
                    return;
                } 
            }
            listStavkaIznajmljivanja.Add(si);
            _ucRent.DateTimePicker.Enabled = false;
            _ucRent.DgvUser.Enabled = false;
        }
        private void BtnObrisiStavku_click(object sender, EventArgs e)
        {
            StavkaIznajmljivanja si = (StavkaIznajmljivanja)_ucRent.DgvStavke.CurrentRow?.DataBoundItem;
            if (si == null)
            {
                MessageBox.Show("Nema stavki za brisanje!");
                return;
            }
            listStavkaIznajmljivanja.Remove(si);
            if (listStavkaIznajmljivanja.Count == 0)
            {
                _ucRent.DateTimePicker.Enabled = true;
                _ucRent.DgvUser.Enabled = true;
            }
        }


        private void BindingList_ListChanged(object sender, ListChangedEventArgs e)
        {
            calculator();
        }
        private void txtPopust_TextChanged(object sender, EventArgs e)
        {
            calculator();
        }
        private void calculator()
        {
            decimal popust = 0;
            decimal.TryParse(_ucRent.TxtPopust.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out popust);
            decimal cena = 0;
            if (listStavkaIznajmljivanja.Count == 0) {
                _ucRent.TxtUkupnaCena.Text = cena.ToString();
            }
            foreach (StavkaIznajmljivanja siz in listStavkaIznajmljivanja) {
                cena += siz.UkupnaCenaStavke;
            }
            cena -= (popust / 100) * cena;
            _ucRent.TxtUkupnaCena.Text = cena.ToString();
        }



        //razuzivanje
        private void BtnShowUserRents_click(object sender, EventArgs e)
        {
            _ucUpdateRent = new UCUpdateRent();
            _ucUpdateRent.BtnShowRent.Visible = true;
            _ucUpdateRent.BtnReleaseRentItems.Visible = false;

            korisnik = _ucRent.DgvUser.CurrentRow?.DataBoundItem as Korisnik;

            if (korisnik == null)
            {
                MessageBox.Show("Iznajmljivanja koja odgovaraju zadatoj vrednosti nisu pronadjena!");
                return;
            }
            Iznajmljivanje i = new Iznajmljivanje() { Korisnik = korisnik, Radnik = new Radnik(), ListaStavki=new List<StavkaIznajmljivanja>() };
            BindingList<Iznajmljivanje> listRents = new BindingList<Iznajmljivanje>(_clientController.getListRents(i));
            foreach (var re in listRents) {
                re.Korisnik = korisnik;
                re.Radnik = radnik;
            }
            if (listRents.Count == 0)
            {
                MessageBox.Show("Iznajmljivanja koja odgovaraju zadatoj vrednosti nisu pronadjena!");
                return;
            }
            
            _ucUpdateRent.DgvRentsForUser.DataSource = listRents;
            _ucUpdateRent.BtnShowRent.Click += BtnShowRentItems_click;
            
           _ucUpdateRent.BtnReleaseRentItems.Click += BtnUpdateRent_click;
            OnPanelChangeRequested?.Invoke(_ucUpdateRent);
        }
        private void BtnShowRentItems_click(object sender, EventArgs e) {
            rent = _ucUpdateRent.DgvRentsForUser.CurrentRow?.DataBoundItem as Iznajmljivanje;
            if (rent == null) {
                MessageBox.Show("Sistem ne moze da prikaze stavke iznajmljivanja ili niste odabrali iznajmljivanje!");
                return;
            }

            BindingList<StavkaIznajmljivanja> listItems = new BindingList<StavkaIznajmljivanja>(_clientController.getListRentsItems(rent));
            rent.ListaStavki = new List<StavkaIznajmljivanja>(listItems);
            _ucUpdateRent.DgvRentsForUser.DataSource = listItems;
            _ucUpdateRent.DgvRentsForUser.AllowUserToAddRows = false;
            _ucUpdateRent.DgvRentsForUser.AllowUserToDeleteRows = false;
            _ucUpdateRent.DgvRentsForUser.DataError+= DgvRentsForUser_DataError;
            foreach (DataGridViewColumn col in _ucUpdateRent.DgvRentsForUser.Columns)
            {
                col.ReadOnly = true;
            }
            foreach (DataGridViewRow row in _ucUpdateRent.DgvRentsForUser.Rows) {
                var item = (StavkaIznajmljivanja)row.DataBoundItem;
                if (item.StatusStavke == StatusIznajmljivanja.aktivno) {
                    row.Cells[_ucUpdateRent.DgvRentsForUser.Columns["ZavrsnaKM"].Index].ReadOnly = false;
                }
                else
                    row.DefaultCellStyle.BackColor = Color.LightGray;
            }
            _ucUpdateRent.BtnShowRent.Visible = false;
            _ucUpdateRent.BtnReleaseRentItems.Visible= true;
        }
        private void DgvRentsForUser_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Neispravno uneta zavrsna kilometraza ");

            e.ThrowException = false;

            // Optional: cancel editing so user stays in the cell
            e.Cancel = true;
        }
        private void BtnUpdateRent_click(object sender, EventArgs e)
        {
            _ucUpdateRent.DgvRentsForUser.EndEdit();
            try
            {
                bool check = false;
                rent.StatusIznajmljivanja = StatusIznajmljivanja.zavrseno;
                foreach (StavkaIznajmljivanja item in rent.ListaStavki) {
                    
                   
                    
                    if (item.ZavrsnaKM != null && item.ZavrsnaKM < item.PocetnaKM) {
                        MessageBox.Show("Morate uneti zavrsnu kilometrazu koja je veca od početne!");
                        return;
                    }
                    
                    if (item.ZavrsnaKM != null && item.StatusStavke != StatusIznajmljivanja.zavrseno)
                    {
                        item.DatumDo = DateTime.Now;
                        item.StatusStavke = StatusIznajmljivanja.zavrseno;
                        item.ZavrsnaKM = item.ZavrsnaKM.Value;
                        check = true;
                    }
                    if (item.StatusStavke == StatusIznajmljivanja.aktivno)
                        rent.StatusIznajmljivanja = StatusIznajmljivanja.aktivno;

                }
                if (check)
                {
                    _clientController.ReleaseRent(rent);
                }
                else {
                    MessageBox.Show("Niste izmenili ni jednu stavku");
                    return;
                }
                MessageBox.Show("Stavke iznajmljivanja su uspesno razduzene!");
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
    }
}
//530053 sifra za micin laptop