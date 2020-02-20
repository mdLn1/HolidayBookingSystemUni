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
    public partial class UC_EmployeesPresent : UserControl
    {
        private static UC_EmployeesPresent _instance;
        public UC_EmployeesPresent()
        {
            InitializeComponent();
            datePickCalendar.MinDate = DateTime.Now.Date;
            datePickCalendar.SetDate(DateTime.Now.Date);
            selectedDateLabel.Text = "Currently selected date " + DateTime.Now.ToShortDateString();

        }
        public static UC_EmployeesPresent Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UC_EmployeesPresent();
                }
                return _instance;
            }
        }

        public void initialiseEmployeesLists()
        {
            onHolidayEmployeesListView.Items.Clear();
            workingEmployeesListView.Items.Clear();
            var selectedDate = datePickCalendar.SelectionRange.Start;
            using (HBSModel entity = new HBSModel())
            {
                var users = entity.Users.ToList();
                foreach (var user in users)
                {
                    if(user.Role.RoleName == GeneralUtils.ADMIN_ROLE)
                    {
                        continue;
                    }
                    if (user.HolidayRequests != null && 
                        user.HolidayRequests.Any(x => x.StatusRequest.Status == GeneralUtils.APPROVED 
                        && x.StartDate >= selectedDate 
                        && x.EndDate > selectedDate))
                    {
                        string[] arr = new string[5];
                        arr[0] = user.id.ToString();
                        arr[1] = user.Username;
                        ListViewItem item = new ListViewItem(arr);
                        onHolidayEmployeesListView.Items.Add(item);
                    }
                    else
                    {
                        string[] arr = new string[5];
                        arr[0] = user.id.ToString();
                        arr[1] = user.Username;
                        ListViewItem item = new ListViewItem(arr);
                        workingEmployeesListView.Items.Add(item);
                    }
                }
            }
        }

        private void datePickCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            initialiseEmployeesLists();
            selectedDateLabel.Text = "Currently selected date " + datePickCalendar.SelectionRange.Start.ToShortDateString();
        }
    }
}
