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
                foreach (var holidayRequest in userHolidayRequests)
                {
                    TableRow tableRow = new TableRow();
                    var requestStatus = holidayRequest.StatusRequest.Status;
                    TableCell startDate = new TableCell
                    {
                        Text = holidayRequest.StartDate.ToShortDateString()
                    };
                    TableCell endDate = new TableCell
                    {
                        Text = holidayRequest.EndDate.ToShortDateString()
                    };
                    TableCell duration = new TableCell
                    {
                        Text = (holidayRequest.EndDate - holidayRequest.StartDate).Days.ToString()
                    };
                    TableCell status = new TableCell
                    {
                        Text = requestStatus
                    };
                    tableRow.Cells.Add(startDate);
                    tableRow.Cells.Add(endDate);
                    tableRow.Cells.Add(duration);
                    tableRow.Cells.Add(status);
                    
                    if (requestStatus == GeneralUtils.PENDING)
                    {
                        tableRow.CssClass = "warning";
                    }
                    else if (requestStatus == GeneralUtils.APPROVED)
                    {
                        tableRow.CssClass = "success";
                    }
                    else { 
                        tableRow.CssClass = "danger";
                    }
                    RequestHistoryTable.Rows.Add(tableRow);
                }
            }
        }
    }
}