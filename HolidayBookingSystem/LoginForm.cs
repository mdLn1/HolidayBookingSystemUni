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

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
           
        }

        public void formValuesChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tb_username.Text.Trim()) 
                || String.IsNullOrEmpty(tb_password.Text.Trim())) {
                btn_login.ForeColor = Color.White;
                btn_login.BackColor = Color.IndianRed;
                btn_login.Cursor = Cursors.No;
            }
            else
            {
                btn_login.BackColor = Color.Green;
                btn_login.ForeColor = Color.White;
                btn_login.Cursor = Cursors.Hand;
            }
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if(btn_login.Cursor == Cursors.No)
            {   
                return;
            }
            try
            {
                string username = tb_username.Text.Trim();
                string password = tb_password.Text.Trim();
                if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password))
                {
                    Utils.popDefaultErrorMessageBox("Username and password must not be empty");
                    return;
                }
                using (HBSModel _entity = new HBSModel())
                {
                    var _user = _entity.Users.FirstOrDefault(x => x.Username == username);
                    if (_user == null)
                    {
                        Utils.popDefaultErrorMessageBox("User not found");
                        return;
                    }
                    if (!Utils.VerifyPasswordHash(password, _user.Pwd, _user.PwdSalt))
                    {
                        Utils.popDefaultErrorMessageBox("Invalid login attempt");
                        return;
                    }

                    // Only users matching the role Head and beloging to the Office department can login as admins
                    if (_user.Role.RoleName != Utils.ADMIN_ROLE)
                    {
                        Utils.popDefaultErrorMessageBox("Only admins can login with this app");
                        return;
                    }

                    this.Hide();
                    Dashboard dashboard = new Dashboard();
                    dashboard.ShowDialog();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Utils.popDefaultErrorMessageBox(ex.Message);
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
