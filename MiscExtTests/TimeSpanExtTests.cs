using Microsoft.VisualStudio.TestTools.UnitTesting;
using MightyElk.MiscExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MightyElk.MiscExt.Tests
{
    [TestClass()]
    public class TimeSpanExtTests
    {
        [TestMethod()]
        public void ToHumanReadableTest()
        {
            TimeSpan ts = new TimeSpan(1, 2, 3, 4, 5);

            Assert.AreEqual("1 day,2 hours,3 minutes,4 seconds", ts.ToHumanReadable());
        }
    }
}