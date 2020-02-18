using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HBSDatabase;

namespace HBSWeb
{
    public partial class RequestsHistory : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (HBSModel _entity = new HBSModel())
            {
                int userId = (int) Session["userId"];
                var userHolidayRequests = _entity.HolidayRequests.Where(request => request.UserID == userId)
                    .OrderByDescending(x => x.StartDate).ToList();
                foreach (HolidayRequest hRequest in userHolidayRequests)
                {
                    TableRow newRow = new TableRow();
                    TableCell StartDate = new TableCell();
                    StartDate.Text = hRequest.StartDate.Day.ToString() + "/" + hRequest.StartDate.Month.ToString() + "/" + hRequest.StartDate.Year.ToString();
                    TableCell EndDate = new TableCell();
                    EndDate.Text = hRequest.EndDate.Day.ToString() + "/" + hRequest.EndDate.Month.ToString() + "/" + hRequest.EndDate.Year.ToString();
                    TableCell Duration = new TableCell();
                    Duration.Text = (hRequest.EndDate.DayOfYear - hRequest.StartDate.DayOfYear + 1).ToString();
                    TableCell Status = new TableCell();
                    Status.Text = hRequest.StatusRequest.Status;
                    newRow.Cells.Add(StartDate);
                    newRow.Cells.Add(EndDate);
                    newRow.Cells.Add(Duration);
                    newRow.Cells.Add(Status);
                    if (hRequest.StatusRequest.Status == "Pending")
                    {
                        newRow.CssClass = "warning";
                    }
                    if (hRequest.StatusRequest.Status == "Accepted")
                    {
                        newRow.CssClass = "success";
                    }
                    if (hRequest.StatusRequest.Status == "Rejected")
                    {
                        newRow.CssClass = "danger";
                    }
                    RequestHistoryTable.Rows.Add(newRow);
                }
            }
        }
    }
}