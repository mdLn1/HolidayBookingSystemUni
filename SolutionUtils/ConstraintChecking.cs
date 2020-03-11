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
        private List<User> usersFromDepartment;
        public ConstraintChecking(User user, HolidayRequest holidayRequest)
        {
            entity = new HBSModel();
            this.holidayRequest = holidayRequest;
            this.user = user;
            usersFromDepartment = entity.Users.Where(x => x.DepartmentID == user.DepartmentID && x.id != user.id).ToList();
        }

        public ConstraintChecking(int userId, DateTime holidayStartDate, DateTime holidayEndDate)
        {
            entity = new HBSModel();
            this.holidayRequest = entity.HolidayRequests
                    .FirstOrDefault(x => x.EndDate == holidayEndDate && x.StartDate == holidayStartDate && x.UserID == userId);
            this.user = entity.Users.Find(userId);
            usersFromDepartment = entity.Users.Where(x => x.DepartmentID == user.DepartmentID && x.id != user.id).ToList();
        }

        public void changeCurrentlyVerifiedHolidayRequest(DateRange dateRange)
        {
            holidayRequest.StartDate = dateRange.StartDate;
            holidayRequest.EndDate = dateRange.EndDate;
        }

        public void changeCurrentlyVerifiedHolidayRequest(DateTime start, DateTime end)
        {
            holidayRequest.StartDate = start;
            holidayRequest.EndDate = end;
        }

        public static bool areAnyConstraintsBroken(ConstraintsBroken constraintsBroken)
        {
            return constraintsBroken.AtLeastPercentage
                        || constraintsBroken.ExceedsHolidayEntitlement || constraintsBroken.ManagerOrSenior
                            || constraintsBroken.HeadOrDeputy;
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
            if (userRole == GeneralUtils.HEAD_ROLE || userRole == GeneralUtils.DEPUTY_HEAD_ROLE)
            {
                if (isDeputyOrHeadOnHolidayAlready(userRole == GeneralUtils.DEPUTY_HEAD_ROLE
                    ? GeneralUtils.HEAD_ROLE : GeneralUtils.DEPUTY_HEAD_ROLE))
                    constraintsBroken.HeadOrDeputy = true;
            }
            if (userRole == GeneralUtils.SENIOR_ROLE || userRole == GeneralUtils.MANAGER_ROLE)
            {
                if (isNotMinimumNumberOfManagersOrSeniors(GeneralUtils.MINIMUM_NUMBER_MANAGERS_OR_SENIORS))
                {
                    constraintsBroken.ManagerOrSenior = true;
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
            }
            return constraintsBroken;
        }

        public bool isItBreakingConstraints()
        {
            if (GeneralUtils.noConstraintsApply.Any(x => holidayRequest.StartDate >= x.StartDate
                 && holidayRequest.EndDate <= x.EndDate))
            {
                return false;
            }
            string userRole = user.Role.RoleName;

            if (isHolidayAllowanceExceeded())
                return true;

            if (userRole == GeneralUtils.HEAD_ROLE || userRole == GeneralUtils.DEPUTY_HEAD_ROLE)
            {
                if (isDeputyOrHeadOnHolidayAlready(userRole == GeneralUtils.DEPUTY_HEAD_ROLE
                    ? GeneralUtils.HEAD_ROLE : GeneralUtils.DEPUTY_HEAD_ROLE))
                    return true;
            }

            if (userRole == GeneralUtils.SENIOR_ROLE || userRole == GeneralUtils.MANAGER_ROLE)
            {
                if (isNotMinimumNumberOfManagersOrSeniors(GeneralUtils.MINIMUM_NUMBER_MANAGERS_OR_SENIORS))
                {
                    return true;
                }
            }

            double requiredPercentage = GeneralUtils.REQUIRED_PERCENTAGE_AT_LEAST_MAX;
            if (GeneralUtils.lessEmployeePercentageRequired.Any(x => holidayRequest.StartDate >= x.StartDate
                 && holidayRequest.EndDate <= x.EndDate))
            {
                requiredPercentage = GeneralUtils.REQUIRED_PERCENTAGE_AT_LEAST_MIN;
            }

            return areThereNotEnoughEmployeesWorking(requiredPercentage);
        }

        private bool isHolidayAllowanceExceeded()
        {
            return user.RemainingDays < holidayRequest.NumberOfDays;
        }

        private bool isDeputyOrHeadOnHolidayAlready(string role)
        {
            var roleId = entity.Roles.FirstOrDefault(x => x.RoleName == role).ID;
            var holidays = usersFromDepartment
                .FirstOrDefault(x => x.RoleID == roleId)
                .HolidayRequests.Where(x => x.StatusRequest.Status == GeneralUtils.APPROVED && x.EndDate > DateTime.Now)
                .ToList();
            if (holidays.Any(x => GeneralUtils.isOverlappingHoliday(x, holidayRequest)))
            {
                return true;
            }
            return false;


        }

        private bool isNotMinimumNumberOfManagersOrSeniors(int min)
        {
            var colleagues = usersFromDepartment.Where(x => x.RoleID == user.RoleID);
            int numOfColleagues = colleagues.Count();
            foreach (var usr in colleagues)
            {
                if (usr.HolidayRequests.Any(x => GeneralUtils.isOverlappingHoliday(x, holidayRequest)))
                {
                    numOfColleagues--;
                }
            }
            return numOfColleagues >= min;
        }



        private bool areThereNotEnoughEmployeesWorking(double percentage)
        {
            double numEmployees = usersFromDepartment.Count();
            double onHolidayEmployees = 0;
            foreach (var employee in usersFromDepartment)
            {
                if (employee.HolidayRequests.Any(x => GeneralUtils.isOverlappingHoliday(x, holidayRequest)))
                {
                    onHolidayEmployees++;
                }
            }
            return (onHolidayEmployees / numEmployees) > percentage;
        }

    }
}
