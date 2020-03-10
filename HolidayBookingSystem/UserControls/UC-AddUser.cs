
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
            hideErrors();
        }

        private void hideErrors()
        {
            usernameErrorLabel.Visible = false;
            passwordErrorLabel.Visible = false;
            confirmPasswordErrorLabel.Visible = false;
            phoneNumberErrorLabel.Visible = false;
            roleErrorLabel.Visible = false;
            departmentErrorLabel.Visible = false;
        }

        private void btn_register_employee_Click(object sender, EventArgs e)
        {
            try
            {
                hideErrors();
                bool noErrors = true;
                if (String.IsNullOrEmpty(tb_username.Text) || (tb_username.Text.Length < 6))
                {
                    usernameErrorLabel.Text = "Username must be above 6 characters";
                    usernameErrorLabel.Visible = true;
                    noErrors = false;
                }

                if (String.IsNullOrEmpty(tb_password.Text))
                {
                    passwordErrorLabel.Text = "Password field must be filled";
                    passwordErrorLabel.Visible = true;
                    noErrors = false;

                }

                if (tb_password.Text != tb_repeat_password.Text)
                {
                    confirmPasswordErrorLabel.Text = "Passwords do not match";
                    confirmPasswordErrorLabel.Visible = true;
                    noErrors = false;
                }

                if (!GeneralUtils.checkPasswordComplexity(tb_password.Text))
                {
                    passwordErrorLabel.Text = "Password does not match the required complexity";
                    passwordErrorLabel.Visible = true;
                    noErrors = false;
                }

                if (cb_departments.SelectedIndex == -1)
                {
                    departmentErrorLabel.Text = "Please select department";
                    departmentErrorLabel.Visible = true;
                    noErrors = false;
                }

                if (cb_roles.SelectedIndex == -1)
                {
                    roleErrorLabel.Text = "Please select role";
                    roleErrorLabel.Visible = true;
                    noErrors = false;
                }
                if (!String.IsNullOrEmpty(tb_phoneNumber.Text))
                {
                    if (!tb_phoneNumber.ValidInput())
                    {
                        phoneNumberErrorLabel.Text = "The phone number entered is not in a valid format";
                        phoneNumberErrorLabel.Visible = true;
                        noErrors = false;
                    }
                }
                if (noErrors)
                {
                    using (HBSModel _entity = new HBSModel())
                    {
                        User newUser = new User
                        {
                            Username = tb_username.Text
                        };
                        var isAlreadyRegistered = _entity.Users.FirstOrDefault(x => x.Username == newUser.Username);
                        if (isAlreadyRegistered != null)
                        {
                            usernameErrorLabel.Text = "Username already registered";
                            usernameErrorLabel.Visible = true;
                        }
                        // hash the password
                        GeneralUtils.CreatePasswordHash(tb_password.Text, out byte[] passwordHash, out byte[] passwordSalt);
                        newUser.Pwd = passwordHash;
                        newUser.PwdSalt = passwordSalt;
                        newUser.PhoneNumber = tb_phoneNumber.Text;

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
                            DesktopAppUtils.popDefaultErrorMessageBox("Please select valid role and department:\n" + ex.Message);
                            return;

                        }

                        newUser.PhoneNumber = tb_phoneNumber.Text;

                        // get date and make it to datetime2
                        newUser.StartDate = dp_add_employee.Value.Date;

                        // calculate remaining days
                        newUser.RemainingDays = GeneralUtils.CalculateHolidayAllowanceOnRegistration(dp_add_employee.Value.Date);

                        try
                        {
                            _entity.Users.Add(newUser);
                            _entity.SaveChanges();
                            
                            if(MessageBox.Show("Employee successfully registered", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                            {
                                tb_username.Text = "";
                                tb_password.Text = "";
                                tb_repeat_password.Text = "";
                                cb_departments.SelectedIndex = -1;
                                cb_roles.SelectedIndex = -1;
                                dp_add_employee.Value = DateTime.Now;
                                dp_add_employee.Format = DateTimePickerFormat.Custom;
                            }
                        }
                        catch
                        {
                            DesktopAppUtils.popDefaultErrorMessageBox("Something went wrong, please try again later");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                DesktopAppUtils.popDefaultErrorMessageBox("Registration Error: \n" + ex.Message);
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
                DesktopAppUtils.popDefaultErrorMessageBox("Could not connect to the database");
            }

        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to clear the form?", "Confirm Clearing", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                initialiseForm();
            }
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
