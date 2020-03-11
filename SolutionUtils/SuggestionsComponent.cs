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
        private List<DateRange> suggestions;
        private DateRange currentRequest;
        private ConstraintChecking constraintChecking;
        private int userId;
        private int userHolidayRemainingDays;
        public SuggestionsComponent(int userId, DateRange holidayDateRange, int userHolidayRemainingDays)
        {
            currentRequest = holidayDateRange;
            this.userId = userId;
            suggestions = new List<DateRange>();
            this.userHolidayRemainingDays = userHolidayRemainingDays;
        }

        public List<DateRange> getSuggestions()
        {

            int numDaysBetween = (currentRequest.EndDate - currentRequest.StartDate).Days + 1;

            DateTime startCheck = currentRequest.StartDate.AddDays(-GeneralUtils.SUGGESTIONS_MAX_DAYS_BOUNDARY);
            if(startCheck.Date < DateTime.Now.AddDays(2))
            {
                startCheck = startCheck.AddDays(2);
            }
            // make sure using the current request analyzed
            constraintChecking = new ConstraintChecking(userId, currentRequest.StartDate, currentRequest.EndDate);

            DateTime currentStartDate = currentRequest.StartDate;
            DateTime currentEndDate = currentRequest.EndDate;

            // if the broken constraint regards the holiday entitlement reduce the number of days for suggestion checks
            if (constraintChecking.getBrokenConstraints().ExceedsHolidayEntitlement)
            {
                currentEndDate = currentEndDate.AddDays(userHolidayRemainingDays - numDaysBetween);
                numDaysBetween = userHolidayRemainingDays;
                if (numDaysBetween < 1)
                {
                    return new List<DateRange>();
                }
            }
            calculateSuggestionsBeforeStartDate(startCheck, currentEndDate);

            // add one to start date so moving range forward
            startCheck = currentStartDate.AddDays(1);
            calculateSuggestionsAfterEndDate(startCheck, currentEndDate);

            // only shorten holiday maximum to half
            numDaysBetween = (int)Math.Ceiling((double)numDaysBetween / 2);

            // starting from next day
            startCheck = currentStartDate.AddDays(1);
            calculateSuggestionsByReducingDaysFromEnd(startCheck, currentEndDate, numDaysBetween);

            // reducing from day before end date
            DateTime endCheck = currentEndDate.AddDays(-1);
            calculateSuggestionsByReducingDaysFromStart(currentStartDate, endCheck, numDaysBetween);


            return suggestions;

        }

        private void calculateSuggestionsBeforeStartDate(DateTime start, DateTime end)
        {
            // check if suggestion available in the past
            for (int i = 0; i < GeneralUtils.SUGGESTIONS_MAX_DAYS_BOUNDARY; i++)
            {
                if (GeneralUtils.isWeekendDay(start))
                {
                    start = start.AddDays(1);
                    continue;
                }
                if (suggestions.Count > GeneralUtils.MAX_SUGGESTIONS_COUNT)
                {
                    break;
                }
                DateTime currentDateUsed = end.AddDays(-GeneralUtils.SUGGESTIONS_MAX_DAYS_BOUNDARY + i);
                constraintChecking.changeCurrentlyVerifiedHolidayRequest(new DateRange(start, currentDateUsed));
                if (!constraintChecking.isItBreakingConstraints())
                {
                    suggestions.Add(new DateRange(start, currentDateUsed));
                }
                start = start.AddDays(1);
            }
        }

        public void calculateSuggestionsAfterEndDate(DateTime start, DateTime end)
        {
            // check if suggestion available in the future
            for (int i = 0; i < GeneralUtils.SUGGESTIONS_MAX_DAYS_BOUNDARY; i++)
            {
                if (GeneralUtils.isWeekendDay(start))
                {
                    start = start.AddDays(1);
                    continue;
                }
                if (suggestions.Count > GeneralUtils.MAX_SUGGESTIONS_COUNT)
                {
                    break;
                }
                DateTime currentDateUsed = end.AddDays(i + 1);
                constraintChecking.changeCurrentlyVerifiedHolidayRequest(new DateRange(start, currentDateUsed));
                if (!constraintChecking.isItBreakingConstraints())
                {
                    suggestions.Add(new DateRange(start, currentDateUsed));
                }
                start = start.AddDays(1);
            }
        }

        public void calculateSuggestionsByReducingDaysFromStart(DateTime start, DateTime end, int numDaysMaxReduced)
        {
            // suggesstions using start date, decreasing days from end date
            for (int i = 1; i <= numDaysMaxReduced; i++)
            {
                end = GeneralUtils.simplifyEndDate(end);
                if (suggestions.Count > GeneralUtils.MAX_SUGGESTIONS_COUNT)
                {
                    break;
                }
                constraintChecking.changeCurrentlyVerifiedHolidayRequest(new DateRange(start, end));
                if (!constraintChecking.isItBreakingConstraints())
                {
                    suggestions.Add(new DateRange(start, end));
                }
                end = end.AddDays(-1);
            }
        }

        public void calculateSuggestionsByReducingDaysFromEnd(DateTime start, DateTime end, int numDaysMaxReduced)
        {
            // suggestions from end date, decreasing days from start date
            for (int i = 1; i <= numDaysMaxReduced; i++)
            {
                start = GeneralUtils.simplifyStartDate(start);
                if (suggestions.Count > GeneralUtils.MAX_SUGGESTIONS_COUNT)
                {
                    break;
                }
                constraintChecking.changeCurrentlyVerifiedHolidayRequest(new DateRange(start, end));
                if (!constraintChecking.isItBreakingConstraints())
                {
                    suggestions.Add(new DateRange(start, end));
                }
                start = start.AddDays(1);
            }
        }
    }
}
