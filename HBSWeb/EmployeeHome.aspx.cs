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
            if (Request.QueryString["HolidayRequest"] == "Success")
            {
                HolidayRequestAlert.Visible = true;
            }

            using (HBSModel _entity = new HBSModel())
            {
                int userId = (int) Session["userId"];
                var userHolidayRequests = _entity.HolidayRequests.Where(request => request.UserID == userId)
                    .OrderByDescending(x => x.StartDate).ToList();
                foreach (var holidayRequest in userHolidayRequests)
                {
                    TableRow tableRow = new TableRow();

                    var requestStatus = holidayRequest.StatusRequest.Status;

                    tableRow.Cells.Add(new TableCell
                    {
                        Text = holidayRequest.StartDate.ToShortDateString()
                    });

                    tableRow.Cells.Add(new TableCell
                    {
                        Text = holidayRequest.EndDate.ToShortDateString()
                    });
                    tableRow.Cells.Add(new TableCell
                    {
                        Text = holidayRequest.NumberOfDays.ToString()
                    });
                    tableRow.Cells.Add(new TableCell
                    {
                        Text = requestStatus.ToUpper()
                    });
                    
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
                    requestsTable.Rows.Add(tableRow);
                }
            }
        }
    }
}