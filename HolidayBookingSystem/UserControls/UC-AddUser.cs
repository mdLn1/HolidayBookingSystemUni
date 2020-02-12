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
                    _instance.initializeRolesDepartments();
                }
                return _instance;
            }
        }
        public UC_AddUser()
        {
            InitializeComponent();
        }

        Utils utils = new Utils();
        private Validator validator = new Validator();
        private void btn_register_employee_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(tb_username.Text) || (tb_username.Text.Length < 6))
                {
                    throw new Exception("Username must be above 6 characters");
                }

                if (String.IsNullOrEmpty(tb_password.Text) || String.IsNullOrEmpty(tb_repeat_password.Text))
                {
                    throw new Exception("Password field is empty");
                }

                if (tb_password.Text != tb_repeat_password.Text)
                {
                    throw new Exception("Passwords do not match");
                }

                if (!validator.checkPasswordComplexity(tb_password.Text))
                {
                    throw new Exception("Passwords does not matches the required complexity");
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
                    utils.CreatePasswordHash(tb_password.Text, out passwordHash, out passwordSalt);
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

                        MessageBox.Show("Please select valid role and department:\n" + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        cb_departments.SelectedIndex = -1;
                        cb_roles.SelectedIndex = -1;
                        dp_add_employee.Value = DateTime.Now;
                        dp_add_employee.Format = DateTimePickerFormat.Custom;
                        MessageBox.Show("Employee correctly registered", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("Something went wrong!", "Error", MessageBoxButtons.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Registration Error: \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void initializeRolesDepartments()
        {
            try
            {
                using (HBSModel _entity = new HBSModel())
                {
                    List<Role> _roles = _entity.Roles.ToList();
                    foreach (Role role in _roles)
                    {
                        cb_roles.Items.Add(role.RoleName);
                    }
                    List<Department> _departments = _entity.Departments.ToList();
                    foreach (Department department in _departments)
                    {
                        cb_departments.Items.Add(department.DepartmentName);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Could not connect to the database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            _instance.initializeRolesDepartments();
            _instance.dp_add_employee.Value = DateTime.Now;
        }
    }
}
