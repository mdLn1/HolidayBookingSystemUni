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
        public int EmployeeLogin(string username, string password)
        {
            using (HBSModel _entity = new HBSModel())
            {
                var _user = _entity.Users.FirstOrDefault(x => x.Username == username);
                if (_user == null)
                {
                    return -1;
                }
                if (!GeneralUtils.VerifyPasswordHash(password, _user.Pwd, _user.PwdSalt) || _user.Role.RoleName == GeneralUtils.ADMIN_ROLE)
                {
                    return -2;
                }

                return 1;
            }
        }

        [WebMethod(EnableSession = true)]
        public int HolidayRequest(DateTime startDate, DateTime endDate, int workingDays, string username, string password)
        {
            if (startDate > endDate || startDate < DateTime.Now.AddDays(2) || workingDays == 0)
            {
                return -4;
            }
            try
            {
                using (HBSModel _entity = new HBSModel())
                {
                    var _user = _entity.Users.FirstOrDefault(x => x.Username == username);
                    if (_user == null)
                    {
                        return -1;
                    }
                    if (!GeneralUtils.VerifyPasswordHash(password, _user.Pwd, _user.PwdSalt) || _user.Role.RoleName == GeneralUtils.ADMIN_ROLE)
                    {
                        return -2;
                    }
                    HolidayRequest holidayRequest = new HolidayRequest()
                    {
                        StartDate = startDate,
                        EndDate = endDate,
                        UserID = _user.id,
                        NumberOfDays = workingDays
                    };
                    holidayRequest.RequestStatusID = _entity.StatusRequests
                        .FirstOrDefault(status => status.Status == GeneralUtils.PENDING).ID;
                    holidayRequest.ConstraintsBroken = new ConstraintChecking(_user, holidayRequest).getBrokenConstraints();
                    holidayRequest.DaysPeakTime = PrioritiseRequests
                        .daysFallPeakTimesCount(holidayRequest.StartDate, holidayRequest.EndDate);
                    _entity.HolidayRequests.Add(holidayRequest);
                    _entity.SaveChanges();
                }
            }
            catch
            {
                return -3;
            }
            return 1;
        }
    }
}
