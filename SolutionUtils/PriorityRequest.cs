using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionUtils
{
    public class PriorityRequest : IComparable
    {
        public class BreakingConstraints
        {
            public bool ExceedsHolidayEntitlement { get; set; }
            public bool HeadOrDeputy { get; set; }
            public bool ManagerOrSenior { get; set; }
            public bool AtLeastPercentage { get; set; }
        }
        public int ID { get; set; }
        public BreakingConstraints Constraints { get; set; }
        public int DaysPeakTime { get; set; }
        public int WorkingDays { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int RemainingDays { get; set; }
        public int InitialHolidayEntitlement { get; set; }
        public int TotalPeakDaysHoliday { get; set; }
        public int CompareTo(object obj)
        {
            PriorityRequest ob = (PriorityRequest)obj;
            return this.RemainingDays - ob.RemainingDays;
        }

        public class SortByPriority : IComparer<PriorityRequest>
        {
            public int Compare(PriorityRequest x, PriorityRequest y)
            {
                //when x should go first, return -1. When y should go first, return 1.
                if(x.InitialHolidayEntitlement - x.RemainingDays > y.InitialHolidayEntitlement - y.RemainingDays)
                    return 1;
                if (x.TotalPeakDaysHoliday > y.TotalPeakDaysHoliday)
                    return 1;
                if (x.RemainingDays >= y.RemainingDays)
                    return -1;
                if (x.DaysPeakTime == 0 && y.DaysPeakTime == 0)
                    return 0;
                if (x.DaysPeakTime == 0)
                    return -1;
                if (y.DaysPeakTime == 0)
                    return 1;
                return 0;
            }


        }
    }
}
