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
    public class ICollectionExtTests
    {
        [TestMethod()]
        public void AddAndReturnTest()
        {
            var l = new List<string>();
            var s=l.AddAndReturn<string>("test");
            
            Assert.AreEqual("test", s);

            var n = new List<int>();
            var i = n.AddAndReturn<int>(100);
            Assert.AreEqual(100, i);
        }
    }
}