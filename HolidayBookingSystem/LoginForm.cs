﻿using System;
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
            tb_username.Text = "Username";
            tb_password.PasswordChar = '\0';
            tb_password.Text = "Password";
        }

        public void formValuesChanged(object sender, EventArgs e)
        {
            string username = tb_username.Text.Trim();
            string password = tb_password.Text.Trim();
            if (String.IsNullOrEmpty(username) 
                || String.IsNullOrEmpty(password) 
                || !username.Equals("Username") || !password.Equals("Password")) {
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

        private void textBox_Enter(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if(textBox.Name == "tb_username")
            {
                if (tb_username.Text == "Username")
                {
                    tb_username.Text = "";
                }
            } else
            {
                if (tb_password.Text == "Password")
                {
                    tb_password.Text = "";
                    tb_password.PasswordChar = '*';
                }
            }
            
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Name == "tb_username")
            {
                if (tb_username.Text.Trim() == "")
                {
                    tb_username.Text = "Username";
                }
            } else
            {
                if (tb_password.Text.Trim() == "")
                {
                    tb_password.PasswordChar = '\0';
                    tb_password.Text = "Password";
                }
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
                if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password) 
                    || !username.Equals("Username") || !password.Equals("Password"))
                {
                    throw new Exception("Username and password must not be empty");
                }
                using (HBSModel _entity = new HBSModel())
                {
                    var _user = _entity.Users.FirstOrDefault(x => x.Username == username);
                    if (_user == null)
                    {
                        throw new Exception("User not found");
                    }
                    if (!Utils.VerifyPasswordHash(password, _user.Pwd, _user.PwdSalt))
                    {
                        throw new Exception("Invalid login attempt");
                    }

                    // Only users matching the role Head and beloging to the Office department can login as admins
                    if (_user.Role.RoleName != Utils.ADMIN_ROLE)
                    {
                        throw new Exception("Only admins can login with this app");
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

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Name == "tb_username")
            {
                if (tb_username.Text == "Username")
                {
                    tb_username.Text = "";
                }
            }
            else
            {
                if (tb_password.Text == "Password")
                {
                    tb_password.Text = "";
                    tb_password.PasswordChar = '*';
                }
            }
        }
    }
}
