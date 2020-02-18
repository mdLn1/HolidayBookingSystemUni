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
    public partial class SubmitRequest : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl_summary.Visible = false;
            submitButton.Enabled = false;
        }

        protected void submitHolidayRequest(object sender, EventArgs e)
        {
            DateTime startDate = startDateCalendar.SelectedDate;
            DateTime endDate = endDateCalendar.SelectedDate;
            using (HBSModel _entity = new HBSModel())
            {
                HolidayRequest holidayRequest = new HolidayRequest()
                {
                    StartDate = startDate,
                    EndDate = endDate,
                    UserID = (int)Session["userId"]
                };
                holidayRequest.RequestStatusID = _entity.StatusRequests.FirstOrDefault(status => status.Status == "Pending").ID;
                _entity.HolidayRequests.Add(holidayRequest);
                _entity.SaveChanges();
                Response.Redirect("/Dashboard?HolidayRequest=Success");
            }
        }

        protected void displayHolidaySummary(string text, string color)
        {
            lbl_summary.Visible = true;
            lbl_summary.BackColor = ColorTranslator.FromHtml(color);
            lbl_summary.ForeColor = Color.Beige;
            lbl_summary.Text = text;
        }

        protected void verifySelectedDate(object sender, EventArgs e)
        {
            Calendar calendar = (Calendar)sender;
            if(calendar.ID == startDateCalendar.ID)
            {
                if(startDateCalendar.SelectedDate < DateTime.Today)
                {
                    displayHolidaySummary("Please select a start date in the future.", GeneralUtils.DANGER_COLOR);
                }
            } else
            {
                if(endDateCalendar.SelectedDate < startDateCalendar.SelectedDate)
                {
                    displayHolidaySummary("Start date must be before end date", GeneralUtils.DANGER_COLOR);

                } else
                {
                    DateTime startDate = startDateCalendar.SelectedDate;
                    DateTime endDate = endDateCalendar.SelectedDate;
                    int daysRequested = endDate.DayOfYear - startDate.DayOfYear == 0 ? 1 : endDate.DayOfYear - startDate.DayOfYear + 1;
                    displayHolidaySummary("You have selected to submit a request for a total of: " + daysRequested + " day(s). From " +
                                            startDate.ToShortDateString() + " to " +
                                                endDate.ToShortDateString(), GeneralUtils.SUCCESS_COLOR);
                    submitButton.BackColor = ColorTranslator.FromHtml(GeneralUtils.SUCCESS_COLOR);
                    submitButton.BorderColor = ColorTranslator.FromHtml(GeneralUtils.SUCCESS_COLOR);
                    submitButton.Enabled = true;
                    
                }
            }
        }

    }
}