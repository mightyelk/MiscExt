using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MightyElk.MiscExt.Tests
{
    [TestClass()]
    public class StringExtTests
    {
        [TestMethod()]
        public void PrintFTest()
        {
            string what = "string={s} second string={s} number={d} float={f} formatted float={f:0.00}";

            string ret = what.PrintF("hallo", "welt", 30, 12.9876F, 12.9876F);

            if (ret != "string=hallo second string=welt number=30 float=12,9876 formatted float=12,99")
                Assert.Fail("Culture falsch?");

        }


        [TestMethod()]
        public void SplitTest()
        {
            string what = "lorem\nipsum\ndolor";
            var x = what.Split('\n');

            if (!Enumerable.SequenceEqual(x, new string[] { "lorem", "ipsum", "dolor" }))
                Assert.Fail();

        }

        [TestMethod()]
        public void ReverseTest()
        {
            string what = "abc123";
            if (what.Reverse()!="321cba")
                Assert.Fail();

        }

        [TestMethod()]
        public void BetweenTest()
        {
            string what = "lorem ipsum dolor sit amet";
            if (what.Between("ipsum", "amet") != "dolor sit")
                Assert.Fail();

        }

        [TestMethod()]
        public void CutoffTest()
        {
            string what = "lorem ipsum";
            if (what.Cutoff(3) != "lorem ip")
                Assert.Fail();
                
        }

        [TestMethod()]
        public void ReplaceAllTest()
        {
            string what="lorem ipsum dolor sit amet";
            if (what.ReplaceAll(new string[] { "l", "o" }, "X") != "XXrem ipsum dXXXr sit amet")
                Assert.Fail();
        }
    }
}