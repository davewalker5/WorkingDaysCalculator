using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WorkingDays.Tests
{
    [TestClass]
    public class WorkingDaysForPartialMonthTest
    {
        private readonly List<int[]> _january2020 = new List<int[]>
        {
            new int[] { 1, 15 },
            new int[] { 2, 14 },
            new int[] { 3, 13 },
            new int[] { 4, 12 },
            new int[] { 5, 12 },
            new int[] { 6, 12 },
            new int[] { 7, 11 },
            new int[] { 8, 10 },
            new int[] { 9, 9 },
            new int[] { 10, 8 },
            new int[] { 11, 7 },
            new int[] { 12, 7 },
            new int[] { 13, 7 },
            new int[] { 14, 6 },
            new int[] { 15, 5 },
            new int[] { 16, 4 },
            new int[] { 17, 3 },
            new int[] { 18, 2 },
            new int[] { 19, 2 },
            new int[] { 20, 2 },
            new int[] { 21, 1 }
        };

        [TestMethod]
        public void CalculateForPartialMonthTest()
        {
            WorkingDaysCalculator calculator = new WorkingDaysCalculator();
            DateTime endDate = new DateTime(2020, 1, 21);

            foreach (int[] pair in _january2020)
            {
                DateTime start = new DateTime(2020, 1, pair[0]);
                int days = calculator.Calculate(start, endDate);
                Assert.AreEqual(pair[1], days);
            }
        }
    };
}
