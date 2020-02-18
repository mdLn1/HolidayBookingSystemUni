using HBSDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HBSWeb
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            errorMessageLabel.Visible = false;
        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            try
            {
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
                                Response.Redirect("Dashboard");
                                return;
                            } else
                            {
                                errorMessageLabel.Visible = true;
                                errorMessageLabel.Text = "Admins cannot login through this website";
                            }
                        }
                    }
                    errorMessageLabel.Visible = true;
                    errorMessageLabel.Text = "Incorrect login details";

                }
            }
            catch (Exception ex)
            {
                Response.Write("Something Failed During Login"+ex.Message);
            }
        }
    }


}