using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tool;

namespace Tests
{
    [TestClass]
    public class AttribureParserTests
    {
        private const string First = "First";
        private const string Second = "Second";
        private const string Third = "Third";

        [TestMethod]
        public void TestParsingOneParam()
        {
            var array = new string[1] { First };
            var list = AttribureParser.Parse(array, 1);
            Assert.IsTrue(list.Count == 1);
            Assert.IsTrue(list[0] == First);

            list = AttribureParser.Parse(array, 2);
            Assert.IsTrue(list.Count == 2);
            Assert.IsTrue(list[0] == First);
            Assert.IsTrue(list[1] == null);

            list = AttribureParser.Parse(array, 3);
            Assert.IsTrue(list.Count == 3);
            Assert.IsTrue(list[0] == First);
            Assert.IsTrue(list[1] == null);
            Assert.IsTrue(list[2] == null);
        }

        [TestMethod]
        public void TestParsingTwoParam()
        {
            var array = new string[2] { First, Second };
            var list = AttribureParser.Parse(array, 1);
            Assert.IsTrue(list.Count == 1);
            Assert.IsTrue(list[0] == First);

            list = AttribureParser.Parse(array, 2);
            Assert.IsTrue(list.Count == 2);
            Assert.IsTrue(list[0] == First);
            Assert.IsTrue(list[1] == Second);

            list = AttribureParser.Parse(array, 3);
            Assert.IsTrue(list.Count == 3);
            Assert.IsTrue(list[0] == First);
            Assert.IsTrue(list[1] == Second);
            Assert.IsTrue(list[2] == null);
        }

        [TestMethod]
        public void TestParsingThreeParam()
        {
            var array = new string[3] { First, Second, Third };
            var list = AttribureParser.Parse(array, 1);
            Assert.IsTrue(list.Count == 1);
            Assert.IsTrue(list[0] == First);

            list = AttribureParser.Parse(array, 2);
            Assert.IsTrue(list.Count == 2);
            Assert.IsTrue(list[0] == First);
            Assert.IsTrue(list[1] == Second);

            list = AttribureParser.Parse(array, 3);
            Assert.IsTrue(list.Count == 3);
            Assert.IsTrue(list[0] == First);
            Assert.IsTrue(list[1] == Second);
            Assert.IsTrue(list[2] == Third);
        }
    }
}
