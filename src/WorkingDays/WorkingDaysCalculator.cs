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
            if (start.DayOfWeek == DayOfWeek.Sunday) start = start.AddDays(-1);
            int startForwardDays = DayOfWeek.Saturday - start.DayOfWeek + 1;
            int endForwardDays = DayOfWeek.Saturday - end.DayOfWeek - 1;

            DateTime adjustedStart = start.AddDays(startForwardDays - 1);
            DateTime adjustedEnd = end.AddDays(endForwardDays + 1);

            int weeks = (int)(((adjustedEnd - adjustedStart).TotalDays + 1) / 7);
            int workingDays = 5 * weeks + startForwardDays - endForwardDays - 1;

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

        /// <summary>
        /// Calculate the number of working days throughout a specified month
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="finalDay"></param>
        /// <returns></returns>
        public Dictionary<int, int> CalculateMonth(int year, int month, int finalDay)
        {
            Dictionary<int, int> results = new Dictionary<int, int>();
            DateTime end = new DateTime(year, month, finalDay);

            WorkingDaysCalculator calculator = new WorkingDaysCalculator();
            for (int dayOfMonth = 1; dayOfMonth <= finalDay; dayOfMonth++)
            {
                DateTime start = new DateTime(year, month, dayOfMonth);
                int days = calculator.Calculate(start, end);
                results.Add(dayOfMonth, days);
            }

            return results;
        }
    }
}
