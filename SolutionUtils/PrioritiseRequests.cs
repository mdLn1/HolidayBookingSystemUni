using HBSDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolutionUtils;
using static SolutionUtils.PriorityRequest;

namespace SolutionUtils
{
    public class PrioritiseRequests
    {
        public static int daysFallPeakTimesCount(DateTime startDate, DateTime endDate)
        {
            int peakTimeDays = 0;
            foreach (var peakTime in GeneralUtils.getPeakTimesForCurrentYear())
            {
                if (GeneralUtils.isOverlappingDateRanges(
                        new DateRange(startDate, endDate), peakTime))
                {
                    DateTime startCheck = startDate;
                    while (startCheck <= peakTime.EndDate && startCheck <= endDate)
                    {
                        if (startCheck >= peakTime.StartDate && !GeneralUtils.isWeekendDay(startCheck))
                        {
                            peakTimeDays++;
                        }
                        startDate = startDate.AddDays(1);
                    }
                }
            }
            return peakTimeDays;
        }

        private List<PriorityRequest> holidayRequests;
        public PrioritiseRequests(List<PriorityRequest> holidayRequests)
        {
            this.holidayRequests = holidayRequests.ToList();
        }

        public List<PriorityRequest> getPrioritisedRequests()
        {
            SortByPriority sBP = new SortByPriority();
            holidayRequests.Sort(sBP);
            return holidayRequests;
        }

    }
}
