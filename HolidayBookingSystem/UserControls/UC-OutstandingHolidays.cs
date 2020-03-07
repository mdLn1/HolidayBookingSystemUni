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
using SolutionUtils;
using static SolutionUtils.PriorityRequest;

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
            firstConstraintLabel.Text = GeneralUtils.CONSTRAINT_HOLIDAY_ENTITLEMENT_EXCEEDED;
            secondConstraintLabel.Text = GeneralUtils.CONSTRAINT_DEPUTY_OR_HEAD;
            thirdConstraintLabel.Text = GeneralUtils.CONSTRAINT_MINIMUM_SENIOR_OR_MANAGERS;
            fourthConstraintLabel.Text = GeneralUtils.CONSTRAINT_AT_LEAST_60_PERCENT;
            messageLabel.Visible = false;
            suggestionsButton.Visible = false;
        }

        public void initializeRequestsList()
        {
            outstandingHolidaysListView.Items.Clear();
            try
            {
                messageLabel.Visible = false;
                using (HBSModel _entity = new HBSModel())
                {
                    var prioritiseReqs = (from el in _entity.HolidayRequests
                                          where el.StatusRequest.Status == GeneralUtils.PENDING
                                          select new PriorityRequest()
                                          {
                                              Constraints = new BreakingConstraints()
                                              {
                                                  AtLeastPercentage = el.ConstraintsBroken.AtLeastPercentage,
                                                  ExceedsHolidayEntitlement = el.ConstraintsBroken.ExceedsHolidayEntitlement,
                                                  HeadOrDeputy = el.ConstraintsBroken.HeadOrDeputy,
                                                  ManagerOrSenior = el.ConstraintsBroken.ManagerOrSenior
                                              },
                                              WorkingDays = el.NumberOfDays,
                                              DaysPeakTime = el.DaysPeakTime,
                                              EndDate = el.EndDate,
                                              ID = el.ID,
                                              RemainingDays = el.User.RemainingDays,
                                              StartDate = el.StartDate
                                          }).ToList();
                    var ordered = new PrioritiseRequests(prioritiseReqs).getPrioritisedRequests();
                    foreach (var request in ordered)
                    {
                        string[] arr = new string[4];
                        arr[0] = request.ID.ToString();
                        arr[1] = request.StartDate.ToShortDateString();
                        arr[2] = request.EndDate.ToShortDateString();
                        arr[3] = request.WorkingDays.ToString();
                        ListViewItem item = new ListViewItem(arr);
                        if (breaksConstraint(request.Constraints))
                            item.BackColor = Color.SandyBrown;
                        else
                            item.BackColor = Color.Lime;

                        outstandingHolidaysListView.Items.Add(item);
                    }
                }
            }
            catch (Exception err)
            {
                DesktopAppUtils.popDefaultErrorMessageBox("Could not retrieve Item from DB \n" + err.Message);
            }
        }

        public bool breaksConstraint(BreakingConstraints constraint)
        {
            if (constraint.AtLeastPercentage
                        || constraint.ExceedsHolidayEntitlement || constraint.ManagerOrSenior
                            || constraint.HeadOrDeputy)
                return true;
            return false;
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
                request.User.RemainingDays = request.User.RemainingDays - request.NumberOfDays;
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
                messageLabel.Visible = false;
                isBreakingConstraints = false;
                int selIndex = outstandingHolidaysListView.SelectedIndices[0];
                ListViewItem item = outstandingHolidaysListView.Items[selIndex];
                using (HBSModel entity = new HBSModel())
                {
                    var request = entity.HolidayRequests.Find(Convert.ToInt32(item.SubItems[0].Text));
                    
                    if(ConstraintChecking.areAnyConstraintsBroken(request.ConstraintsBroken)
                        && request.DaysPeakTime > 0 && request.DaysPeakTime < 16)
                    {
                        suggestionsButton.Visible = true;
                    } else
                    {
                        suggestionsButton.Visible = false;
                    }
                    if (request.ConstraintsBroken.ExceedsHolidayEntitlement)
                    {
                        firstConstraintLabel.ForeColor = Color.Red;
                        isBreakingConstraints = true;
                    }
                    else
                    {
                        firstConstraintLabel.ForeColor = Color.Green;
                    }
                    if (request.ConstraintsBroken.HeadOrDeputy)
                    {
                        secondConstraintLabel.ForeColor = Color.Red;
                        isBreakingConstraints = true;
                    }
                    else
                    {
                        secondConstraintLabel.ForeColor = Color.Green;
                    }
                    if (request.ConstraintsBroken.ManagerOrSenior)
                    {
                        thirdConstraintLabel.ForeColor = Color.Red;
                        isBreakingConstraints = true;
                    }
                    else
                    {
                        thirdConstraintLabel.ForeColor = Color.Green;
                    }
                    if (request.ConstraintsBroken.AtLeastPercentage)
                    {
                        if (request.StartDate.Month == 8 || request.EndDate.Month == 8)
                            fourthConstraintLabel.Text = GeneralUtils.CONSTRAINT_AT_LEAST_40_PERCENT;
                        else
                            fourthConstraintLabel.Text = GeneralUtils.CONSTRAINT_AT_LEAST_60_PERCENT;
                        fourthConstraintLabel.ForeColor = Color.Red;
                        isBreakingConstraints = true;
                    }
                    else
                    {
                        fourthConstraintLabel.ForeColor = Color.Green;
                    }
                }
            }
        }
    }
}
