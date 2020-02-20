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
            holidaRequestMessage.Visible = false;
            submitButton.Enabled = false;
        }

        protected void submitHolidayRequest(object sender, EventArgs e)
        {
            DateTime startDate = startDateCalendar.SelectedDate;
            DateTime endDate = endDateCalendar.SelectedDate;
            int workingDays = GeneralUtils.CalculateWorkingDays(endDate, startDate);
            using (HBSModel _entity = new HBSModel())
            {

                HolidayRequest holidayRequest = new HolidayRequest()
                {
                    StartDate = startDate,
                    EndDate = endDate,
                    UserID = (int)Session["userId"],
                    NumberOfDays = workingDays
                };
                holidayRequest.RequestStatusID = _entity.StatusRequests
                    .FirstOrDefault(status => status.Status == GeneralUtils.PENDING).ID;
                _entity.HolidayRequests.Add(holidayRequest);
                _entity.SaveChanges();
                Response.Redirect("/EmployeeHome?HolidayRequest=Success");
            }
        }

        protected void displayHolidaySummary(string text, string color)
        {
            holidaRequestMessage.Visible = true;
            holidaRequestMessage.BackColor = ColorTranslator.FromHtml(color);
            holidaRequestMessage.ForeColor = Color.Beige;
            holidaRequestMessage.Text = text;
        }

        protected void verifySelectedDate(object sender, EventArgs e)
        {
            Calendar calendar = (Calendar)sender;
            if (calendar.ID == startDateCalendar.ID)
            {
                if (startDateCalendar.SelectedDate < DateTime.Today.AddDays(5))
                {
                    startDateCalendar.SelectedDates.Clear();
                    displayHolidaySummary("Please select a start date for at least 5 days in future.", GeneralUtils.DANGER_COLOR);
                }
                endDateCalendar.SelectedDates.Clear();
                submitButton.BackColor = ColorTranslator.FromHtml(GeneralUtils.DANGER_COLOR);
                submitButton.BorderColor = ColorTranslator.FromHtml(GeneralUtils.DANGER_COLOR);
                submitButton.Enabled = false;
            }
            else
            {
                if (startDateCalendar.SelectedDate < DateTime.Today)
                {
                    endDateCalendar.SelectedDates.Clear();
                    displayHolidaySummary("Please select a start date first.", GeneralUtils.DANGER_COLOR);
                    return;
                }

                if (endDateCalendar.SelectedDate < startDateCalendar.SelectedDate)
                {
                    endDateCalendar.SelectedDates.Clear();
                    displayHolidaySummary("End date must come after start date", GeneralUtils.DANGER_COLOR);
                }
                else
                {
                    DateTime startDate = startDateCalendar.SelectedDate;
                    DateTime endDate = endDateCalendar.SelectedDate;
                    int workingDays = GeneralUtils.CalculateWorkingDays(startDate, endDate);
                    if (workingDays == 0)
                    {
                        displayHolidaySummary("You selected weekend days, no need for holiday allowance", GeneralUtils.WARNING_COLOR);
                    }
                    else if (workingDays > GeneralUtils.MAX_POSSIBLE_HOLIDAY)
                    {
                        displayHolidaySummary("Too many days selected, it exceeds the maximum allowance", GeneralUtils.DANGER_COLOR);
                    }
                    else
                    {
                        displayHolidaySummary("You requested " + workingDays + " day(s) of holiday allowance from " +
                                            startDate.ToShortDateString() + " to " +
                                                endDate.ToShortDateString() + ". Please submit if you are satisfied with your selection", GeneralUtils.SUCCESS_COLOR);
                        submitButton.BackColor = ColorTranslator.FromHtml(GeneralUtils.SUCCESS_COLOR);
                        submitButton.BorderColor = ColorTranslator.FromHtml(GeneralUtils.SUCCESS_COLOR);
                        submitButton.Enabled = true;
                    }


                }
            }
        }

    }
}