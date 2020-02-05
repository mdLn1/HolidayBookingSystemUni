using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            // Set to no text.
            tb_password.Text = "";
            // The password character is an asterisk.
            tb_password.PasswordChar = '*';
            // The control will allow no more than 14 characters.
            tb_password.MaxLength = 20;
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            
            string username = tb_username.Text;
            string password = tb_password.Text;
            using (HBSModelData _entity = new HBSModelData())
            {
                var _user = _entity.Users.FirstOrDefault(x => x.Username == username);
                if (_user == null)
                {
                    MessageBox.Show("User not found", "Message", MessageBoxButtons.OK);
                    return;
                }

                if (!utils.VerifyPasswordHash(password, _user.Pwd, _user.PwdSalt))
                {
                    MessageBox.Show("Wrong password", "Message", MessageBoxButtons.OK);
                    return;
                }

                this.Hide();
                Dashboard dashboard = new Dashboard();
                dashboard.ShowDialog();
                this.Close();
            }
            
        }
    }
}
