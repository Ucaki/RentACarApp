using Common.Domain;
using Repository.Connection;
using Repository.Implementation;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            IConnectionFactory factory = new SqlConnectionFactory(ConfigurationManager.ConnectionStrings["RentACar"].ConnectionString);
            IRepository<IEntity> repo = new GenericDbRepository(factory);
            
            //ServerController.Initialize(repo, factory);
            ServerController controller = new ServerController(repo, factory);
            var server = new Server(controller);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmServer(server));
        }
    }
}
