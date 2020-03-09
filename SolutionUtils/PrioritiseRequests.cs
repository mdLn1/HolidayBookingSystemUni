using HBSDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolutionUtils;

namespace SolutionUtils
{
    public class PrioritiseRequests
    {
        public static int daysFallPeakTimes(HolidayRequest holidayRequest)
        {
            int peakTimeDays = 0;
            foreach (var peakTime in GeneralUtils.getPeakTimesForCurrentYear())
            {
                if (GeneralUtils.isOverlappingDateRanges(new DateRange(holidayRequest.StartDate, holidayRequest.EndDate), peakTime))
                {
                    DateTime startDate = holidayRequest.StartDate;
                    while (startDate <= peakTime.EndDate && startDate <= holidayRequest.EndDate)
                    {
                        if (startDate >= peakTime.StartDate && !GeneralUtils.isWeekendDay(startDate))
                        {
                            peakTimeDays++;
                        }
                        startDate = startDate.AddDays(1);
                    }
                }
            }
            return peakTimeDays;
        }

        public static bool areDaysInPeakTime(DateRange existing, DateRange newAdded)
        {
            if (existing.EndDate > DateTime.Now
                  && ((existing.EndDate >= newAdded.StartDate && existing.EndDate <= newAdded.EndDate)
                  || (existing.StartDate <= newAdded.EndDate && existing.StartDate >= newAdded.StartDate)
                  || (existing.StartDate <= newAdded.StartDate && existing.EndDate >= newAdded.EndDate)))
                return true;
            return false;
        }

        private List<PriorityRequest> holidayRequests;
        public PrioritiseRequests(List<PriorityRequest> holidayRequests)
        {

            this.holidayRequests = holidayRequests.ToList();
        }

        public List<PriorityRequest> getPrioritisedRequests()
        {
            PriorityRequest.SortByPriority sBP =
        new PriorityRequest.SortByPriority();
            holidayRequests.Sort(sBP);
            return holidayRequests;
        }

    }
}
