using Client.Controller;
using Client.UserControls;
using Common.Domain;
using Common.Exceptions;
using System;
using System.Collections.Generic;
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
        public Action<UserControl> OnPanelChangeRequested { get; internal set; }

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

            _uccar.DgvCars.DataSource= _clientController.FilterCars(new Automobil {FilterQuerry="1=1", Klasa=new KlasaAutomobila()   });
           // _uccar.DgvCars.DataSource = _clientController.FilterCars("1=1");
            _uccar.BtnAddNewCar.Click += BtnAddNewCar_Click;
            _uccar.CmbClassCar.SelectedIndexChanged+= CmbClassCar_SelectedIndexChanged;
            OnPanelChangeRequested?.Invoke(_uccar);
            
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
                var auto = new Automobil();
                if (selectedClass.KlasaID == -1)
                {
                    _uccar.DgvCars.DataSource = _clientController.FilterCars(new Automobil { FilterQuerry = "1=1", Klasa = new KlasaAutomobila() });
                }
                else
                {
                    _uccar.DgvCars.DataSource = _clientController.FilterCars(new Automobil { FilterQuerry = "KlasaVozila.KlasaID="+selectedClass.KlasaID, Klasa = new KlasaAutomobila() });
                }
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
