using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParagraphChecker;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParagraphChecker.Tests
{
    [TestClass()]
    public class ParagraphTests
    {
        string paragraphText = string.Empty;
        string wordsText = string.Empty;

        [TestMethod()]
        public void ReadArticleTest()
        {
            string articlePath = string.Empty;

            try
            {
                articlePath = @"C:\Users\CARL\Desktop\BuilderWireCodingChallenge-0820\Input\Article.txt";

                ProcessFile pf = new ProcessFile();
                string paragraphText = pf.ReadFile(articlePath);
            }
            catch
            {
                Assert.Fail();
            }

        }


        [TestMethod()]
        public void ReadWordsTest()
        {
            string wordPath = string.Empty;
            try
            {
                wordPath = @"C:\Users\CARL\Desktop\BuilderWireCodingChallenge-0820\Input\Words.txt";

                ProcessFile pf = new ProcessFile();
                wordsText = pf.ReadFile(wordPath);
            }
            catch
            {
                Assert.Fail();
            }

        }

        [TestMethod()]
        public void ParseTest()
        {
            try
            {
                Paragraph paragraph = new Paragraph();
                string output = paragraph.Parse(paragraphText, wordsText);
            }
            catch {
                Assert.Fail();
            }
        }
    }
}