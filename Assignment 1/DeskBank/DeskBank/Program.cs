using DeskBank.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeskBank
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

            Employee.Gateway = new EmployeeGateway();
            Client.Gateway = new ClientGateway();
            ClientAccount.Gateway = new ClientAccountGateway();
            EmployeeActivity.Gateway = new EmployeeActivityGateway();

            Application.Run(new LoginForm());
        }
    }
}
