using Client.UserControls;
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
        private Action<UserControl> _changePanel;
        public MainGuiController(CarGUIController CarGUIController, Action<UserControl>changePanel)
        {
            _carGUIController = CarGUIController;
            _changePanel = changePanel;
            _carGUIController.OnPanelChangeRequested += _changePanel;
            //_customerGuiController.OnPanelChangeRequested += _changePanel;
            //_rentGuiController.OnPanelChangeRequested += _changePanel;
        }
        //poziva subscribere(frmMain) da izvrse svoju metodu koju su pretplatili sa UserControl parametrom prosledjuje UC koja se kreira u konkretnom UCGUIControlleru

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
