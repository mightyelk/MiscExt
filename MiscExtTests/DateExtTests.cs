using Microsoft.VisualStudio.TestTools.UnitTesting;
using MightyElk.MiscExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MightyElk.MiscExt;

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

    }
}