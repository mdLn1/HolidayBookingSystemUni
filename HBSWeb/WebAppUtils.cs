using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace HBSWeb
{
    public class WebAppUtils
    {
        public static string genAlert(string type, string msg)
        {
            string returnMsg = "<div='container'><div class='" + type + " alert-danger' role='alert'>" + msg + "</ div ></div>";
            return returnMsg;
        }
    }
}