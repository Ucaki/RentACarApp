using Client.Controller;
using Client.UserControls;
using Common.Domain;
using System;
using System.Collections.Generic;
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
            _uccar.BtnAddNewCar.Click += BtnAddNewCar_Click;
            
            OnPanelChangeRequested?.Invoke(_uccar);
        }

        internal void ShowUCAddCar() {
            _ucAddCar = new UCAddCar();
            _ucAddCar.CmbClassCar.DataSource = _clientController.GetClassCarForCmb();
            //Ovde treba da napunis i kombo box za klasu automobila
            _ucAddCar.BtnSaveCarInDb.Click += BtnSaveCarInDb_Click;
            OnPanelChangeRequested?.Invoke(_ucAddCar);
        }
        private void BtnAddNewCar_Click(object sender, EventArgs e) => ShowUCAddCar();
        private void BtnSaveCarInDb_Click(object sender, EventArgs e)=> SaveCar();
        

        private void SaveCar()
        {
            try
            {
                
                string registration = _ucAddCar.TxtRegistration.Text;
                if (string.IsNullOrEmpty(registration)) {
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
                        RegistarskiBroj=registration,
                        Marka= marka,
                        Model = model,
                        Godiste = year,
                        Klasa = klasa,
                        Status=stat
                    });

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
