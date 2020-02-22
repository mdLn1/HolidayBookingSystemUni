using HBSMobileApp.EmployeeService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HBSMobileApp
{
    /// <summary>
    /// Interaction logic for SubmitRequest.xaml
    /// </summary>
    public partial class SubmitRequest : Window
    {
        public EmployeeServiceSoapClient client;
        public SubmitRequest()
        {
            InitializeComponent();
            client = new EmployeeServiceSoapClient();
            startDateCalendar.DisplayDateStart = DateTime.Now.AddDays(5);
            startDateCalendar.SelectedDate = DateTime.Now.AddDays(5);
            endDateCalendar.DisplayDateStart = DateTime.Now.AddDays(5);
            endDateCalendar.SelectedDate = DateTime.Now.AddDays(5);
            startDateCalendar.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(onSelectedDateChanged);
            endDateCalendar.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(onSelectedDateChanged);
            submitButton.IsEnabled = false;
            submitButton.Cursor = Cursors.No;
        }

        public void onSelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            //DateTime startDate = startDateCalendar.SelectedDate;
            //DateTime endDate = endDateCalendar.SelectedDate;
            //int workingDays = GeneralUtils.CalculateWorkingDays(endDate, startDate);
            DatePicker calendar = (DatePicker)sender;
            DateTime dateTime1 = (DateTime)calendar.SelectedDate;
            if(dateTime1 < DateTime.Now.Date.AddDays(6))
            {
                return;
            }
            if (calendar.Name == startDateCalendar.Name)
            {
                if (startDateCalendar.SelectedDate < DateTime.Today.AddDays(5))
                {

                    MessageBox.Show("Please select a start date for at least 5 days in future.", "Error");
                }
                DateTime startDateTime = (DateTime)startDateCalendar.SelectedDate;
                //endDateCalendar.SelectedDate;
                if (startDateTime.Month > DateTime.Now.Month)
                {
                    endDateCalendar.DisplayDateStart = startDateTime.Date.AddDays(1);
                }

                if(startDateTime.Date > endDateCalendar.SelectedDate)
                {
                    endDateCalendar.SelectedDate = startDateTime.Date.AddDays(1);
                }
            }
            else
            {
                if (endDateCalendar.SelectedDate < startDateCalendar.SelectedDate)
                {
                    DateTime dateTime = (DateTime)startDateCalendar.SelectedDate;
                    endDateCalendar.SelectedDate = dateTime.AddDays(1);
                    MessageBox.Show("End date must come after start date", "Error");
                }
                else
                {
                    DateTime startDate = (DateTime) startDateCalendar.SelectedDate;
                    DateTime endDate = (DateTime) endDateCalendar.SelectedDate;
                    int workingDays = GeneralUtils.CalculateWorkingDays(startDate, endDate);
                    if (workingDays == 0)
                    {
                        MessageBox.Show("You selected weekend days, no need for holiday allowance", "Error");
                    }
                    else if (workingDays > GeneralUtils.MAX_POSSIBLE_HOLIDAY)
                    {
                        MessageBox.Show("Too many days selected, it exceeds the maximum allowance", "Error");
                    }
                    else
                    {
                        MessageBox.Show("You requested " + workingDays + " day(s) of holiday allowance from " +
                                            startDate.ToShortDateString() + " to " +
                                                endDate.ToShortDateString() + ". Please submit if you are satisfied with your selection", "Informative");
                        startDateCalendar.IsEnabled = false;
                        endDateCalendar.IsEnabled = false;
                        submitButton.IsEnabled = true;
                        submitButton.Cursor = Cursors.Hand;
                    }

                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Success");
        }

        private void resetButton_Click(object sender, RoutedEventArgs e)
        {
            startDateCalendar.IsEnabled = true;
            endDateCalendar.IsEnabled = true;
            submitButton.IsEnabled = false;
            submitButton.Cursor = Cursors.No;
            startDateCalendar.DisplayDateStart = DateTime.Now.AddDays(5);
            startDateCalendar.SelectedDate = DateTime.Now.AddDays(5);
            endDateCalendar.DisplayDateStart = DateTime.Now.AddDays(5);
            endDateCalendar.SelectedDate = DateTime.Now.AddDays(6);
        }
    }
}
