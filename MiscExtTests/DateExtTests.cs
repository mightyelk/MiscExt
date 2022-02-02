using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MightyElk.MiscExt.Tests
{
    [TestClass()]
    public class DateExtTests
    {
        [TestMethod()]
        public void GetWeekTest()
        {
            if (new DateTime(2018, 9, 5).GetWeek() != 36)
                Assert.Fail();
        }

        [TestMethod()]
        public void IsTimeBetweenTest()
        {

            var tsFrom = new TimeSpan(11, 0, 0);
            var tsTo = new TimeSpan(13, 30, 0);

            Assert.IsFalse(new DateTime(2000, 1, 1, 13, 30, 33).IsTimeBetween(tsFrom, tsTo));

            tsTo = new TimeSpan(13, 30, 35);
            Assert.IsTrue(new DateTime(2000, 1, 1, 13, 30, 33).IsTimeBetween(tsFrom, tsTo));


            tsFrom = new TimeSpan(23, 0, 0);
            Assert.IsTrue(new DateTime(2000, 1, 1, 13, 30, 33).IsTimeBetween(tsFrom, tsTo));

            Assert.IsFalse(new DateTime(2000, 1, 1, 14, 30, 33).IsTimeBetween(tsFrom, tsTo));
        }
    }
}