using Microsoft.VisualStudio.TestTools.UnitTesting;
using MightyElk.MiscExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MightyElk.MiscExt.Tests
{
    [TestClass()]
    public class IOExtTests
    {
        [TestMethod()]
        public void NameWithoutExtensionTest()
        {
            System.IO.FileInfo fi = new System.IO.FileInfo("C:\\windows\\notepad.exe");
            if (fi.NameWithoutExtension() != "notepad")
                Assert.Fail();
        }

        [TestMethod()]
        public void GetUniqueFilenameTest()
        {
            System.IO.FileInfo fi = new System.IO.FileInfo("C:\\windows\\notepad.exe");

            if (fi.GetUniqueFilename() != "C:\\windows\\notepad(1).exe")
                Assert.Fail();
        }

        [TestMethod()]
        public void StripIllegalCharsTest()
        {
            var fi = new System.IO.FileInfo("C:\\test\\allesgut.txt");
            Assert.AreEqual(fi.FullName, fi.StripIllegalChars());


            fi = new System.IO.FileInfo("C:\\somethings:wrong");
            Assert.AreNotEqual(fi.FullName, fi.StripIllegalChars());

        }

        [TestMethod()]
        public void ChangeFilenameTest()
        {
            System.IO.FileInfo fi = new System.IO.FileInfo("C:\\windows\\notepad.exe");

            var newFi=fi.ChangeFilename("test");

            Assert.AreEqual("C:\\windows\\test.exe", newFi.FullName);
        }
    }
}