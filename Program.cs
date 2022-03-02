using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeManagementSystem
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
            Application.Run(new Login());
            //Application.Run(new frmEmployee());
            //Application.Run(new frmDepartment());
            //Application.Run(new frmSalary());
            //Application.Run(new frmQualification());
            //Application.Run(new frmPayroll());
            //Application.Run(new MainPortal());
            

        }
    }
}
