using HBSMobileApp.EmployeeService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        private EmployeeServiceSoapClient client;
        private bool loading = false;
        public SubmitRequest()
        {
            InitializeComponent();
            client = new EmployeeServiceSoapClient();
            startDateCalendar.DisplayDateStart = DateTime.Now.AddDays(5);
            startDateCalendar.SelectedDate = DateTime.Now.AddDays(5);
            endDateCalendar.DisplayDateStart = DateTime.Now.AddDays(5);
            endDateCalendar.SelectedDate = DateTime.Now.AddDays(5);
            startDateCalendar.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(onSelectedStartDateChanged);
            endDateCalendar.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(onSelectedEndDateChanged);
            errorBlock.Visibility = Visibility.Hidden;
        }

        public void onSelectedEndDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if(endDateCalendar.SelectedDate > startDateCalendar.SelectedDate)
            {
                DateTime startDate = (DateTime)startDateCalendar.SelectedDate;
                DateTime endDate = (DateTime)endDateCalendar.SelectedDate;
                int workingDays = GeneralUtils.CalculateWorkingDays(startDate, endDate);
                errorBlock.Visibility = Visibility.Visible;
                errorBlock.Text = "You are asking for " + workingDays + " day(s) of holiday allowance.";
                errorBlock.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF0E8B19"));
            }
        }

            public void onSelectedStartDateChanged(object sender, SelectionChangedEventArgs e)
        {
                DateTime startDateTime = (DateTime)startDateCalendar.SelectedDate;
                if (startDateTime.Month > DateTime.Now.Month)
                {
                    endDateCalendar.DisplayDateStart = startDateTime.Date.AddDays(1);
                }
                if (startDateTime.Date > endDateCalendar.SelectedDate)
                {
                    endDateCalendar.SelectedDate = startDateTime.Date.AddDays(1);
                }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            errorBlock.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFF90505"));
            if (endDateCalendar.SelectedDate < startDateCalendar.SelectedDate)
            {
                DateTime dateTime = (DateTime)startDateCalendar.SelectedDate;
                errorBlock.Visibility = Visibility.Visible;
                endDateCalendar.SelectedDate = dateTime.AddDays(1);
                errorBlock.Text = "End date must come after start date";
            }
            else
            {
                errorBlock.Visibility = Visibility.Visible;
                DateTime startDate = (DateTime)startDateCalendar.SelectedDate;
                DateTime endDate = (DateTime)endDateCalendar.SelectedDate;
                int workingDays = GeneralUtils.CalculateWorkingDays(startDate, endDate);
                if (workingDays == 0)
                {
                    
                    errorBlock.Text = "You selected weekend days, no need for holiday allowance";
                }
                else if (workingDays > GeneralUtils.MAX_POSSIBLE_HOLIDAY)
                {
                    
                    errorBlock.Text = "Too many days selected, it exceeds the maximum allowance";
                }
                else
                {
                    this.Cursor = Cursors.Wait;
                    startDate = GeneralUtils.simplifyStartDate(startDate);
                    endDate = GeneralUtils.simplifyEndDate(endDate);
                    bool res = await client.HolidayRequestAsync(startDate, endDate, workingDays);
                    this.Cursor = Cursors.Arrow;
                    if(res)
                    {
                        errorBlock.Text = "Holiday Request Submitted";
                        errorBlock.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF0E8B19"));
                    }
                }
            }
        }

        private void resetButton_Click(object sender, RoutedEventArgs e)
        {
            startDateCalendar.DisplayDateStart = DateTime.Now.AddDays(5);
            startDateCalendar.SelectedDate = DateTime.Now.AddDays(5);
            endDateCalendar.DisplayDateStart = DateTime.Now.AddDays(5);
            endDateCalendar.SelectedDate = DateTime.Now.AddDays(6);
        }

        internal void loadingExec()
        {
            this.Dispatcher.BeginInvoke(new Action(() =>
            {
                while (loading)
                {
                    errorBlock.Text += ".";
                    if (errorBlock.Text.Length > 13)
                    {
                        errorBlock.Text = "Processing";
                    }
                    Thread.Sleep(200);
                }
            }));
            
        }
    }
}
