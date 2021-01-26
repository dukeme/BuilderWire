using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParagraphChecker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParagraphChecker.Tests
{
    [TestClass()]
    public class UtilityTests
    {
        [TestMethod()]
        public void IsUpperTest()
        {
            try
            {
                bool result = Utility.IsUpper("Test");
                Assert.IsTrue(result, "True");
            }
            catch (Exception)
            {
                Assert.Fail();
            }
         
        }

        [TestMethod()]
        public void IsLowerTest()
        {
            try
            {
                bool result = Utility.IsUpper("test");
                Assert.IsFalse(result, "False");
            }
            catch (Exception)
            {
                Assert.Fail();
            }

        }

        [TestMethod()]
        public void SplitTextTest()
        {
            try
            {
                var List = Utility.SplitText("Test Me");
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void SplitTextByCharTest()
        {
            try
            {
                var List = Utility.SplitTextByChar("Hello\r\nWorld\r\n", "\r\n");
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void RemoveSpecialCharactersTest()
        {
            try
            {
                var word = Utility.RemoveSpecialCharacters("Hello.");
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void RemoveSpecialCharacters2Test()
        {
            try
            {
                var word = Utility.RemoveSpecialCharacters("Hello.");
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }
    }
}