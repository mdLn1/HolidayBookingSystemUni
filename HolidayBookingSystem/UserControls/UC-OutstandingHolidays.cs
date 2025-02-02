﻿using System;
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
        private ListViewItem selectedItem;
        private int currentlySelectedIndex;

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
            suggestionsButton.Visible = false;
            suggestionsPanel.Controls.Add(UC_Suggestions.Instance);
            UC_Suggestions.Instance.Dock = DockStyle.Fill;
            UC_Suggestions.Instance.Hide();
            initializeConstraintsLabels();
        }

        private void initializeConstraintsLabels()
        {
            firstConstraintLabel.Text = GeneralUtils.CONSTRAINT_HOLIDAY_ENTITLEMENT_EXCEEDED;
            secondConstraintLabel.Text = GeneralUtils.CONSTRAINT_DEPUTY_OR_HEAD;
            thirdConstraintLabel.Text = GeneralUtils.CONSTRAINT_MINIMUM_SENIOR_OR_MANAGERS;
            fourthConstraintLabel.Text = GeneralUtils.CONSTRAINT_AT_LEAST_60_PERCENT;
            firstConstraintLabel.ForeColor = Color.Black;
            secondConstraintLabel.ForeColor = Color.Black;
            thirdConstraintLabel.ForeColor = Color.Black;
            fourthConstraintLabel.ForeColor = Color.Black;
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
                                              StartDate = el.StartDate,
                                              InitialHolidayEntitlement = el.User.InitialHolidayEntitlement,
                                              TotalPeakDaysHoliday = el.User.TotalPeakDaysHoliday
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
                        if (PriorityRequest.isAnyConstraintBroken(request.Constraints))
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



        private void approveButton_Click(object sender, EventArgs e)
        {
            if (outstandingHolidaysListView.SelectedIndices.Count > 0)
            {
                if (isBreakingConstraints)
                {
                    if (MessageBox.Show("This holiday request is breaking constraints. Are you sure you want to approve it?",
                        "Confirm Approval", MessageBoxButtons.YesNo) == DialogResult.Yes)
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

        private void approveHolidayRequest()
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
        private void declineHolidayRequest()
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
                    if (MessageBox.Show("This holiday request is not breaking constraints. Are you sure you want to decline it?",
                        "Confirm Decline", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
                groupBox3.BringToFront();
                UC_Suggestions.Instance.Hide();
                messageLabel.Visible = false;
                isBreakingConstraints = false;
                currentlySelectedIndex = outstandingHolidaysListView.SelectedIndices[0];
                selectedItem = outstandingHolidaysListView.Items[currentlySelectedIndex];
                using (HBSModel entity = new HBSModel())
                {
                    var request = entity.HolidayRequests.Find(Convert.ToInt32(selectedItem.SubItems[0].Text));
                    
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

        public void ConfirmSuggestion(DateTime startDate, DateTime endDate)
        {
            messageLabel.Text = "Request ID " + selectedItem.SubItems[0].Text + " was sent back for approval";
            messageLabel.BackColor = Color.DarkOrange;
            messageLabel.Visible = true;
            using (HBSModel entity = new HBSModel())
            {
                var request = entity.HolidayRequests.Find(Convert.ToInt32(selectedItem.SubItems[0].Text));
                request.RequestStatusID = entity.StatusRequests.FirstOrDefault(x => x.Status == GeneralUtils.CHANGED).ID;
                request.StartDate = startDate;
                request.EndDate = endDate;
                entity.SaveChanges();
            }
            selectedItem = null;
            outstandingHolidaysListView.Items.RemoveAt(currentlySelectedIndex);
            UC_Suggestions.Instance.Hide();
            initializeConstraintsLabels();
        }

        private void suggestionsButton_Click(object sender, EventArgs e)
        {
            if (selectedItem != null)
            {
                if (suggestionsPanel.Contains(groupBox3))
                {
                    groupBox3.SendToBack();
                    UC_Suggestions.Instance.Show();
                    UC_Suggestions.Instance.BringToFront();
                    UC_Suggestions.Instance.clearSuggestions();
                    using (HBSModel entity = new HBSModel())
                    {
                        var request = entity.HolidayRequests.Find(Convert.ToInt32(selectedItem.SubItems[0].Text));
                        UC_Suggestions.Instance.findSuggestions(request);
                    }
                }
                
            }
        }
    }
}
