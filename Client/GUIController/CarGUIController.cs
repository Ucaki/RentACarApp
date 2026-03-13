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
    public class CarGUIController
    {
        private ClientController _clientController;
        private UCCar _uccar;
        private UCAddCar _ucAddCar;
        private UCShowCar _ucShowCar;
        private Automobil auto;
        public Action<UserControl> OnPanelChangeRequested { get; internal set; }
        BindingList<Automobil> listCars;

        public CarGUIController(ClientController clientController)
        {
            _clientController = clientController; 
        }


        internal void ShowUCCar()
        {
            _uccar = new UCCar();
            List<KlasaAutomobila> classes = GetClassCarForCmb();
            classes.Insert(0, new KlasaAutomobila { KlasaID = -1, Naziv = "All" });
            _uccar.CmbClassCar.DataSource = classes;

            listCars = new BindingList<Automobil>(_clientController.FilterCars(new Automobil { FilterQuerry = "1=1", Klasa = new KlasaAutomobila() }));
            _uccar.DgvCars.DataSource = listCars;
            
            _uccar.BtnAddNewCar.Click += BtnAddNewCar_Click;
            
            _uccar.CmbClassCar.SelectedIndexChanged+= CmbClassCar_SelectedIndexChanged;
            _uccar.BtnShowCar.Click += BtnShowCar_Click;
            OnPanelChangeRequested?.Invoke(_uccar);
            
        }

        private void BtnShowCar_Click(object sender, EventArgs e)
        {
            auto = (Automobil)_uccar.DgvCars.CurrentRow.DataBoundItem;

            _ucShowCar = new UCShowCar();
            _ucShowCar.TxtRegistration.Text = auto.RegistarskiBroj;
            _ucShowCar.TxtBrand.Text = auto.Marka;
            _ucShowCar.TxtModel.Text = auto.Model;
            _ucShowCar.NumUpDownYearProduction.Value = auto.Godiste;

            _ucShowCar.CmbClassCar.DataSource= GetClassCarForCmb();
            _ucShowCar.CmbClassCar.DisplayMember = "Naziv";
            _ucShowCar.CmbClassCar.ValueMember = "KlasaID";
            _ucShowCar.CmbClassCar.SelectedValue = auto.Klasa.KlasaID;

            _ucShowCar.CmbStatus.DataSource = Enum.GetValues(typeof(StatusAutomobila));
            _ucShowCar.CmbStatus.SelectedItem = auto.Status;

            OnPanelChangeRequested?.Invoke(_ucShowCar);

            _ucShowCar.BtnDeleteCar.Click += DeleteSelectedCar;
            _ucShowCar.BtnUpdate.Click += UpdateSelectedCar;
        }

        private void UpdateSelectedCar(object sender, EventArgs e)
        {
            //try
            //{
            //    Automobil a = new Automobil();
            //    a.AutomobilID = auto.AutomobilID;
            //    a.RegistarskiBroj = _ucShowCar.TxtRegistration.Text;
            //    a.Marka = _ucShowCar.TxtBrand.Text;
            //    a.Model = _ucShowCar.TxtModel.Text;
            //    a.Godiste = (int)_ucShowCar.NumUpDownYearProduction.Value;
            //    a.Klasa = (KlasaAutomobila)_ucShowCar.CmbClassCar.SelectedItem;
            //    a.Status = (StatusAutomobila)_ucShowCar.CmbStatus.SelectedItem;
            //    if (!a.Equals(auto))
            //    {
            //        _clientController.UpdateCar(a);
            //        MessageBox.Show("Vozilo obrisano!");
            //    }
            //    else
            //        MessageBox.Show("Ne mozete da brišete izmenjen automobil. Update ili obrišite neizmenjen objekat!");
            //}
            //catch (ServerCommunicationException ex)
            //{
            //    MessageBox.Show(ex.Message);
            //    _clientController.CloseConnection();
            //    Form main = Application.OpenForms["FrmMain"];
            //    main.DialogResult = DialogResult.Retry;

            //}
            //catch (SystemOperationException ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Unexpected error");
            //    Debug.WriteLine(">>>>" + ex.Message);
            //}
        }

        private void DeleteSelectedCar(object sender, EventArgs e)
        {
            try
            {
                Automobil a = new Automobil();
                a.AutomobilID = auto.AutomobilID;
                a.RegistarskiBroj = _ucShowCar.TxtRegistration.Text;
                a.Marka = _ucShowCar.TxtBrand.Text;
                a.Model = _ucShowCar.TxtModel.Text;
                a.Godiste = (int)_ucShowCar.NumUpDownYearProduction.Value;
                a.Klasa = (KlasaAutomobila)_ucShowCar.CmbClassCar.SelectedItem;
                a.Status = (StatusAutomobila)_ucShowCar.CmbStatus.SelectedItem;
                if (a.Equals(auto))
                {
                    _clientController.DeleteCar(a);
                    MessageBox.Show("Vozilo obrisano!");
                }
                else
                    MessageBox.Show("Ne mozete da brišete izmenjen automobil. Update ili obrišite neizmenjen objekat!");
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
        
        internal void ShowUCAddCar()
        {
            //_ucAddCar.CmbClassCar.DataSource = new BindingList<KlasaAutomobila>(GetClassCarForCmb());
            //_ucAddCar.CmbClassCar.DisplayMember = "Naziv";
            //_ucAddCar.CmbClassCar.ValueMember = "KlasaID";
            _ucAddCar = new UCAddCar();
            _ucAddCar.CmbClassCar.DataSource = GetClassCarForCmb();
            _ucAddCar.BtnSaveCarInDb.Click += BtnSaveCarInDb_Click;
            OnPanelChangeRequested?.Invoke(_ucAddCar);
        }
        private void CmbClassCar_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var selectedClass = (KlasaAutomobila)_uccar.CmbClassCar.SelectedItem;
                List<Automobil> updatedList;
                if (selectedClass.KlasaID == -1)
                {
                    updatedList = _clientController.FilterCars(new Automobil { FilterQuerry = "1=1", Klasa = new KlasaAutomobila() });
                }
                else
                {
                    updatedList = _clientController.FilterCars(new Automobil { FilterQuerry = "KlasaVozila.KlasaID=" + selectedClass.KlasaID, Klasa = new KlasaAutomobila()});
                }
                listCars.Clear();
                foreach (var car in updatedList) {
                    listCars.Add(car);
                }
                
            }
            catch (SystemOperationException ex) {
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
        private void BtnAddNewCar_Click(object sender, EventArgs e) => ShowUCAddCar();
        private void BtnSaveCarInDb_Click(object sender, EventArgs e) => SaveCar();

        public List<KlasaAutomobila> GetClassCarForCmb()
        {
            try
            {
                return _clientController.GetClassCarForCmb();
            }
            catch (ServerCommunicationException ex)
            {
                MessageBox.Show(ex.Message);
                _clientController.CloseConnection();
                Form main = Application.OpenForms["FrmMain"];
                main.DialogResult = DialogResult.Retry;
                return null;
            }
        }
        private void SaveCar()
        {
            try
            {

                string registration = _ucAddCar.TxtRegistration.Text;
                if (string.IsNullOrEmpty(registration))
                {
                    MessageBox.Show("Niste uneli polje registracija");
                    return;
                }
                if (!Regex.IsMatch(registration, @"^[A-Za-z]{2}\d{3,4}[A-Za-z]{2}$"))
                {
                    MessageBox.Show("Niste uneli ispravno registraciju");
                    return;
                }
                string marka = _ucAddCar.TxtBrand.Text;
                if (string.IsNullOrEmpty(marka))
                {
                    MessageBox.Show("Niste uneli polje marka");
                    return;
                }
                string model = _ucAddCar.TxtModel.Text;
                if (string.IsNullOrEmpty(model))
                {
                    MessageBox.Show("Niste uneli polje model");
                    return;
                }
                int year = (int)_ucAddCar.NumUpDownYearProduction.Value;
                KlasaAutomobila klasa = (KlasaAutomobila)_ucAddCar.CmbClassCar.SelectedItem;
                StatusAutomobila stat = StatusAutomobila.dostupan;
                Automobil newAutomobil = _clientController.AddCar(
                    new Automobil()
                    {
                        RegistarskiBroj = registration,
                        Marka = marka,
                        Model = model,
                        Godiste = year,
                        Klasa = klasa,
                        Status = stat
                    });
                MessageBox.Show("Uspešno ste sačuvali novo vozilo!");
                listCars.Add(newAutomobil);
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
