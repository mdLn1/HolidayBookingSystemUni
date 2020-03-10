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
        private ConstraintChecking constraintChecking;
        public SuggestionsComponent(HolidayRequest request)
        {
            currentRequest = request;
            suggestions = new List<DateRange>();
        }

        public List<DateRange> getSuggestions()
        {

            int numDaysBetween = (currentRequest.EndDate - currentRequest.StartDate).Days + 1;

            DateTime startCheck = currentRequest.StartDate.AddDays(-GeneralUtils.SUGGESTIONS_MAX_DAYS_BOUNDARY);
            // make sure using the current request analyzed
            constraintChecking = new ConstraintChecking(currentRequest.User, currentRequest);
            
            DateTime currentStartDate = currentRequest.StartDate;
            DateTime currentEndDate = currentRequest.EndDate;
            if (!constraintChecking.getBrokenConstraints().ExceedsHolidayEntitlement)
            {
                calculateSuggestionsBeforeStartDate(startCheck, currentEndDate);

                // add one to start date so moving range forward
                startCheck = currentStartDate.AddDays(1);
                calculateAvailableSuggestionsAfterEndDate(startCheck, currentEndDate);
            } else
            {
                numDaysBetween = currentRequest.User.RemainingDays;
            }

            // only shorten holiday maximum to half
            numDaysBetween = (int)Math.Ceiling((double)numDaysBetween / 2);

            // starting from next day
            startCheck = currentStartDate.AddDays(1);
            calculateSuggestionsByReducingDaysFromStart(startCheck, currentEndDate, numDaysBetween);

            // reducing from day before end date
            DateTime endCheck = currentEndDate.AddDays(-1);
            calculateSuggestionsByReducingDaysFromEnd(currentStartDate, endCheck, numDaysBetween);

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
                if (suggestions.Count > GeneralUtils.MaxSuggestionsCount)
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

        public void calculateAvailableSuggestionsAfterEndDate(DateTime start, DateTime end)
        {
            // check if suggestion available in the future
            for (int i = 0; i < GeneralUtils.SUGGESTIONS_MAX_DAYS_BOUNDARY; i++)
            {
                if (GeneralUtils.isWeekendDay(start))
                {
                    start = start.AddDays(1);
                    continue;
                }
                if (suggestions.Count > GeneralUtils.MaxSuggestionsCount)
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

        public void calculateSuggestionsByReducingDaysFromEnd(DateTime start, DateTime end, int numDaysMaxReduced)
        {
            // suggesstions from start decreasing days
            for (int i = 1; i <= numDaysMaxReduced; i++)
            {
                end = GeneralUtils.simplifyEndDate(end);
                if (suggestions.Count > GeneralUtils.MaxSuggestionsCount)
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

        public void calculateSuggestionsByReducingDaysFromStart(DateTime start, DateTime end, int numDaysMaxReduced)
        {
            // suggestions from end decreasing days
            for (int i = 1; i <= numDaysMaxReduced; i++)
            {
                start = GeneralUtils.simplifyStartDate(start);
                if (suggestions.Count > GeneralUtils.MaxSuggestionsCount)
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
