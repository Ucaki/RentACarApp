using Client.Communication;
using Client.Controller;
using Client.GUIController;
using System;
using System.Windows.Forms;

namespace Client
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ClientCommunication communication = new ClientCommunication();
            communication.Connect();                                //communication.Connect(); konekciju stavi kad se loguje.
            ClientController clientController = new ClientController(communication);
            CarGUIController carGUIController = new CarGUIController(clientController);
            FrmMain formMain = new FrmMain();
            MainGuiController mainGuiController = new MainGuiController(carGUIController, (uc)=>formMain.SetUCPanel(uc));

            formMain.OnCarsRequested += mainGuiController.ShowCarSection;
            formMain.OnCustomerRequested += mainGuiController.ShowCustomerSection;
            formMain.OnRentRequested += mainGuiController.ShowRentSection;
            Application.Run(formMain);
        }
    }
}
