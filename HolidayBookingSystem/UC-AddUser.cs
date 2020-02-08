using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            // Set to no text.
            tb_password.Text = "";
            // The password character is an asterisk.
            tb_password.PasswordChar = '*';
            // The control will allow no more than 14 characters.
            tb_password.MaxLength = 20;
            //initializeRolesDepartments();
        }
        Utils utils = new Utils();
        private void btn_register_employee_Click(object sender, EventArgs e)
        {
            try
            {
                using (HBSModel _entity = new HBSModel())
                {
                    User newUser = new User();
                    newUser.Username = tb_username.Text;

                    // hash the password
                    if (tb_password.Text == tb_repeat_password.Text)
                    {
                        byte[] passwordHash, passwordSalt;
                        utils.CreatePasswordHash(tb_password.Text, out passwordHash, out passwordSalt);
                        newUser.Pwd = passwordHash;
                        newUser.PwdSalt = passwordSalt;
                    }
                    else
                    {
                        MessageBox.Show("Passwords do not match", "Error Message", MessageBoxButtons.OK);
                    }
                    

                    // Find ID of selected role and department
                    try
                    {
                        var _selectedDepartment = _entity.Departments.First(dpt => dpt.DepartmentName == cb_departments.SelectedItem.ToString());
                        var _selectedRole = _entity.Roles.First(role => role.RoleName == cb_roles.SelectedItem.ToString());
                        newUser.DepartmentID = _selectedDepartment.ID;
                        newUser.RoleID = _selectedRole.ID;
                    }
                    catch (Exception err)
                    {

                        MessageBox.Show("Please select role and department", "Error Message", MessageBoxButtons.OK);
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
                        MessageBox.Show("Employee correctly registered", "Success", MessageBoxButtons.OK);
                    }
                    catch
                    {
                        MessageBox.Show("Something went wrong!", "Error", MessageBoxButtons.OK);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Could not connect to the database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

    }
}
