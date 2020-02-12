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
    public partial class LoginForm : Form
    {
        private Utils utils = new Utils();
        
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(tb_username.Text))
                {
                    throw new Exception("Empty Username String");
                }

                if (String.IsNullOrEmpty(tb_password.Text))
                {
                    throw new Exception("Empty Password String");
                }

                string username = tb_username.Text;
                string password = tb_password.Text;
                using (HBSModel _entity = new HBSModel())
                {
                    var _user = _entity.Users.FirstOrDefault(x => x.Username == username);
                    if (_user == null)
                    {
                        throw new Exception("User not found");
                    }

                    if (!utils.VerifyPasswordHash(password, _user.Pwd, _user.PwdSalt))
                    {
                        throw new Exception("Incorrect Login Details");
                    }

                    // Only users matching the role Head and beloging to the Office department can login as admins
                    if (_user.DepartmentID != 6 && _user.RoleID != 1)
                    {
                        throw new Exception("User is not an admin");
                    }

                    this.Hide();
                    Dashboard dashboard = new Dashboard();
                    dashboard.ShowDialog();
                    this.Close();
                }
            }   
            catch (Exception ex)
            {
                MessageBox.Show("Error Encountered \n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            
        }

        private void btn_skip_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard dashboard = new Dashboard();
            dashboard.ShowDialog();
            this.Close();
        }
    }
}
