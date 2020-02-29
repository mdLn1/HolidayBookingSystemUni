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
                if (areDaysInPeakTime(peakTime, new DateRange(holidayRequest.StartDate, holidayRequest.EndDate)))
                {
                    DateTime startDate = holidayRequest.StartDate;
                    while (startDate <= peakTime.EndDate)
                    {
                        if (startDate >= peakTime.StartDate && startDate.DayOfWeek != DayOfWeek.Saturday
                                && startDate.DayOfWeek != DayOfWeek.Sunday)
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

        //public List<string> getOrderedStrings()
        //{
        //    List<string> strings = new List<string>()
        //    {
        //        "hello",
        //        "gello",
        //        "gey",
        //        "jaleyone"
        //    };

        //    return strings;
        //}


        //public static IComparer<string> sortTextLength()
        //{
        //    return (IComparer<string>)new TextLengthComparer();
        //}
    }

    //public class TextLengthComparer : IComparer<string>
    //{
    //    //when x should go first, return -1. When y should go first, return 1.
    //    public int Compare(string x, string y)
    //    {
    //        if (x.Length > y.Length)
    //            return 1;
    //        if (x.Length == y.Length)
    //            return 0;
    //        return -1;
    //    }


    //}

}
