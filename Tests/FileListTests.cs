using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            testClass.ModifyList(dirPath, listMode[0], testList, null);
            Assert.IsTrue(testList.Count == 9);
            Assert.IsTrue(testList.SequenceEqual(resultList1));

            testList.Clear();
            testList.AddRange(firstList);
            testClass.ModifyList(dirPath, listMode[1], testList, null);
            Assert.IsTrue(testList.Count == 3);
            Assert.IsTrue(testList.SequenceEqual(resultList2));

            testList.Clear();
            testList.AddRange(firstList);
            testClass.ModifyList(dirPath, listMode[1], testList, new List<string> { ".cs", ".cpp" });
            Assert.IsTrue(testList.Count == 6);
            Assert.IsTrue(testList.SequenceEqual(resultList3));

            testList.Clear();
            testList.AddRange(firstList);
            testClass.ModifyList(dirPath, listMode[2], testList, null);
            Assert.IsTrue(testList.Count == 9);
            Assert.IsTrue(testList.SequenceEqual(resultList4));

            testList.Clear();
            testList.AddRange(firstList);
            testClass.ModifyList(dirPath, listMode[3], testList, null);
            Assert.IsTrue(testList.Count == 9);
            Assert.IsTrue(testList.SequenceEqual(resultList5));

        }


        //public void ModifyList(string dirPath, string mode, List<string> list, List<string> needExt)
        //{
        //    switch (mode)
        //    {
        //        case "all":
        //            for (int i = 0; i < list.Count; i++)
        //            {
        //                list[i] = list[i].RemoveStartFolder(dirPath);
        //            }
        //            break;
        //        case "cpp":
        //            if (needExt == null)
        //            {
        //                needExt = NeedExt;
        //            }

        //            list.RemoveAll(t => !needExt.Contains(Path.GetExtension(t)));
        //            for (int i = 0; i < list.Count; i++)
        //            {
        //                list[i] = list[i].AddStringToPath(" /");
        //            }
        //            break;
        //        case "reversed1":
        //            for (int i = 0; i < list.Count; i++)
        //            {
        //                list[i] = list[i].ReverseFolderPath();
        //            }
        //            break;
        //        case "reversed2":
        //            for (int i = 0; i < list.Count; i++)
        //            {
        //                list[i] = list[i].ReverseAllPath();
        //            }
        //            break;
        //    }
        //}
    }
}
