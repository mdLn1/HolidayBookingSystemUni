using HBSDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionUtils
{
    public class SuggestionsComponent
    {
        private HolidayRequest currentRequest;
        private List<DateRange> suggestions;
        public SuggestionsComponent(HolidayRequest request)
        {
            currentRequest = request;
            suggestions = new List<DateRange>();
        }

        public void getSuggestions()
        {
            DateTime startCheck = currentRequest.StartDate.AddDays(-GeneralUtils.SUGGESTIONS_MAX_DAYS_BOUNDARY);
            DateTime endCheck = currentRequest.EndDate.AddDays(GeneralUtils.SUGGESTIONS_MAX_DAYS_BOUNDARY);

            using (HBSModel entity = new HBSModel())
            {
                var users = entity.Users.Where(x => x.id != currentRequest.UserID && x.DepartmentID == currentRequest.User.DepartmentID);
                List<HolidayRequest> requests1 = new List<HolidayRequest>();
                foreach(var user in users)
                {
                    requests1.AddRange(user.HolidayRequests
                        .Where(x => x.EndDate <= startCheck
                        && currentRequest.EndDate <= endCheck
                        && x.StatusRequest.Status == GeneralUtils.APPROVED).ToList());
                }
                ConstraintChecking constraintChecking = new ConstraintChecking(requests1, currentRequest.User, currentRequest);

                for(int i = 0; i < GeneralUtils.SUGGESTIONS_MAX_DAYS_BOUNDARY; i++)
                {
                    DateTime currentDateUsed = currentRequest.EndDate.AddDays(-GeneralUtils.SUGGESTIONS_MAX_DAYS_BOUNDARY + i);
                    if (startCheck.DayOfWeek == DayOfWeek.Saturday || startCheck.DayOfWeek == DayOfWeek.Sunday)
                    {
                        i++;
                        continue;
                    }
                    if (!ConstraintChecking.areAnyConstraintsBroken(constraintChecking.getBrokenConstraints()))
                    {
                        suggestions.Add(new DateRange(startCheck, currentDateUsed));
                    }
                    constraintChecking.changeHolidayRequest(new DateRange(startCheck, currentDateUsed));
                }
                startCheck = currentRequest.EndDate.AddDays(-GeneralUtils.SUGGESTIONS_MAX_DAYS_BOUNDARY);
                for (int i = 1; i <= GeneralUtils.SUGGESTIONS_MAX_DAYS_BOUNDARY; i++)
                {
                    DateTime currentDateUsed = currentRequest.EndDate.AddDays(i);
                    if (startCheck.DayOfWeek == DayOfWeek.Saturday || startCheck.DayOfWeek == DayOfWeek.Sunday)
                    {
                        i++;
                        continue;
                    }
                    if (!ConstraintChecking.areAnyConstraintsBroken(constraintChecking.getBrokenConstraints()))
                    {
                        suggestions.Add(new DateRange(startCheck, currentDateUsed));
                    }
                    constraintChecking.changeHolidayRequest(new DateRange(startCheck, currentDateUsed));
                }
            }
        }
    }
}
