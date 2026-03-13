using Client.Communication;
using Client.Controller;
using Client.GUIController;
using Common.Domain;
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
            ClientController clientController = new ClientController(communication);
            CarGUIController carGUIController = new CarGUIController(clientController);
            LoginGUIController loginGUIController = new LoginGUIController(clientController);
            CustomerGUIController customerGUIController = new CustomerGUIController(clientController);
            Radnik r;
            while (true)
            {
                
                  using (FrmLogin login = new FrmLogin())
                {
                    MainGuiController mainGuiController = new MainGuiController(loginGUIController, carGUIController, customerGUIController);

                    login.onLoginClick += mainGuiController.Login;
                    if (login.ShowDialog() != DialogResult.OK)
                        break;
                    r=login.radnik;
                }

                using (FrmMain main = new FrmMain(r))
                {
                    MainGuiController mainGuiController = new MainGuiController(loginGUIController, carGUIController, customerGUIController,(uc) => main.SetUCPanel(uc));

                    mainGuiController.ConnectionLost += () =>
                    {
                        main.Close();
                    };

                    main.OnCarsRequested += mainGuiController.ShowCarSection;
                    main.OnCustomerRequested += mainGuiController.ShowCustomerSection;
                    main.OnRentRequested += mainGuiController.ShowRentSection;
                    main.OnLogOutRequested += mainGuiController.LogOut;
                    if (main.ShowDialog() != DialogResult.Retry)
                        break;
                }
            }
        }
    }
}
