using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HolidayBookingSystem
{
    public partial class Dashboard : Form
    {
        Utils utils = new Utils();
        public Dashboard()
        {
            InitializeComponent();
            panel_manage_side.Hide();
        }

        private void btn_manage_Click(object sender, EventArgs e)
        {
            panel_manage_side.Show();
        }

        private void btn_holiday_Click(object sender, EventArgs e)
        {
            panel_manage_side.Hide();
        }

        private void btn_calendar_Click(object sender, EventArgs e)
        {
            panel_manage_side.Hide();
        }

        private void btn_add_employee_Click(object sender, EventArgs e)
        {
            uC_AddUser.Visible = true;
        }
    }
}
