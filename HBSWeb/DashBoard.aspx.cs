using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HBSWeb
{
    public partial class DashBoard1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["HolidayRequest"] == "Success")
            {
                HolidayRequestAlert.Visible = true;
            }
        }
    }
}