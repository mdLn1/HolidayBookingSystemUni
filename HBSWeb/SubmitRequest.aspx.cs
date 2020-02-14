using HBSDatabase;
using System;
using System.Collections.Generic;
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
                _entity.HolidayRequests.Add(holidayRequest);
                _entity.SaveChanges();
                Response.Redirect("/Dashboard");
            }
        }
    }
}