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

            string result = PathStringOperations.RemoveStartFolder(path, "c:\\1\\2\\");
            Assert.IsTrue(result == "3\\4\\5\\MyFile.txt");

            result = PathStringOperations.RemoveStartFolder(path, "");
            Assert.IsTrue(result == "c:\\1\\2\\3\\4\\5\\MyFile.txt");

            result = PathStringOperations.RemoveStartFolder(path, "c:\\1\\2\\3\\4\\5\\");
            Assert.IsTrue(result == "MyFile.txt");

            result = PathStringOperations.RemoveStartFolder(path, "d:\\1\\2\\3\\");
            Assert.IsTrue(result == "c:\\1\\2\\3\\4\\5\\MyFile.txt");

            path = "MyFile.txt";
            result = PathStringOperations.RemoveStartFolder(path, "c:\\1\\2\\");
            Assert.IsTrue(result == "MyFile.txt");

            path = string.Empty;
            result = PathStringOperations.RemoveStartFolder(path, "c:\\1\\2\\");
            Assert.IsTrue(result == string.Empty);
        }

        [TestMethod]
        public void TestAddStringToPath()
        {
            string path = "c:\\1\\MyFile.txt";

            string result = PathStringOperations.AddStringToPath(path, " /");
            Assert.IsTrue(result == "c:\\1\\MyFile.txt /");

            result = PathStringOperations.AddStringToPath(path, "");
            Assert.IsTrue(result == "c:\\1\\MyFile.txt");

            path = "";
            result = PathStringOperations.AddStringToPath(path, " /");
            Assert.IsTrue(result == " /");
        }

        [TestMethod]
        public void TestReversePath()
        {
            string path = "c:\\1\\2\\MyFile.txt";

            string result = PathStringOperations.ReversePath(path);
            Assert.IsTrue(result == "MyFile.txt\\2\\1\\c:");

            path = "MyFile.txt";
            result = PathStringOperations.ReversePath(path);
            Assert.IsTrue(result == "MyFile.txt");

            path = "";
            result = PathStringOperations.ReversePath(path);
            Assert.IsTrue(result == "");

            path = "f\\bla\\ra\\t.dat";
            result = PathStringOperations.ReversePath(path);
            Assert.IsTrue(result == "t.dat\\ra\\bla\\f");
        }

        [TestMethod]
        public void TestReversePathString()
        {
            string path = "c:\\1\\2\\MyFile.txt";

            string result = PathStringOperations.ReversePathString(path);
            Assert.IsTrue(result == "txt.eliFyM\\2\\1\\:c");

            path = "MyFile.txt";
            result = PathStringOperations.ReversePathString(path);
            Assert.IsTrue(result == "txt.eliFyM");

            path = "";
            result = PathStringOperations.ReversePathString(path);
            Assert.IsTrue(result == "");

            path = "f\\bla\\ra\\t.dat";
            result = PathStringOperations.ReversePathString(path);
            Assert.IsTrue(result == "tad.t\\ar\\alb\\f");
        }
    }
}
