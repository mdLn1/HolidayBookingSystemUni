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
        private List<HolidayRequest> filteredRequests;
        public ConstraintChecking(User user, HolidayRequest holidayRequest)
        {
            this.holidayRequest = holidayRequest;
            entity = new HBSModel();
            this.user = user;
            usersFromDepartment = entity.Users.Where(x => x.DepartmentID == user.DepartmentID && x.id != user.id).ToList();
        }

        public ConstraintChecking(List<HolidayRequest> filteredRequests, User user, HolidayRequest holidayRequest)
        {
            this.holidayRequest = holidayRequest;
            entity = new HBSModel();
            this.user = user;
            this.filteredRequests = filteredRequests;
            usersFromDepartment = entity.Users.Where(x => x.DepartmentID == user.DepartmentID && x.id != user.id).ToList();
        }

        public void changeHolidayRequest(DateRange dateRange)
        {
            holidayRequest.StartDate = dateRange.StartDate;
            holidayRequest.EndDate = dateRange.EndDate;
        }

        public static bool areAnyConstraintsBroken(ConstraintsBroken constraintsBroken)
        {
            if (constraintsBroken.AtLeastPercentage
                        || constraintsBroken.ExceedsHolidayEntitlement || constraintsBroken.ManagerOrSenior
                            || constraintsBroken.HeadOrDeputy)
                return true;
            return false;
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

        private bool isHolidayAllowanceExceeded()
        {
            return user.RemainingDays < holidayRequest.NumberOfDays;
        }

        private bool isDeputyOrHeadOnHolidayAlready(string role)
        {
            var roleId = entity.Roles.FirstOrDefault(x => x.RoleName == role).ID;
            if(filteredRequests != null)
            {
                if (filteredRequests.Any(x => isOverlappingHoliday(x, holidayRequest)))
                {
                    return true;
                }
                return false;

            } else
            {
                var holidays = usersFromDepartment
                .FirstOrDefault(x => x.RoleID == roleId)
                .HolidayRequests.Where(x => x.StatusRequest.Status == GeneralUtils.APPROVED && x.EndDate > DateTime.Now)
                .ToList();
                if (holidays.Any(x => isOverlappingHoliday(x, holidayRequest)))
                {
                    return true;
                }
                return false;
            }
            
        }

        private bool isNotMinimumNumberOfManagersOrSeniors(int min)
        {
            var colleagues = usersFromDepartment.Where(x => x.RoleID == user.RoleID);
            int numOfColleagues = colleagues.Count();
            foreach (var usr in colleagues)
            {
                if (usr.HolidayRequests.Any(x => isOverlappingHoliday(x, holidayRequest)))
                {
                    numOfColleagues--;
                }
            }
            return numOfColleagues >= min;
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
            double numEmployees = usersFromDepartment.Count();
            double onHolidayEmployees = 0;
            foreach (var employee in usersFromDepartment)
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
