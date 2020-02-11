using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HBSDatabase;

namespace HBSWeb
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (HBSModel _entity = new HBSModel())
            {
                var _users = _entity.Users.ToList();
                Console.WriteLine(_users[0].Username);
            }
        }
    }
}