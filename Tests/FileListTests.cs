using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tool;

namespace Tests
{
    [TestClass]
    public class FileListTests
    {
        [TestMethod]
        public void ModifyListTest()
        {
            string dirPath = "d:\\1\\";
            var listMode = new List<string> { "all", "cpp", "reversed1", "reversed2" };
            string mode;
            var firstList = new List<string> { "d:\\1\\11.txt", "d:\\1\\2\\21.txt", "d:\\1\\2\\3\\31.txt", 
                                               "d:\\1\\12.cpp", "d:\\1\\2\\22.cpp", "d:\\1\\2\\3\\32.cpp",
                                               "d:\\1\\13.cs",  "d:\\1\\2\\23.cs",  "d:\\1\\2\\3\\33.cs" };

            var resultList1 = new List<string> { "11.txt", "2\\21.txt", "2\\3\\31.txt", 
                                                 "12.cpp", "2\\22.cpp", "2\\3\\32.cpp",
                                                 "13.cs",  "2\\23.cs",  "2\\3\\33.cs" };
            var resultList2 = new List<string> { "12.cpp /", "2\\22.cpp /", "2\\3\\32.cpp /" };
            var resultList3 = new List<string> { "12.cpp /", "2\\22.cpp /", "2\\3\\32.cpp /",
                                                 "13.cs /",  "2\\23.cs /",  "2\\3\\33.cs /" };
            var resultList4 = new List<string> { "11.txt", "21.txt\\2", "31.txt\\3\\2", 
                                                 "12.cpp", "22.cpp\\2", "32.cpp\\3\\2",
                                                 "13.cs",  "23.cs\\2",  "33.cs\\3\\2" };
            var resultList5 = new List<string> { "txt.11", "txt.12\\2", "txt.13\\3\\2", 
                                                 "ppc.21", "ppc.22\\2", "ppc.23\\3\\2",
                                                 "sc.31",  "sc.32\\2",  "sc.33\\3\\2" };

            var testList = new List<string>();
            var needExt = new List<string> { ".cs", ".cpp" };

            var testClass = new FileList();

            testList.Clear();
            testList.AddRange(firstList);
            testClass.ModifyList(testList, listMode[0], dirPath, null);
            Assert.IsTrue(testList.Count == 9);
            Assert.IsTrue(testList.SequenceEqual(resultList1));

            testList.Clear();
            testList.AddRange(firstList);
            testClass.ModifyList(testList, listMode[1], dirPath, null);
            Assert.IsTrue(testList.Count == 3);
            Assert.IsTrue(testList.SequenceEqual(resultList2));

            testList.Clear();
            testList.AddRange(firstList);
            testClass.ModifyList(testList, listMode[1], dirPath, needExt);
            Assert.IsTrue(testList.Count == 6);
            Assert.IsTrue(testList.SequenceEqual(resultList3));

            testList.Clear();
            testList.AddRange(firstList);
            testClass.ModifyList(testList, listMode[2], dirPath, null);
            Assert.IsTrue(testList.Count == 9);
            Assert.IsTrue(testList.SequenceEqual(resultList4));

            testList.Clear();
            testList.AddRange(firstList);
            testClass.ModifyList(testList, listMode[3], dirPath, null);
            Assert.IsTrue(testList.Count == 9);
            Assert.IsTrue(testList.SequenceEqual(resultList5));

        }

        [TestMethod]
        public void CreateFileTest()
        {
            var fileList1 = new List<string> { "d:\\1\\11.txt", "d:\\1\\2\\21.txt", "d:\\1\\2\\3\\31.txt", 
                                               "d:\\1\\12.cpp", "d:\\1\\2\\22.cpp", "d:\\1\\2\\3\\32.cpp",
                                               "d:\\1\\13.cs",  "d:\\1\\2\\23.cs",  "d:\\1\\2\\3\\33.cs" };

            var fileList2 = new List<string> { "txt.11", "txt.12\\2", "txt.13\\3\\2", 
                                                 "ppc.21", "ppc.22\\2", "ppc.23\\3\\2",
                                                 "sc.31",  "sc.32\\2",  "sc.33\\3\\2" };

            string fileName1 = "file1.txt";
            string fileName2 = "file2.txt";

            var testClass = new FileList();

            testClass.CreateFile(fileList1, fileName1);

            Assert.IsTrue(File.Exists(fileName1));

            var testFileList = new List<string>();
            using (var fs = new FileStream(fileName1, FileMode.Open, FileAccess.Read))
            {
                using (var sr = new StreamReader(fs))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        testFileList.Add(line);
                    }
                }
            }
            Assert.IsTrue(testFileList.SequenceEqual(fileList1));


            testClass.CreateFile(fileList2, fileName2);

            Assert.IsTrue(File.Exists(fileName2));

            testFileList = new List<string>();
            using (var fs = new FileStream(fileName2, FileMode.Open, FileAccess.Read))
            {
                using (var sr = new StreamReader(fs))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        testFileList.Add(line);
                    }
                }
            }
            Assert.IsTrue(testFileList.SequenceEqual(fileList2));

            File.Delete(fileName1);
            File.Delete(fileName2);
        }


        [TestMethod]
        public void WalkDirTreeTest()
        {
            var fileList1 = new List<string> { "1.cpp", "2\\2.cs", "2\\3\\31.cpp", "2\\3\\32.exe" };

            var testClass = new FileList();
            Directory.CreateDirectory("1");
            File.Create("1\\1.cpp").Close();
            Directory.CreateDirectory("1\\2");
            File.Create("1\\2\\2.cs").Close();
            Directory.CreateDirectory("1\\2\\3");
            File.Create("1\\2\\3\\31.cpp").Close();
            File.Create("1\\2\\3\\32.exe").Close();

            var rootDir = new DirectoryInfo(Directory.GetCurrentDirectory() + "\\1\\");
            
            var testFileList = testClass.WalkDirTree(rootDir).Result;
            for (int i = 0; i < testFileList.Count; i++)
            {
                testFileList[i] = testFileList[i].RemoveStartFolder(rootDir.FullName);
            }
            Assert.IsTrue(testFileList.SequenceEqual(fileList1));

            Directory.Delete("1", true);
        }
    }
}
