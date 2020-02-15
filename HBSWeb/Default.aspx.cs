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
            lbl_errorMsg.Visible = false;
        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            try
            {
                string username = tb_username.Text.Trim();
                string password = tb_password.Text.Trim();
                using (HBSModel _entity = new HBSModel())
                {
                    var _user = _entity.Users.FirstOrDefault(x => x.Username == username);
                    if (_user != null)
                    {
                        if (!Utils.VerifyPasswordHash(password, _user.Pwd, _user.PwdSalt))
                        {
                            lbl_errorMsg.Visible = true;
                            lbl_errorMsg.Text = "Password not correct.\nTry Again!";
                        }
                        else
                        {
                            Session["username"] = _user.Username;
                            Response.Redirect("Dashboard");
                        }
                    }
                    else
                    {
                        lbl_errorMsg.Visible = true;
                        lbl_errorMsg.Text = "Username not registered.\n Try Again!";
                    }

                }
            }
            catch (Exception ex)
            {
                Response.Write("Something Failed During Login"+ex.Message);
            }
        }
    }


}