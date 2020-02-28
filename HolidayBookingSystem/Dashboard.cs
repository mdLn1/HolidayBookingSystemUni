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
using HolidayBookingSystem.UserControls;

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
            panel_holiday_requests.Hide();
            panel_calendar_view.Hide();
            panel_manage_employee.Show();
            panel_manage_employee.Location = new Point(1,0);
            panel_main.Show();
        }

        private void btn_holiday_Click(object sender, EventArgs e)
        {
            panel_manage_side.Show();
            panel_manage_employee.Hide();
            panel_calendar_view.Hide();
            panel_holiday_requests.Show();
            panel_holiday_requests.Location = new Point(1, 0);
            panel_main.Show();
        }

        private void btn_calendar_Click(object sender, EventArgs e)
        {
            panel_manage_side.Show();
            panel_holiday_requests.Hide();
            panel_manage_employee.Hide();
            panel_calendar_view.Show();
            panel_calendar_view.Location = new Point(1, 0);
            panel_main.Show();
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

        private void btn_pending_requests_Click(object sender, EventArgs e)
        {
            if (!panel_main.Controls.Contains(UC_OutstandingHolidays.Instance))
            {
                panel_main.Controls.Add(UC_OutstandingHolidays.Instance);
                UC_OutstandingHolidays.Instance.Dock = DockStyle.Fill;
                UC_OutstandingHolidays.Instance.BringToFront();
                UC_OutstandingHolidays.Instance.initializeRequestsList();
            }
            else
            {
                UC_OutstandingHolidays.Instance.BringToFront();
                UC_OutstandingHolidays.Instance.initializeRequestsList();
            }
        }

        private void btn_holiday_bookings_Click(object sender, EventArgs e)
        {
            if (!panel_main.Controls.Contains(UC_HolidayBookings.Instance))
            {
                panel_main.Controls.Add(UC_HolidayBookings.Instance);
                UC_HolidayBookings.Instance.Dock = DockStyle.Fill;
                UC_HolidayBookings.Instance.BringToFront();
                UC_HolidayBookings.Instance.initializeHolidayBookingsList();
                UC_HolidayBookings.Instance.populateEmployeesDropdown();
            }
            else
            {
                UC_HolidayBookings.Instance.BringToFront();
                UC_HolidayBookings.Instance.initializeHolidayBookingsList();
                UC_HolidayBookings.Instance.populateEmployeesDropdown();
            }
        }

        private void btn_day_view_Click(object sender, EventArgs e)
        {
            if (!panel_main.Controls.Contains(UC_EmployeesPresent.Instance))
            {
                panel_main.Controls.Add(UC_EmployeesPresent.Instance);
                UC_EmployeesPresent.Instance.Dock = DockStyle.Fill;
                UC_EmployeesPresent.Instance.BringToFront();
                UC_EmployeesPresent.Instance.initialiseEmployeesLists();
            }
            else
            {
                UC_EmployeesPresent.Instance.BringToFront();
                UC_EmployeesPresent.Instance.initialiseEmployeesLists();
            }
        }

        private void btn_1_Click(object sender, EventArgs e)
        {
            if (!panel_main.Controls.Contains(EmployeeCalendar.Instance))
            {
                panel_main.Controls.Add(EmployeeCalendar.Instance);
                EmployeeCalendar.Instance.Dock = DockStyle.Fill;
                EmployeeCalendar.Instance.BringToFront();
            }
            else
            {
                EmployeeCalendar.Instance.BringToFront();
            }
        }
    }
}
