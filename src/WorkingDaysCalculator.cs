using System;
using System.Collections.Generic;
using System.Linq;

namespace WorkingDays
{
    public class WorkingDaysCalculator
    {
        /// <summary>
        /// Calculate working days between two dates
        /// as weekends
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public int Calculate(DateTime start, DateTime end)
        {
            int forwardToNextWeekend = DayOfWeek.Saturday - start.DayOfWeek;
            int backToPreviousWeekend = Math.Abs(end.DayOfWeek - DayOfWeek.Sunday);

            DateTime adjustedStart = start.AddDays(forwardToNextWeekend);
            DateTime adjustedEnd = end.AddDays(-backToPreviousWeekend);

            int weeks = (int)(adjustedEnd - adjustedStart).TotalDays / 7;
            int workingDays = 5 * weeks + forwardToNextWeekend + backToPreviousWeekend;

            return workingDays;
        }

        /// <summary>
        /// Count working days between two days accounting for holidays
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="holidays"></param>
        /// <returns></returns>
        public int Calculate(DateTime start, DateTime end, IEnumerable<DateTime> holidays)
        {
            DayOfWeek[] weekends = { DayOfWeek.Saturday, DayOfWeek.Sunday };
            int holidayDays = holidays.Count(h => !weekends.Contains(h.DayOfWeek) && (h >= start) && (h <= end));
            return Calculate(start, end) - holidayDays;
        }
    }
}
