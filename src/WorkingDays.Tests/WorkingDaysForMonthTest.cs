using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WorkingDays.Tests
{
    [TestClass]
    public class WorkingDaysForMonthTest
    {
        private WorkingDaysCalculator _calculator;

        private readonly List<int[]> _january2020 = new List<int[]>
        {
            new int[] { 1, 23 },
            new int[] { 2, 22 },
            new int[] { 3, 21 },
            new int[] { 4, 20 },
            new int[] { 5, 20 },
            new int[] { 6, 20 },
            new int[] { 7, 19 },
            new int[] { 8, 18 },
            new int[] { 9, 17 },
            new int[] { 10, 16 },
            new int[] { 11, 15 },
            new int[] { 12, 15 },
            new int[] { 13, 15 },
            new int[] { 14, 14 },
            new int[] { 15, 13 },
            new int[] { 16, 12 },
            new int[] { 17, 11 },
            new int[] { 18, 10 },
            new int[] { 19, 10 },
            new int[] { 20, 10 },
            new int[] { 21, 9 },
            new int[] { 22, 8 },
            new int[] { 23, 7 },
            new int[] { 24, 6 },
            new int[] { 25, 5 },
            new int[] { 26, 5 },
            new int[] { 27, 5 },
            new int[] { 28, 4 },
            new int[] { 29, 3 },
            new int[] { 30, 2 },
            new int[] { 31, 1 }
        };

        [TestInitialize]
        public void TestInitialize()
        {
            _calculator = new WorkingDaysCalculator();
        }

        [TestMethod]
        public void CalculateIndividuallyTest()
        {
            DateTime endDate = new DateTime(2020, 1, 31);
            foreach (int[] pair in _january2020)
            {
                DateTime start = new DateTime(2020, 1, pair[0]);
                int days = _calculator.Calculate(start, endDate);
                Assert.AreEqual(pair[1], days);
            }
        }

        [TestMethod]
        public void CalculateForMonthTest()
        {
            Dictionary<int, int> results = _calculator.CalculateMonth(2020, 1, 31);
            Assert.AreEqual(31, results.Count);

            for (int i = 1; i < 31; i++)
            {
                int[] expected = _january2020[i - 1];
                Assert.AreEqual(expected[1], results[i]);
            }
        }
    };
}
