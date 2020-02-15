using HBSDatabase;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HBSWeb
{
    public partial class SubmitRequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl_summary.Visible = false;
            btn_submit.Enabled = false;
        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            DateTime startDate = cal_start_date.SelectedDate;
            DateTime endDate = cal_end_date.SelectedDate;
            using (HBSModel _entity = new HBSModel())
            {
                HolidayRequest holidayRequest = new HolidayRequest();
                holidayRequest.StartDate = startDate;
                holidayRequest.EndDate = endDate;
                string username = Session["username"] as string;
                holidayRequest.UserID = _entity.Users.FirstOrDefault(user => user.Username == username).id;
                holidayRequest.RequestStatusID = _entity.StatusRequests.FirstOrDefault(status => status.Status == "Pending").ID;
                _entity.HolidayRequests.Add(holidayRequest);
                _entity.SaveChanges();
                Response.Redirect("/Dashboard?HolidayRequest=Success");
            }
        }

        protected void btn_preview_Click(object sender, EventArgs e)
        {
            DateTime startDate = cal_start_date.SelectedDate;
            DateTime endDate = cal_end_date.SelectedDate;
            if (startDate.Year == 0001 || endDate.Year == 0001) // Weak check
            {
                lbl_summary.Visible = true;
                lbl_summary.BackColor = System.Drawing.ColorTranslator.FromHtml("#E54B4B");
                lbl_summary.ForeColor = System.Drawing.Color.WhiteSmoke;
                lbl_summary.Text = "Error! Select both Start Date and End Date.";
            }
            else if (startDate < DateTime.Today)
            {
                lbl_summary.Visible = true;
                lbl_summary.BackColor = System.Drawing.ColorTranslator.FromHtml("#E54B4B");
                lbl_summary.ForeColor = System.Drawing.Color.WhiteSmoke;
                lbl_summary.Text = "Error! Please select a start date in the future.";
            } 
            else if (endDate < startDate)
            {
                lbl_summary.Visible = true;
                lbl_summary.BackColor = System.Drawing.ColorTranslator.FromHtml("#E54B4B");
                lbl_summary.ForeColor = System.Drawing.Color.WhiteSmoke;
                lbl_summary.Text = "Error! Start date must be before end date, if you are requesting only 1 single day, please mark the same date.";
            }
            else
            {
                lbl_summary.Visible = true;
                lbl_summary.BackColor = System.Drawing.ColorTranslator.FromHtml("#717C89");
                lbl_summary.ForeColor = System.Drawing.Color.WhiteSmoke;
                int daysRequested = endDate.DayOfYear - startDate.DayOfYear == 0 ? 1 : endDate.DayOfYear - startDate.DayOfYear + 1;
                lbl_summary.Text = "You have selected to submit a request for a total of: " + daysRequested + " day(s). From " + 
                                        startDate.Day + "-" + startDate.Month + "-" + startDate.Year + " to " +
                                            endDate.Day + "-" + endDate.Month + "-" + endDate.Year;
                btn_submit.Enabled = true;
            }
            
        }
    }
}