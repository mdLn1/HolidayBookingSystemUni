using HBSDatabase;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SolutionUtils
{
    public class ConstraintChecking
    {
        private HolidayRequest holidayRequest;
        private User user;
        private HBSModel entity;
        //private List<string> brokenConstraints;
        public ConstraintChecking(User user, HolidayRequest holidayRequest)
        {
            this.holidayRequest = holidayRequest;
            entity = new HBSModel();
            this.user = user;
            //brokenConstraints = new List<string>();
        }

        public ConstraintsBroken getBrokenConstraints()
        {
            ConstraintsBroken constraintsBroken = new ConstraintsBroken();
            if (GeneralUtils.noConstraintsApply.Any(x => holidayRequest.StartDate >= x.StartDate
                 && holidayRequest.EndDate <= x.EndDate))
            {
                return constraintsBroken;
            }
            string userRole = user.Role.RoleName;
            if (isHolidayAllowanceExceeded())
                constraintsBroken.ExceedsHolidayEntitlement = true;
                //brokenConstraints.Add("Exceeds the number of days of holiday entitlement");
            if (userRole == GeneralUtils.HEAD_ROLE || userRole == GeneralUtils.DEPUTY_HEAD_ROLE)
            {
                if (isDeputyOrHeadOnHolidayAlready(userRole == GeneralUtils.DEPUTY_HEAD_ROLE
                    ? GeneralUtils.HEAD_ROLE : GeneralUtils.DEPUTY_HEAD_ROLE))
                    constraintsBroken.HeadOrDeputy = true;
                    //brokenConstraints.Add("Either the head or the deputy head of the department must be on duty");
            }
            if (userRole == GeneralUtils.SENIOR_ROLE || userRole == GeneralUtils.MANAGER_ROLE)
            {
                if (isNotMinimumNumberOfManagersOrSeniors(GeneralUtils.MINIMUM_NUMBER_MANAGERS_OR_SENIORS))
                {
                    constraintsBroken.ManagerOrSenior = true;
                    //brokenConstraints.Add("At least one manager and one senior staff member must be on duty");
                }
            }
            double requiredPercentage = GeneralUtils.REQUIRED_PERCENTAGE_AT_LEAST_MAX;
            if (GeneralUtils.lessEmployeePercentageRequired.Any(x => holidayRequest.StartDate >= x.StartDate
                 && holidayRequest.EndDate <= x.EndDate))
            { 
                requiredPercentage = GeneralUtils.REQUIRED_PERCENTAGE_AT_LEAST_MIN;
            }
            if (areThereNotEnoughEmployeesWorking(requiredPercentage))
            {
                constraintsBroken.AtLeastPercentage = true;
                //brokenConstraints.Add("At least" + requiredPercentage + "% of a department must be on duty");
            }
            return constraintsBroken;
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
                .HolidayRequests.Where(x => x.StatusRequest.Status == GeneralUtils.APPROVED && x.EndDate > DateTime.Now)
                .ToList();
            if (holidays.Any(x => isOverlappingHoliday(x, holidayRequest)))
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
                if (usr.HolidayRequests.Any(x => isOverlappingHoliday(x, holidayRequest)))
                {
                    numOfColleagues--;
                }
            }
            return numOfColleagues > 0;
        }

        public bool isOverlappingHoliday(HolidayRequest existing, HolidayRequest newAdded)
        {
            if(existing.EndDate > DateTime.Now
                  && ((existing.EndDate >= newAdded.StartDate && existing.EndDate <= newAdded.EndDate)
                  || (existing.StartDate <= newAdded.EndDate && existing.StartDate >= newAdded.StartDate)
                  || (existing.StartDate <= newAdded.StartDate && existing.EndDate >= newAdded.EndDate)))
                return true;
            return false;
        }

        private bool areThereNotEnoughEmployeesWorking(double percentage)
        {
            var employeesByDepartment = entity.Users.Where(x => x.DepartmentID == user.DepartmentID);
            double numEmployees = employeesByDepartment.Count();
            double onHolidayEmployees = 0;
            foreach (var employee in employeesByDepartment)
            {
                if (employee.HolidayRequests.Any(x => isOverlappingHoliday(x, holidayRequest)))
                {
                    onHolidayEmployees++;
                }
            }
            return (onHolidayEmployees / numEmployees) > percentage;
        }

    }
}
