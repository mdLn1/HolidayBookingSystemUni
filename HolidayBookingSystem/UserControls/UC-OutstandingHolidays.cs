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

namespace HolidayBookingSystem.UserControls
{
    public partial class UC_OutstandingHolidays : UserControl
    {
        private static UC_OutstandingHolidays _instance;
        private bool isBreakingConstraints = false;

        public static UC_OutstandingHolidays Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UC_OutstandingHolidays();
                }
                return _instance;
            }
        }
        public UC_OutstandingHolidays()
        {
            InitializeComponent();
            messageLabel.Visible = false;
        }

        public void initializeRequestsList()
        {
            outstandingHolidaysListView.Items.Clear();
            try
            {
                messageLabel.Visible = false;
                using (HBSModel _entity = new HBSModel())
                {
                    var requests = _entity.HolidayRequests.ToList();
                    foreach (var request in requests)
                    {
                        string[] arr = new string[4];
                        arr[0] = request.ID.ToString();
                        arr[1] = request.StartDate.ToShortDateString();
                        arr[2] = request.EndDate.ToShortDateString();
                        arr[3] = request.NumberOfDays.ToString();
                        ListViewItem item = new ListViewItem(arr);
                        outstandingHolidaysListView.Items.Add(item);
                    }
                }
            }
            catch (Exception err)
            {
                DesktopAppUtils.popDefaultErrorMessageBox("Could not retrieve Item from DB \n" + err.Message);
            }
        }

        private void approveButton_Click(object sender, EventArgs e)
        {
            if (outstandingHolidaysListView.SelectedIndices.Count > 0)
            {
                if (isBreakingConstraints)
                {
                    if (MessageBox.Show("This holiday request is breaking constraints. Are you sure you want to approve it?", "Confirm Approval", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        approveHolidayRequest();
                    }
                }
                else
                {
                    approveHolidayRequest();
                }
            }
        }

        public void approveHolidayRequest()
        {
            int selIndex = outstandingHolidaysListView.SelectedIndices[0];
            ListViewItem item = outstandingHolidaysListView.Items[selIndex];
            using (HBSModel entity = new HBSModel())
            {
                var request = entity.HolidayRequests.Find(Convert.ToInt32(item.SubItems[0].Text));
                request.RequestStatusID = entity.StatusRequests.FirstOrDefault(x => x.Status == GeneralUtils.APPROVED).ID;
                entity.SaveChanges();
            }
            messageLabel.Visible = true;
            messageLabel.Text = "Request " + item.SubItems[0].Text + " Approved";
            messageLabel.BackColor = Color.Green;
            outstandingHolidaysListView.Items.RemoveAt(selIndex);
        }
        public void declineHolidayRequest()
        {
            int selIndex = outstandingHolidaysListView.SelectedIndices[0];
            ListViewItem item = outstandingHolidaysListView.Items[selIndex];
            using (HBSModel entity = new HBSModel())
            {
                var request = entity.HolidayRequests.Find(Convert.ToInt32(item.SubItems[0].Text));
                request.RequestStatusID = entity.StatusRequests.FirstOrDefault(x => x.Status == GeneralUtils.DECLINED).ID;
                entity.SaveChanges();
            }
            messageLabel.Visible = true;
            messageLabel.Text = "Request " + item.SubItems[0].Text + " Declined";
            messageLabel.BackColor = Color.DarkRed;
            outstandingHolidaysListView.Items.RemoveAt(selIndex);
        }

        private void declineButton_Click(object sender, EventArgs e)
        {
            if (outstandingHolidaysListView.SelectedIndices.Count > 0)
            {

                if (!isBreakingConstraints)
                {
                    if (MessageBox.Show("This holiday request is not breaking constraints. Are you sure you want to decline it?", "Confirm Decline", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        declineHolidayRequest();
                    }
                }
                else
                {
                    declineHolidayRequest();
                }
            }
        }

        private void outstandingHolidaysListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (outstandingHolidaysListView.SelectedIndices.Count > 0)
            {
                isBreakingConstraints = false;
                int selIndex = outstandingHolidaysListView.SelectedIndices[0];
                ListViewItem item = outstandingHolidaysListView.Items[selIndex];
                using (HBSModel entity = new HBSModel())
                {
                    var request = entity.HolidayRequests.Find(Convert.ToInt32(item.SubItems[0].Text));
                    if (request.ConstraintsBroken.ExceedsHolidayEntitlement)
                    {
                        firstLabel.ForeColor = Color.Red;
                        isBreakingConstraints = true;
                    }
                    else
                    {
                        firstLabel.ForeColor = Color.Green;
                    }
                    if (request.ConstraintsBroken.HeadOrDeputy)
                    {
                        secondLabel.ForeColor = Color.Red;
                        isBreakingConstraints = true;
                    }
                    else
                    {
                        secondLabel.ForeColor = Color.Green;
                    }
                    if (request.ConstraintsBroken.ManagerOrSenior)
                    {
                        thirdLabel.ForeColor = Color.Red;
                        isBreakingConstraints = true;
                    }
                    else
                    {
                        thirdLabel.ForeColor = Color.Green;
                    }
                    if (request.ConstraintsBroken.AtLeastPercentage)
                    {
                        fourthLabel.ForeColor = Color.Red;
                        isBreakingConstraints = true;
                    }
                    else
                    {
                        fourthLabel.ForeColor = Color.Green;
                    }
                }
            }
        }
    }
}
