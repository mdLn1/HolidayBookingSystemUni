using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HBSDatabase;

namespace HolidayBookingSystem.UserControls
{
    public partial class UC_HolidayBookings : UserControl
    {
        private static UC_HolidayBookings _instance;

        public static UC_HolidayBookings Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UC_HolidayBookings();
                }
                return _instance;
            }
        }

        public UC_HolidayBookings()
        {
            InitializeComponent();
        }

        public void initializeHolidayBookingsList()
        {
            using (HBSModel entity = new HBSModel())
            {
                var holidayBookings = entity.HolidayRequests.ToList();
                populateBookingsList(holidayBookings);
                var departments = entity.Departments.Where(x => x.DepartmentName != GeneralUtils.MANAGEMENT_DEPARTMENT);
                departmentComboBox.Items.Clear();
                foreach (var department in departments)
                {
                    departmentComboBox.Items.Add(new ComboItem(department.DepartmentName, department.ID));
                }
            }
        }

        public void populateBookingsList(List<HolidayRequest> holidayBookings)
        {
            holidayBookings.RemoveAll(x => x.StatusRequest.Status != GeneralUtils.APPROVED);
            holidayBookingsListView.Items.Clear();
            if (holidayBookings.Count == 0)
            {
                messageLabel.Visible = true;
            }
            else
            {
                messageLabel.Visible = false;
            }
            foreach (var booking in holidayBookings)
            {
                string[] arr = new string[5];
                arr[0] = booking.ID.ToString();
                arr[1] = booking.StartDate.ToShortDateString();
                arr[2] = booking.EndDate.ToShortDateString();
                arr[3] = booking.NumberOfDays.ToString();
                ListViewItem item = new ListViewItem(arr);
                holidayBookingsListView.Items.Add(item);
            }
        }

        public void populateEmployeesDropdown()
        {
            using (HBSModel entity = new HBSModel())
            {
                var employees = entity.Users.Where(x => x.Username != GeneralUtils.ADMIN_ROLE).ToList();
                employeesComboBox.Items.Clear();
                foreach (var employee in employees)
                {
                    employeesComboBox.Items.Add(new ComboItem(employee.Username, employee.id));
                }
            }

        }
        public void populateEmployeesDropdown(int departmentId)
        {
            using (HBSModel entity = new HBSModel())
            {
                var employees = entity.Users.Where(x => x.DepartmentID == departmentId).ToList();
                employeesComboBox.Items.Clear();
                foreach (var employee in employees)
                {
                    employeesComboBox.Items.Add(new ComboItem(employee.Username, employee.id));
                }
            }

        }

        private void employeesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (HBSModel entity = new HBSModel())
            {
                ComboItem itm = (ComboItem)employeesComboBox.SelectedItem;
                var holidayBookings = entity.HolidayRequests.Where(x => x.UserID == itm.ID).ToList();
                populateBookingsList(holidayBookings);
            }
        }

        private void departmentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboItem itm = (ComboItem)departmentComboBox.SelectedItem;
            populateEmployeesDropdown(itm.ID);
        }
    }
}
