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
    public class NumericExtTests
    {
        [TestMethod()]
        public void ToRadiansTest()
        {
            if (((double)2000F).ToRadians() != 34.906585039886593)
                Assert.Fail();
        }

        [TestMethod()]
        public void RadianToDegreeTest()
        {
            if (((double)55.55).RadianToDegree() != 3182.7805519517228)
                Assert.Fail();
        }
    }
}