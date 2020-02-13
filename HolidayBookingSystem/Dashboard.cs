using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HBSDatabase;

namespace HolidayBookingSystem
{
    public partial class Dashboard : Form
    {
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
            panel_main.Hide();
        }

        private void btn_calendar_Click(object sender, EventArgs e)
        {
            panel_manage_side.Hide();
            panel_main.Hide();
        }

        private void btn_add_employee_Click(object sender, EventArgs e)
        {
            if (!panel_main.Controls.Contains(UC_AddUser.Instance))
            {
                panel_main.Controls.Add(UC_AddUser.Instance);
                UC_AddUser.Instance.Dock = DockStyle.Fill;
                UC_AddUser.Instance.BringToFront();
            }
            else
            {
                UC_AddUser.Instance.BringToFront();
                UC_AddUser.Instance.initialiseForm();
            }
        }

        private void btn_delete_employee_Click(object sender, EventArgs e)
        {
            if (!panel_main.Controls.Contains(UC_DeleteUser.Instance))
            {
                panel_main.Controls.Add(UC_DeleteUser.Instance);
                UC_DeleteUser.Instance.Dock = DockStyle.Fill;
                UC_DeleteUser.Instance.BringToFront();
                UC_DeleteUser.Instance.initializeUserList();
            }
            else
            {
                UC_DeleteUser.Instance.BringToFront();
                UC_DeleteUser.Instance.initializeUserList();
            }
        }

        private void btn_edit_employee_Click(object sender, EventArgs e)
        {
            if (!panel_main.Controls.Contains(UC_EditUser.Instance))
            {
                panel_main.Controls.Add(UC_EditUser.Instance);
                UC_EditUser.Instance.Dock = DockStyle.Fill;
                UC_EditUser.Instance.BringToFront();
                UC_EditUser.Instance.initializeUserList();
            }
            else
            {
                UC_EditUser.Instance.BringToFront();
                UC_EditUser.Instance.initializeUserList();
            }
        }
    }
}
