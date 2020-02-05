using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HolidayBookingSystem
{
    public partial class UC_EditUser : UserControl
    {
        private static UC_EditUser _instance;

        public static UC_EditUser Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UC_EditUser();
                }
                return _instance;
            }
        }
        public UC_EditUser()
        {
            InitializeComponent();
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {

        }
    }
}
