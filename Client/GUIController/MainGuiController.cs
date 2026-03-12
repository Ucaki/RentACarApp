using Client.UserControls;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.GUIController
{
    public class MainGuiController
    {
        private CarGUIController _carGUIController;
        //private CustomerGUIController _customerGuiController;
        //private RentGUIController _rentGuiController;
        private LoginGUIController _loginGUIController;
        private Action<UserControl> _changePanel;
        public event Action ConnectionLost;
        public MainGuiController(LoginGUIController loginGUIController, CarGUIController CarGUIController, Action<UserControl> changePanel = null)
        {
            _carGUIController = CarGUIController;
            _loginGUIController = loginGUIController;
            _changePanel = changePanel;

            _carGUIController.OnPanelChangeRequested += _changePanel;
            //_customerGuiController.OnPanelChangeRequested += _changePanel;
            //_rentGuiController.OnPanelChangeRequested += _changePanel
        }


        //poziva subscribere(frmMain) da izvrse svoju metodu koju su pretplatili sa UserControl parametrom prosledjuje UC koja se kreira u konkretnom UCGUIControlleru
        internal Radnik Login(string user,string pass)
        {
            try
            {
                return _loginGUIController.LoginAdmin(user, pass);
            }
            catch (Exception)
            {
                ConnectionLost?.Invoke();
                return null;
            }
        }
        internal void LogOut() {
            _loginGUIController.LogOutAdmin();
        }
        internal void ShowCarSection()
        {
            _carGUIController.ShowUCCar();
        }
 
        internal void ShowCustomerSection()
        {
            //_customerGuiController.ShowUCCustomer();
            throw new NotImplementedException();
        }

        

        internal void ShowRentSection()
        {
            //_rentGuiController.ShowUCRent();
            throw new NotImplementedException();
        }
    }
}
