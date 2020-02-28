using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HolidayBookingSystem.UserControls
{
    public partial class EmployeeCalendar : UserControl
    {

        private static EmployeeCalendar _instance;

        public static EmployeeCalendar Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EmployeeCalendar();
                }
                return _instance;
            }
        }

        private EmployeeCalendar()
        {
            InitializeComponent();
            selectedMonthLabel.Text = "Selected Month: " + GeneralUtils.getMonthName(DateTime.Now.Month);
        }


    }

}
