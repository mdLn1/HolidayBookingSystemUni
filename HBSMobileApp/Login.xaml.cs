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
using System.Windows.Navigation;
using System.Windows.Shapes;
using SolutionUtils;
using HBSMobileApp.EmployeeService;
using System.Threading;

namespace HBSMobileApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private EmployeeServiceSoapClient client;
        public MainWindow()
        {
            InitializeComponent();
            errorBlock.Visibility = Visibility.Hidden;
            client = new EmployeeServiceSoapClient();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameBox.Text.Trim();
            string password = passwordBox.Password.Trim();
            errorBlock.Visibility = Visibility.Hidden;
            if (username.Length > 0 && password.Length > 0)
            {
                this.Cursor = Cursors.Wait;
                Button button = (Button)sender;
                button.Cursor = Cursors.Wait;
                
                EmployeeLoginResponse response = await client.EmployeeLoginAsync(username, password);
                this.Cursor = Cursors.Arrow;
                button.Cursor = Cursors.Hand;
                if (response.Body.EmployeeLoginResult != 1)
                {
                    errorBlock.Visibility = Visibility.Visible;
                    errorBlock.Text = "Invalid login attempt";
                } else
                {
                    Application.Current.Resources["username"] = username;
                    Application.Current.Resources["password"] = password;
                    SubmitRequest submitRequest = new SubmitRequest();
                    submitRequest.Show();
                    this.Close();
                }
            } else
            {
                errorBlock.Visibility = Visibility.Visible;
                errorBlock.Text = "Please enter credentials";
            }
        }

       

    }
}
