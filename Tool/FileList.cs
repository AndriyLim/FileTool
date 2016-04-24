using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Tool
{
    public class FileList : IFileList<string>
    {
        private const string DefaultFileName = "results.txt";
        private static readonly List<string> NeedExt = new List<string> { ".cpp" };

        public async Task<List<string>> FillList(string dirPath, string mode, List<string> needExt = null)
        {
            var rootDir = new DirectoryInfo(dirPath);

            if (!rootDir.Exists)
            {
                throw new Exception(string.Format("Directory {0} not found", dirPath));
            }

            var list = await WalkDirTree(rootDir);

            ModifyList(list, mode, dirPath, needExt);

            return list;
        }

        /// <summary>
        /// get files list from base directory
        /// </summary>
        /// <param name="rootDir">base directory full path</param>
        /// <returns>files list from base directory</returns>
        public async Task<List<string>> WalkDirTree(DirectoryInfo rootDir)
        {
            return Directory.EnumerateFiles(rootDir.FullName, "*.*", SearchOption.AllDirectories).ToList();
        }

        /// <summary>
        /// modify list to some type
        /// </summary>
        /// <param name="list">list to modify</param>
        /// <param name="mode">modify mode</param>
        /// <param name="dirPath">base directory path</param>
        /// <param name="needExt">mask file list</param>
        public void ModifyList(List<string> list, string mode, string dirPath, List<string> needExt)
        {
            switch (mode)
            {
                case "all":
                    for (int i = 0; i < list.Count; i++)
                    {
                        list[i] = list[i].RemoveStartFolder(dirPath);
                    }
                    break;
                case "cpp":
                    if (needExt == null)
                    {
                        needExt = NeedExt;
                    }

                    list.RemoveAll(t => !needExt.Contains(Path.GetExtension(t)));
                    for (int i = 0; i < list.Count; i++)
                    {
                        list[i] = list[i].RemoveStartFolder(dirPath).AddStringToPath(" /");
                    }
                    break;
                case "reversed1":
                    for (int i = 0; i < list.Count; i++)
                    {
                        list[i] = list[i].RemoveStartFolder(dirPath).ReverseFolderPath();
                    }
                    break;
                case "reversed2":
                    for (int i = 0; i < list.Count; i++)
                    {
                        list[i] = list[i].RemoveStartFolder(dirPath).ReverseAllPath();
                    }
                    break;
            }
        }

        public void CreateFile(List<string> fileList, string fileName)
        {
            if (fileName == null)
            {
                fileName = DefaultFileName;
            }
            using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                using (var sr = new StreamWriter(fs))
                {
                    foreach (var myInfoFile in fileList)
                    {
                        sr.WriteLine(myInfoFile);
                    }
                }
            }
        }
    }
}
