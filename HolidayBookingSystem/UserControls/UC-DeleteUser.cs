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
    public partial class UC_DeleteUser : UserControl
    {
        private static UC_DeleteUser _instance;

        public static UC_DeleteUser Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UC_DeleteUser();
                }
                return _instance;
            }
        }

        public UC_DeleteUser()
        {
            InitializeComponent();
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            lv_users.Items.Clear();
            initializeUserList();
        }

        public void initializeUserList()
        {
            lv_users.Items.Clear();
            try
            {
                using (HBSModel _entity = new HBSModel())
                {
                    var _users = _entity.Users.ToList();
                    _users.RemoveAll(u => u.Username == "admin");
                    foreach (User usr in _users)
                    {
                        string[] arr = new string[6];
                        arr[0] = usr.id.ToString();
                        arr[1] = usr.Username.ToString();
                        arr[2] = usr.StartDate.ToString().Substring(0,10);
                        arr[3] = usr.RemainingDays.ToString() == "" ? "N/A" : usr.RemainingDays.ToString();
                        arr[4] = _entity.Roles.Find(Convert.ToInt32(usr.RoleID)).RoleName.ToString();
                        arr[5] = _entity.Departments.Find(Convert.ToInt32(usr.DepartmentID)).DepartmentName.ToString();
                        ListViewItem item = new ListViewItem(arr);
                        lv_users.Items.Add(item);
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Could not retrive Item from DB \n" + err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try {
                int selIndex = lv_users.SelectedIndices[0];
                ListViewItem item = lv_users.Items[selIndex];

                using (HBSModel _entity = new HBSModel())
                {
                    User userDelete = _entity.Users.Find(Convert.ToInt32(item.SubItems[0].Text));
                    _entity.Users.Remove(userDelete);
                    _entity.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could complete delete operation. Ensure to select a user.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            initializeUserList();
        }
    }
}
