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
using SolutionUtils;
namespace HolidayBookingSystem.UserControls
{
    public partial class EmployeeCalendar : UserControl
    {

        private static EmployeeCalendar _instance;
        private List<Department> departments;
        private int currentlySelectedEmployeeId = -1;
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
            selectedMonthLabel.Text = "Selected Month: " + GeneralUtils.getMonthName(DateTime.Now.Month) + " " + DateTime.Now.Year;
            InitializeDropdowns();
        }

        private void departmentsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboItem itm = (ComboItem)departmentDropDown.SelectedItem;
            fillEmployeesDropDown(itm.ID);
        }

        public void fillEmployeesDropDown(int departmentId)
        {
            employeeDropDown.Items.Clear();
            employeeDropDown.SelectedIndex = -1;

            using (HBSModel model = new HBSModel())
            {
                var employees = model.Users.Where(x => x.DepartmentID == departmentId)
                    .OrderBy(x => x.Username).ToList();
                foreach (var employee in employees)
                {
                    employeeDropDown.Items.Add(new ComboItem(employee.Username, employee.id));
                }
                if(employees.Count() == 0)
                {
                    employeeDropDown.Items.Add(new ComboItem("No employee found", -1));
                }
            }
        }

        public void InitializeDropdowns()
        {
            yearDropDown.Items.AddRange(new object[] { DateTime.Now.Year, DateTime.Now.Year + 1 });
            for(int i = 1; i < 13; i++)
            {
                monthDropDown.Items.Add(new ComboItem(GeneralUtils.getMonthName(i), i));
            }
            yearDropDown.SelectedIndex = 0;
            using (HBSModel model = new HBSModel())
            {
                departments = model.Departments.OrderBy(x => x.DepartmentName).ToList();
                fillEmployeesDropDown(departments.ElementAt(0).ID);
            }

            departmentDropDown.Items.Clear();
            foreach (var department in departments)
            {
                departmentDropDown.Items.Add(new ComboItem(department.DepartmentName, department.ID));
            }
        }

        private void searchBookingsButton_Click(object sender, EventArgs e)
        {
            if(employeeDropDown.SelectedIndex == -1)
            {
                DesktopAppUtils.popDefaultErrorMessageBox("No employee selected");
                return;
            }
            ComboItem employee = (ComboItem)employeeDropDown.SelectedItem;
            if(employee.ID == -1)
            {
                DesktopAppUtils.popDefaultErrorMessageBox("No employee selected");
                return;
            }
            if(departmentDropDown.SelectedIndex == -1)
            {
                DesktopAppUtils.popDefaultErrorMessageBox("No department selected");
                return;

            }
            if (monthDropDown.SelectedIndex == -1)
            {
                DesktopAppUtils.popDefaultErrorMessageBox("No month selected");
                return;

            }
            ComboItem month = (ComboItem)monthDropDown.SelectedItem;
            object year = yearDropDown.SelectedItem;
            this.Cursor = Cursors.WaitCursor;
            if (currentlySelectedEmployeeId == employee.ID)
            {
                calendarDataVisualization1.ChangeSelection(month.ID, int.Parse(year.ToString()));
            }
            else
            {
                currentlySelectedEmployeeId = employee.ID;
                using (HBSModel model = new HBSModel())
                {
                    var holidayRequests = model.HolidayRequests.Where(x => x.UserID == employee.ID
                        && x.StatusRequest.Status == GeneralUtils.APPROVED).ToList();
                    List<DateRange> dateRanges = new List<DateRange>();
                    foreach (HolidayRequest holidayRequest in holidayRequests)
                    {
                        dateRanges.Add(new DateRange(holidayRequest.StartDate, holidayRequest.EndDate));
                    }
                    calendarDataVisualization1.ClearDateRanges();
                    calendarDataVisualization1.AddDateRangesList(dateRanges);
                    calendarDataVisualization1.ChangeSelection(month.ID, int.Parse(year.ToString()));
                }
            }
            selectedMonthLabel.Text = "Selected Month: " + month.Text + " " + year.ToString();
            this.Cursor = Cursors.Default;
        }
    }

}
