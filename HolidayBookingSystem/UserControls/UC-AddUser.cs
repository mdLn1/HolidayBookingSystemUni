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

namespace HolidayBookingSystem
{
    public partial class UC_AddUser : UserControl
    {
        private static UC_AddUser _instance;

        public static UC_AddUser Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UC_AddUser();
                    _instance.initializeRolesAndDepartments();
                }
                return _instance;
            }
        }
        public UC_AddUser()
        {
            InitializeComponent();
        }

        private void btn_register_employee_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(tb_username.Text) || (tb_username.Text.Length < 6))
                {
                    throw new Exception("Username must be above 6 characters");
                }

                if (String.IsNullOrEmpty(tb_password.Text))
                {
                    throw new Exception("Password field must be filled");
                }

                if (tb_password.Text != tb_repeat_password.Text)
                {
                    throw new Exception("Passwords do not match");
                }

                if (!Validator.checkPasswordComplexity(tb_password.Text))
                {
                    throw new Exception("Password does not match the required complexity");
                }

                if (cb_departments.SelectedIndex == -1)
                {
                    throw new Exception("Please select department");
                }

                if (cb_roles.SelectedIndex == -1)
                {
                    throw new Exception("Please select role");
                }

                using (HBSModel _entity = new HBSModel())
                {
                    User newUser = new User();
                    newUser.Username = tb_username.Text;

                    // hash the password
                    byte[] passwordHash, passwordSalt;
                    Utils.CreatePasswordHash(tb_password.Text, out passwordHash, out passwordSalt);
                    newUser.Pwd = passwordHash;
                    newUser.PwdSalt = passwordSalt;

                    // Find ID of selected role and department
                    try
                    {
                        var _selectedDepartment = _entity.Departments.First(dpt => dpt.DepartmentName == cb_departments.SelectedItem.ToString());
                        var _selectedRole = _entity.Roles.First(role => role.RoleName == cb_roles.SelectedItem.ToString());
                        newUser.DepartmentID = _selectedDepartment.ID;
                        newUser.RoleID = _selectedRole.ID;
                    }
                    catch (Exception ex)
                    {
                        Utils.popDefaultErrorMessageBox("Please select valid role and department:\n" + ex.Message);
                        return;

                    }

                    // get date and make it to datetime2
                    newUser.StartDate = dp_add_employee.Value.Date;

                    try
                    {
                        _entity.Users.Add(newUser);
                        _entity.SaveChanges();
                        tb_username.Text = "";
                        tb_password.Text = "";
                        tb_repeat_password.Text = "";
                        cb_departments.SelectedIndex = -1;
                        cb_roles.SelectedIndex = -1;
                        dp_add_employee.Value = DateTime.Now;
                        dp_add_employee.Format = DateTimePickerFormat.Custom;
                        MessageBox.Show("Employee successfully registered", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        Utils.popDefaultErrorMessageBox("Something went wrong");
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.popDefaultErrorMessageBox("Registration Error: \n" + ex.Message);
            }

        }

        public void initializeRolesAndDepartments()
        {
            try
            {
                using (HBSModel _entity = new HBSModel())
                {
                    foreach (Role role in _entity.Roles.ToList())
                    {
                        cb_roles.Items.Add(role.RoleName);
                    }
                    foreach (Department department in _entity.Departments.ToList())
                    {
                        cb_departments.Items.Add(department.DepartmentName);
                    }
                }
            }
            catch
            {
                Utils.popDefaultErrorMessageBox("Could not connect to the database");
            }

        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            initialiseForm();
        }

        public void initialiseForm()
        {
            _instance.tb_username.Text = "";
            _instance.tb_password.Text = "";
            _instance.tb_repeat_password.Text = "";
            _instance.initializeRolesAndDepartments();
            _instance.dp_add_employee.Value = DateTime.Now;
        }
    }
}
