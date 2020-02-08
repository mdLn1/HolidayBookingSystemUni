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

        Utils utils = new Utils();
        public UC_EditUser()
        {
            InitializeComponent();
            // Set to no text.
            tb_password.Text = "";
            tb_repeat_password.Text = "";
            // The password character is an asterisk.
            tb_password.PasswordChar = '*';
            tb_repeat_password.PasswordChar = '*';
            // The control will allow no more than 14 characters.
            tb_password.MaxLength = 20;
            tb_repeat_password.MaxLength = 20;
            //initializeRolesDepartments();
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            try
            {
                using (HBSModel _entity = new HBSModel())
                {
                    var _users = _entity.Users.Where(user => user.Username.Contains(tb_search.Text)).ToList();
                    if (_users != null)
                    {
                        lv_search.Items.Clear();
                        
                        foreach (User user in _users)
                        {
                            string[] arr = new string[5];
                            arr[0] = user.id.ToString();
                            arr[1] = user.Username.ToString();
                            arr[2] = user.RemainingDays.ToString() == "" ? "N/A" : user.RemainingDays.ToString();
                            arr[3] = _entity.Roles.Find(Convert.ToInt32(user.RoleID)).RoleName.ToString();
                            arr[4] = _entity.Departments.Find(Convert.ToInt32(user.DepartmentID)).DepartmentName.ToString();
                            ListViewItem item = new ListViewItem(arr);
                            lv_search.Items.Add(item);
                        }
                    }
                }

            }
            catch (Exception err)
            {
                MessageBox.Show("Something went wrong \n"+err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
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
                            _entity.Roles.Find(Convert.ToInt32(_selectedUser.RoleID)).RoleName.ToString(),
                            _entity.Departments.Find(Convert.ToInt32(_selectedUser.DepartmentID)).DepartmentName.ToString(),
                            _selectedUser.StartDate);

                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show("Could not connect to DB \n" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                lv_search.SelectedIndices.Clear();
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
                using (HBSModel _entity = new HBSModel())
                {
                    var _user = _entity.Users.FirstOrDefault(user => user.Username == _selectedUser.Username);
                    _user.Username = tb_username.Text;
                    _user.RoleID = _entity.Roles.SingleOrDefault(role => role.RoleName == cb_roles.SelectedItem.ToString()).ID;
                    _user.DepartmentID = _entity.Departments.SingleOrDefault(role => role.DepartmentName == cb_departments.SelectedItem.ToString()).ID;
                    _user.StartDate = dp_edit.Value.Date;
                    _selectedUser = _user;
                    _entity.SaveChanges();
                    initializeUserList();
                    initializeUserBox();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Could not connect to database \n"+err, "Error Message", MessageBoxButtons.OK);
            }
        }

        private void btn_password_Click(object sender, EventArgs e)
        {
            if (tb_password.Text == tb_repeat_password.Text)
            {
                try
                {
                    using (HBSModel _entity = new HBSModel())
                    {
                        var _user = _entity.Users.FirstOrDefault(user => user.Username == _selectedUser.Username);
                        // hash the password
                        byte[] passwordHash, passwordSalt;
                        utils.CreatePasswordHash(tb_password.Text, out passwordHash, out passwordSalt);
                        _user.Pwd = passwordHash;
                        _user.PwdSalt = passwordSalt;
                        _entity.SaveChanges();
                        MessageBox.Show("Password Updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        initializeUserBox();
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show("Could not access the database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
                
            }
            else
            {
                MessageBox.Show("Passwords do not match \n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updateUserBox(string username, string role, string department, DateTime? start)
        {
            tb_username.Text = username;
            initializeRolesDepartments();
            cb_roles.SelectedIndex = cb_roles.FindStringExact(role);
            cb_departments.SelectedIndex = cb_departments.FindStringExact(department);
            dp_edit.Value = (DateTime)start;
        }

        private void initializeRolesDepartments()
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
            catch (Exception err)
            {
                MessageBox.Show("Could not connect to database \n" + err, "Error Message", MessageBoxButtons.OK);
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
                    _users.RemoveAll(u => u.Username == "admin");
                    foreach (User usr in _users)
                    {
                        string[] arr = new string[5];
                        arr[0] = usr.id.ToString();
                        arr[1] = usr.Username.ToString();
                        arr[2] = usr.RemainingDays.ToString() == "" ? "N/A" : usr.RemainingDays.ToString();
                        arr[3] = _entity.Roles.Find(Convert.ToInt32(usr.RoleID)).RoleName.ToString();
                        arr[4] = _entity.Departments.Find(Convert.ToInt32(usr.DepartmentID)).DepartmentName.ToString();
                        ListViewItem item = new ListViewItem(arr);
                        lv_search.Items.Add(item);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Could not retrive Item from DB", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void initializeUserBox()
        {
            tb_password.Text = "";
            tb_repeat_password.Text = "";
            tb_username.Text = "";
            cb_departments.SelectedIndex = -1;
            cb_departments.Items.Clear();
            cb_roles.SelectedIndex = -1;
            cb_roles.Items.Clear();
            dp_edit.Value = DateTime.Now;
            _selectedUser = new User();
        }
    }
}
