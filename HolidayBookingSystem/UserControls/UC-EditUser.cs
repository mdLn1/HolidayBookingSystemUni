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
    public partial class UC_EditUser : UserControl
    {
        private static UC_EditUser _instance;

        public static UC_EditUser Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UC_EditUser();
                }
                return _instance;
            }
        }

        private User _selectedUser = new User();

        public UC_EditUser()
        {
            InitializeComponent();
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(tb_search.Text))
                {
                    throw new Exception("Empty search - please type a search value");
                }
                using (HBSModel _entity = new HBSModel())
                {
                    var _users = _entity.Users.Where(user => user.Username.Contains(tb_search.Text) && user.Username != GeneralUtils.ADMIN_ROLE).ToList();
                    if (_users != null)
                    {
                        lv_search.Items.Clear();
                        
                        foreach (User user in _users)
                        {
                            string[] arr = new string[5];
                            arr[0] = user.id.ToString();
                            arr[1] = user.Username.ToString();
                            arr[2] = user.RemainingDays.ToString() == "" ? "N/A" : user.RemainingDays.ToString();
                            arr[3] = user.Role.RoleName;
                            arr[4] = user.Department.DepartmentName;
                            ListViewItem item = new ListViewItem(arr);
                            lv_search.Items.Add(item);
                        }
                    }
                }

            }
            catch (Exception err)
            {
                DesktopAppUtils.popDefaultErrorMessageBox("Something went wrong \n" + err.Message);
            }
        }

        private void btn_show_all_Click(object sender, EventArgs e)
        {
            initializeUserList();
        }

        private void btn_details_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(_selectedUser.Username))
                {
                    throw new Exception("No User selected");
                }
                if (String.IsNullOrEmpty(tb_username.Text) || (tb_username.Text.Length < 6))
                {
                    throw new Exception("Username must be above 6 characters");
                }
                using (HBSModel _entity = new HBSModel())
                {
                    var _user = _entity.Users.FirstOrDefault(user => user.Username == _selectedUser.Username);
                    _user.Username = tb_username.Text;
                    _user.RoleID = _entity.Roles.SingleOrDefault(role => role.RoleName == cb_roles.SelectedItem.ToString()).ID;
                    _user.DepartmentID = _entity.Departments.SingleOrDefault(role => role.DepartmentName == cb_departments.SelectedItem.ToString()).ID;
                    _user.StartDate = dp_edit.Value.Date;
                    _user.PhoneNumber = tb_phone_number.Text;
                    _selectedUser = _user;
                    _entity.SaveChanges();
                    
                }
                initializeUserList();
                initializeUserBox();
            }
            catch (Exception err)
            {
                DesktopAppUtils.popDefaultErrorMessageBox("Error:\n" + err.Message);
            }
        }

        private void btn_password_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(_selectedUser.Username))
                {
                    throw new Exception("No User selected");
                }
                if (tb_password.Text != tb_repeat_password.Text)
                {
                    throw new Exception("Passwords do not match");
                }
                if (!GeneralUtils.checkPasswordComplexity(tb_password.Text))
                {
                    throw new Exception("Password complexity does not match requirements");
                }
                using (HBSModel _entity = new HBSModel())
                {
                    var _user = _entity.Users.FirstOrDefault(user => user.Username == _selectedUser.Username);
                    // hash the password
                    byte[] passwordHash, passwordSalt;
                    GeneralUtils.CreatePasswordHash(tb_password.Text, out passwordHash, out passwordSalt);
                    _user.Pwd = passwordHash;
                    _user.PwdSalt = passwordSalt;
                    _entity.SaveChanges();
                    MessageBox.Show("Password Updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    initializeUserBox();
                }
            }
            catch (Exception ex)
            {
                DesktopAppUtils.popDefaultErrorMessageBox("Error:\n" + ex.Message);
            }
        }

        private void updateUserBox(string username, string role, string department, DateTime? start, string phoneNumber)
        {
            tb_username.Text = username;
            initializeRolesDepartments();
            cb_roles.SelectedIndex = cb_roles.FindStringExact(role);
            cb_departments.SelectedIndex = cb_departments.FindStringExact(department);
            tb_phone_number.Text = phoneNumber;
            dp_edit.Value = (DateTime)start;
        }

        private void initializeRolesDepartments()
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
            catch (Exception err)
            {
                DesktopAppUtils.popDefaultErrorMessageBox("Could not connect to database \n" + err.Message);
            }

        }

        public void initializeUserList()
        {
            lv_search.Items.Clear();
            try
            {
                using (HBSModel _entity = new HBSModel())
                {
                    var _users = _entity.Users.ToList();
                    _users.RemoveAll(u => u.Role.RoleName == GeneralUtils.ADMIN_ROLE);
                    foreach (User usr in _users)
                    {
                        string[] arr = new string[5];
                        arr[0] = usr.id.ToString();
                        arr[1] = usr.Username.ToString();
                        arr[2] = usr.RemainingDays.ToString() == "" ? "N/A" : usr.RemainingDays.ToString();
                        arr[3] = usr.Role.RoleName;
                        arr[4] = usr.Department.DepartmentName;
                        ListViewItem item = new ListViewItem(arr);
                        lv_search.Items.Add(item);
                    }
                }
            }
            catch (Exception e)
            {
                DesktopAppUtils.popDefaultErrorMessageBox("Could not retrieve Item from DB");
            }
        }

        private void initializeUserBox()
        {
            tb_password.Text = "";
            tb_repeat_password.Text = "";
            tb_username.Text = "";
            tb_phone_number.Text = "";
            cb_departments.SelectedIndex = -1;
            cb_departments.Items.Clear();
            cb_roles.SelectedIndex = -1;
            cb_roles.Items.Clear();
            dp_edit.Value = DateTime.Now;
            _selectedUser = new User();
        }


        private void lv_search_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lv_search.SelectedIndices.Count > 0)
            {
                int selIndex = lv_search.SelectedIndices[0];
                ListViewItem item = lv_search.Items[selIndex];
                try
                {
                    using (HBSModel _entity = new HBSModel())
                    {
                        _selectedUser = _entity.Users.Find(Convert.ToInt32(item.SubItems[0].Text));
                        updateUserBox(
                            _selectedUser.Username.ToString(),
                            _selectedUser.Role.RoleName,
                            _selectedUser.Department.DepartmentName,
                            _selectedUser.StartDate,
                            _selectedUser.PhoneNumber);

                    }
                }
                catch (Exception err)
                {
                    DesktopAppUtils.popDefaultErrorMessageBox("Could not connect to DB \n" + err.Message);
                }
            }
            
        }
    }
}
