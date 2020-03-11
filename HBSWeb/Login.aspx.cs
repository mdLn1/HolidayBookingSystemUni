using HBSDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HBSWeb
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["logout"] == "Success")
            {
                Session.Clear();
                LogoutMessageAlert.Visible = true;
            }
            if (Session["userId"] != null)
            {
                Response.Redirect("EmployeeHome");
            }
            errorMessageLabel.Visible = false;
        }

        protected void loginRequest(object sender, EventArgs e)
        {
            try
            {
                LogoutMessageAlert.Visible = false;

                string username = usernameTextBox.Text.Trim();
                string password = passwordTextBox.Text.Trim();
                using (HBSModel _entity = new HBSModel())
                {
                    var _user = _entity.Users.FirstOrDefault(x => x.Username == username);
                    if (_user != null)
                    {
                        if (GeneralUtils.VerifyPasswordHash(password, _user.Pwd, _user.PwdSalt))
                        {
                            if(_user.Role.RoleName != GeneralUtils.ADMIN_ROLE)
                            {
                                Session["username"] = _user.Username;
                                Session["userId"] = _user.id;
                                Response.Redirect("EmployeeHome");
                                return;
                            }
                        }
                    }
                    errorMessageLabel.Visible = true;
                    errorMessageLabel.Text = "Incorrect login details";

                }
            }
            catch (Exception ex)
            {
                Response.Write("Server encountered an issue during login " + ex.Message);
            }
        }
    }


}