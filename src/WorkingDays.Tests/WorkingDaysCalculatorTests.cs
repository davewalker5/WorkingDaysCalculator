using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WorkingDays.Tests
{
    [TestClass]
    public class WorkingDaysCalculatorTests
    {
        private WorkingDaysCalculator _calculator;

        private readonly DateTime[] _publicHolidays =
        {
            new DateTime(2020, 1, 1),
            new DateTime(2020, 4, 10),
            new DateTime(2020, 4, 13),
            new DateTime(2020, 5, 8),
            new DateTime(2020, 5, 25),
            new DateTime(2020, 8, 31),
            new DateTime(2020, 12, 25),
            new DateTime(2020, 12, 28)
        };

        [TestInitialize]
        public void TestInitialize()
        {
            _calculator = new WorkingDaysCalculator();
        }

        [TestMethod]
        public void SameWeekTest()
        {
            DateTime start = new DateTime(2020, 1, 14);
            DateTime end = new DateTime(2020, 1, 16);
            int days = _calculator.Calculate(start, end);
            Assert.AreEqual(3, days);
        }

        [TestMethod]
        public void SpanWeekendTest()
        {
            DateTime start = new DateTime(2020, 1, 17);
            DateTime end = new DateTime(2020, 1, 20);
            int days = _calculator.Calculate(start, end);
            Assert.AreEqual(2, days);
        }

        [TestMethod]
        public void IncludeHolidaysTest()
        {
            DateTime start = new DateTime(2020, 4, 9);
            DateTime end = new DateTime(2020, 4, 14);

            int days = _calculator.Calculate(start, end);
            Assert.AreEqual(4, days);

            days = _calculator.Calculate(start, end, _publicHolidays);
            Assert.AreEqual(2, days);
        }

        [TestMethod]
        public void KnownDateTest()
        {
            DateTime start = new DateTime(2020, 2, 4);
            DateTime end = new DateTime(2020, 4, 24);
            DateTime[] nonWorkingDays =
            {
                new DateTime(2020, 2, 12),
                new DateTime(2020, 2, 13),
                new DateTime(2020, 2, 14),
                new DateTime(2020, 2, 17)
            };

            int days = _calculator.Calculate(start, end, _publicHolidays.Concat(nonWorkingDays));
            Assert.AreEqual(53, days);
        }
    }
}
