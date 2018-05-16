using System;
using System.IO;
using System.Text;
using Cross;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CrossUnitTests
{
    [TestClass]
    public class CrossTests
    {
        [TestInitialize]
        public void InitializeTest()
        {
            StreamWriter standardOut =
                new StreamWriter(Console.OpenStandardOutput());
            standardOut.AutoFlush = true;
            Console.SetOut(standardOut);
        }

        [TestMethod]
        public void Print_WithHeightZero_PrintNothing()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                CrossBuilder cross = new CrossBuilder();

                cross.Print(0);

                string expected = "";
                Assert.AreEqual<string>(expected, sw.ToString());
            }
        }

        [TestMethod]
        public void Print_WithHeightOne_PrintOneAsteriskOneRow()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                CrossBuilder cross = new CrossBuilder();

                cross.Print(1);

                string expected = string.Format("*{0}", Environment.NewLine);
                Assert.AreEqual<string>(expected, sw.ToString());
            }
        }

        [TestMethod]
        public void Print_WithHeightTwo_PrintTwoAsterisksTwoRows()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                CrossBuilder cross = new CrossBuilder();

                cross.Print(2);

                string expected = string.Format("**{0}**{0}", Environment.NewLine);
                Assert.AreEqual<string>(expected, sw.ToString());
            }
        }

        [TestMethod]
        public void Print_WithHeightFive_PrintAsterisksOdd()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                CrossBuilder cross = new CrossBuilder();

                cross.Print(5);

                StringBuilder sb = new StringBuilder();
                sb.Append(string.Format("*       *{0}", Environment.NewLine));
                sb.Append(string.Format("  *   *{0}", Environment.NewLine));
                sb.Append(string.Format("    *{0}", Environment.NewLine));
                sb.Append(string.Format("  *   *{0}", Environment.NewLine));
                sb.Append(string.Format("*       *{0}", Environment.NewLine));

                string expected = sb.ToString();
                Assert.AreEqual<string>(expected, sw.ToString());
            }
        }

        [TestMethod]
        public void Print_WithHeightSix_PrintAsterisksEven()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                CrossBuilder cross = new CrossBuilder();

                cross.Print(6);

                StringBuilder sb = new StringBuilder();
                sb.Append(string.Format("*        *{0}", Environment.NewLine));
                sb.Append(string.Format("  *    *{0}", Environment.NewLine));
                sb.Append(string.Format("    **{0}", Environment.NewLine));
                sb.Append(string.Format("    **{0}", Environment.NewLine));
                sb.Append(string.Format("  *    *{0}", Environment.NewLine));
                sb.Append(string.Format("*        *{0}", Environment.NewLine));

                string expected = sb.ToString();
                Assert.AreEqual<string>(expected, sw.ToString());
            }
        }
    }
}
