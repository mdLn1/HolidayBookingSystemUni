using HBSDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBSWeb
{
    public class ConstraintChecking
    {
        private HolidayRequest holidayRequest;
        private User user;
        private HBSModel entity;
        private List<string> brokenConstraints;
        public ConstraintChecking(User user, HolidayRequest holidayRequest)
        {
            this.holidayRequest = holidayRequest;
            entity = new HBSModel();
            this.user = user;
            brokenConstraints = new List<string>();
        }

        public List<string> getBrokenConstraints()
        {
            var peakTimes = entity.PeakTimes.ToList();
            if (peakTimes.Any(x => x.NoConstraintsApply && holidayRequest.StartDate >= x.StartDate
                 && holidayRequest.EndDate <= x.EndDate))
            {
                return new List<string>();
            }
            string userRole = user.Role.RoleName;
            if (isHolidayAllowanceExceeded())
                brokenConstraints.Add("Exceeds the number of days of holiday entitlement");
            if (userRole == GeneralUtils.HEAD_ROLE || userRole == GeneralUtils.DEPUTY_HEAD_ROLE)
            {
                if (isDeputyOrHeadOnHolidayAlready(userRole == GeneralUtils.HEAD_ROLE
                    ? GeneralUtils.HEAD_ROLE : GeneralUtils.DEPUTY_HEAD_ROLE))
                    brokenConstraints.Add("Either the head or the deputy head of the department must be on duty");
            }
            if (userRole == GeneralUtils.SENIOR_ROLE || userRole == GeneralUtils.MANAGER_ROLE)
            {
                if (isNotMinimumNumberOfManagersOrSeniors(GeneralUtils.MINIMUM_NUMBER_MANAGERS_OR_SENIORS))
                {
                    brokenConstraints.Add("At least one manager and one senior staff member must be on duty");
                }
            }
            double requiredPercentage = GeneralUtils.REQUIRED_PERCENTAGE_AT_LEAST_MAX;

            if (holidayRequest.StartDate.Month == GeneralUtils.AUGUST
                && holidayRequest.EndDate.Month == GeneralUtils.AUGUST)
            {
                requiredPercentage = GeneralUtils.REQUIRED_PERCENTAGE_AT_LEAST_MIN;
            }
            if (areThereNotEnoughEmployeesWorking(requiredPercentage))
            {
                brokenConstraints.Add("At least" + requiredPercentage + "% of a department must be on duty");
            }
            return brokenConstraints;
        }

        private bool isHolidayAllowanceExceeded()
        {
            return user.RemainingDays < holidayRequest.NumberOfDays;
        }

        private bool isDeputyOrHeadOnHolidayAlready(string role)
        {
            var roleId = entity.Roles.FirstOrDefault(x => x.RoleName == role).ID;
            var holidays = entity.Users
                .FirstOrDefault(x => x.DepartmentID == user.DepartmentID && x.RoleID == roleId)
                .HolidayRequests.Where(x => x.StatusRequest.Status == GeneralUtils.APPROVED && x.EndDate > DateTime.Now);
            if (holidays.Any(x => x.EndDate > DateTime.Now && (x.EndDate > holidayRequest.StartDate && x.EndDate < holidayRequest.EndDate)
                 || (x.StartDate < holidayRequest.EndDate && x.StartDate > holidayRequest.StartDate)
                 || (x.StartDate < holidayRequest.StartDate && x.EndDate > holidayRequest.EndDate)))
            {
                return true;
            }
            return false;
        }

        private bool isNotMinimumNumberOfManagersOrSeniors(int min)
        {
            var colleagues = entity.Users.Where(x => x.DepartmentID == user.DepartmentID
                && x.RoleID == user.RoleID && x.id != user.id);
            int numOfColleagues = colleagues.Count();
            foreach (var usr in colleagues)
            {
                if (usr.HolidayRequests.Any(x => x.EndDate > DateTime.Now
                    && (x.EndDate > holidayRequest.StartDate && x.EndDate < holidayRequest.EndDate)
                  || (x.StartDate < holidayRequest.EndDate && x.StartDate > holidayRequest.StartDate)
                  || (x.StartDate < holidayRequest.StartDate && x.EndDate > holidayRequest.EndDate)))
                {
                    numOfColleagues--;
                }
            }
            return numOfColleagues > 0;
        }

        private bool areThereNotEnoughEmployeesWorking(double percentage)
        {
            var employeesByDepartment = entity.Users.Where(x => x.DepartmentID == user.DepartmentID);
            double numEmployees = employeesByDepartment.Count();
            double onHolidayEmployees = 0;
            foreach (var employee in employeesByDepartment)
            {
                if (employee.HolidayRequests.Any(x => x.EndDate > DateTime.Now
                     && (x.EndDate > holidayRequest.StartDate && x.EndDate < holidayRequest.EndDate)
                   || (x.StartDate < holidayRequest.EndDate && x.StartDate > holidayRequest.StartDate)
                   || (x.StartDate < holidayRequest.StartDate && x.EndDate > holidayRequest.EndDate)))
                {
                    onHolidayEmployees++;
                }
            }
            return (onHolidayEmployees / numEmployees) > percentage;
        }

    }
}
