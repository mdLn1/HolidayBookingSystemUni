using HBSDatabase;
using SolutionUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace HBSWebService
{
    /// <summary>
    /// Summary description for EmployeeService
    /// </summary>
    [WebService(Namespace = "http://holidaybookingsystem.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class EmployeeService : WebService
    {

        [WebMethod(EnableSession = true)]
        public bool EmployeeLogin(string username, string password)
        {
            using (HBSModel _entity = new HBSModel())
            {
                var _user = _entity.Users.FirstOrDefault(x => x.Username == username);
                if (_user == null)
                {
                    //return new ErrorResponse("User not found");
                    return false;
                }
                if (!GeneralUtils.VerifyPasswordHash(password, _user.Pwd, _user.PwdSalt) || _user.Role.RoleName == GeneralUtils.ADMIN_ROLE)
                {
                    //return new ErrorResponse("Invalid login attempt");
                    return false;
                }

                Session["userId"] = _user.id;
            }
            return true;
        }

        [WebMethod(EnableSession = true)]
        public bool HolidayRequest(DateTime startDate, DateTime endDate, int workingDays)
        {
            try
            {
                using (HBSModel _entity = new HBSModel())
                {
                    HolidayRequest holidayRequest = new HolidayRequest()
                    {
                        StartDate = startDate,
                        EndDate = endDate,
                        UserID = (int)Session["userId"],
                        NumberOfDays = workingDays
                    };
                    holidayRequest.RequestStatusID = _entity.StatusRequests
                        .FirstOrDefault(status => status.Status == GeneralUtils.PENDING).ID;
                    _entity.HolidayRequests.Add(holidayRequest);
                    _entity.SaveChanges();
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
    }


}
