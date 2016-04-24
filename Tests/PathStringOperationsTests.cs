using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tool;

namespace Tests
{
    [TestClass]
    public class PathStringOperationsTests
    {
        [TestMethod]
        public void TestRemoveStartFolder()
        {
            string path = "c:\\1\\2\\3\\4\\5\\MyFile.txt";

            string result = path.RemoveStartFolder("c:\\1\\2\\");
            Assert.IsTrue(result == "3\\4\\5\\MyFile.txt");

            result = path.RemoveStartFolder("");
            Assert.IsTrue(result == "c:\\1\\2\\3\\4\\5\\MyFile.txt");

            result = path.RemoveStartFolder("c:\\1\\2\\3\\4\\5\\");
            Assert.IsTrue(result == "MyFile.txt");

            result = path.RemoveStartFolder("d:\\1\\2\\3\\");
            Assert.IsTrue(result == "c:\\1\\2\\3\\4\\5\\MyFile.txt");

            path = "MyFile.txt";
            result = path.RemoveStartFolder("c:\\1\\2\\");
            Assert.IsTrue(result == "MyFile.txt");

            path = string.Empty;
            result = path.RemoveStartFolder("c:\\1\\2\\");
            Assert.IsTrue(result == string.Empty);
        }

        [TestMethod]
        public void TestAddStringToPath()
        {
            string path = "c:\\1\\MyFile.txt";

            string result = path.AddStringToPath(" /");
            Assert.IsTrue(result == "c:\\1\\MyFile.txt /");

            result = path.AddStringToPath("");
            Assert.IsTrue(result == "c:\\1\\MyFile.txt");

            path = "";
            result = path.AddStringToPath(" /");
            Assert.IsTrue(result == " /");
        }

        [TestMethod]
        public void TestReversePath()
        {
            string path = "c:\\1\\2\\MyFile.txt";

            string result = path.ReverseFolderPath();
            Assert.IsTrue(result == "MyFile.txt\\2\\1\\c:");

            path = "MyFile.txt";
            result = path.ReverseFolderPath();
            Assert.IsTrue(result == "MyFile.txt");

            path = "";
            result = path.ReverseFolderPath();
            Assert.IsTrue(result == "");

            path = "f\\bla\\ra\\t.dat";
            result = path.ReverseFolderPath();
            Assert.IsTrue(result == "t.dat\\ra\\bla\\f");
        }

        [TestMethod]
        public void TestReversePathString()
        {
            string path = "c:\\1\\2\\MyFile.txt";

            string result = path.ReverseAllPath();
            Assert.IsTrue(result == "txt.eliFyM\\2\\1\\:c");

            path = "MyFile.txt";
            result = path.ReverseAllPath();
            Assert.IsTrue(result == "txt.eliFyM");

            path = "";
            result = path.ReverseAllPath();
            Assert.IsTrue(result == "");

            path = "f\\bla\\ra\\t.dat";
            result = path.ReverseAllPath();
            Assert.IsTrue(result == "tad.t\\ar\\alb\\f");
        }
    }
}
