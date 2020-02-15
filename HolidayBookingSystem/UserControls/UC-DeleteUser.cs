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
                        string[] arr = new string[7];
                        arr[0] = usr.id.ToString();
                        arr[1] = usr.Username;
                        arr[2] = usr.StartDate.ToString().Substring(0,10);
                        arr[3] = usr.RemainingDays.ToString() == "" ? "N/A" : usr.RemainingDays.ToString();
                        arr[4] = usr.Role.RoleName;
                        arr[5] = usr.Department.DepartmentName;
                        arr[6] = usr.PhoneNumber == null ? "N/A" : usr.PhoneNumber;
                        ListViewItem item = new ListViewItem(arr);
                        lv_users.Items.Add(item);
                    }
                }
            }
            catch (Exception err)
            {
                Utils.popDefaultErrorMessageBox("Could not retrieve Item from DB \n" + err.Message);
            }
        }



        private void btn_delete_Click(object sender, EventArgs e)
        {
            try {
                
                   
                
                int selIndex = lv_users.SelectedIndices[0];
                ListViewItem item = lv_users.Items[selIndex];
                if (MessageBox.Show("Are you sure you want to delete this record?", "Confirm deletion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (HBSModel _entity = new HBSModel())
                    {
                        User userDelete = _entity.Users.Find(Convert.ToInt32(item.SubItems[0].Text));
                        _entity.Users.Remove(userDelete);
                        _entity.SaveChanges();
                    }
                    initializeUserList();
                }
            }
            catch (Exception ex)
            {
                Utils.popDefaultErrorMessageBox("Could not complete delete operation. Ensure to select a user.\n" + ex.Message);
            }
            
            
        }
    }
}
