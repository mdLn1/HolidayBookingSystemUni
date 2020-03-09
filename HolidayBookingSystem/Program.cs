using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HolidayBookingSystem
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
            DesktopAppUtils.RegisterAdmin();
            //DesktopAppUtils.AddPeakTimes();
            DesktopAppUtils.AddDepartments();
            DesktopAppUtils.AddRoles();
            DesktopAppUtils.CreateUsers();
            DesktopAppUtils.AddHolidayRequests();
            Application.Run(new LoginForm());
        }
    }
}
