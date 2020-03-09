using HBSDatabase;
using SolutionUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace HBSWeb
{
    [WebService(Namespace = "http://holidaybookingsystem.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
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
                    return false;
                }
                if (!GeneralUtils.VerifyPasswordHash(password, _user.Pwd, _user.PwdSalt) || _user.Role.RoleName == GeneralUtils.ADMIN_ROLE)
                {
                    return false;
                }

                Session["userId"] = _user.id;
            }
            return true;
        }

        [WebMethod(EnableSession = true)]
        public bool HolidayRequest(DateTime startDate, DateTime endDate, int workingDays)
        {
            if (startDate > endDate || startDate < DateTime.Now.AddDays(2) || workingDays == 0)
            {
                return false;
            }
            try
            {
                using (HBSModel _entity = new HBSModel())
                {
                    var userId = (int)Session["userId"];
                    HolidayRequest holidayRequest = new HolidayRequest()
                    {
                        StartDate = startDate,
                        EndDate = endDate,
                        UserID = userId,
                        NumberOfDays = workingDays
                    };
                    var usr = _entity.Users.Find(userId);
                    holidayRequest.RequestStatusID = _entity.StatusRequests
                        .FirstOrDefault(status => status.Status == GeneralUtils.PENDING).ID;
                    holidayRequest.ConstraintsBroken = new ConstraintChecking(usr, holidayRequest).getBrokenConstraints();
                    holidayRequest.DaysPeakTime = PrioritiseRequests.daysFallPeakTimes(holidayRequest);
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
