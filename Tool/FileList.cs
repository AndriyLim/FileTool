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

        // TODO сделать тест сами создаем проверяем и удаляем
        public async Task<List<string>> FillList(string dirPath, string mode, List<string> needExt = null)
        {
            var rootDir = new DirectoryInfo(dirPath);

            if (!rootDir.Exists)
            {
                throw new Exception(string.Format("Directory {0} not found", dirPath));
            }

            var list = await WalkDirTree(rootDir);

            ModifyList(dirPath, mode, list, needExt);

            return list;
        }

        // TODO сделать тест сами создаем проверяем и удаляем
        public async Task<List<string>> WalkDirTree(DirectoryInfo rootDir)
        {
            return Directory.EnumerateFiles(rootDir.FullName, "*.*", SearchOption.AllDirectories).ToList();
        }

        public void ModifyList(string dirPath, string mode, List<string> list, List<string> needExt)
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

        // TODO сделать тест
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
