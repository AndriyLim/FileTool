using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool
{
    public class FileList : IFileListBase<string>
    {
        private const string DefaultFileName = "results.txt";

        public async Task<List<string>> WalkDirThree(DirectoryInfo rootDir, List<string> notInclude)
        {
            var listFiles = Directory.EnumerateFiles(rootDir.FullName, "*.*", SearchOption.AllDirectories).ToList();
            if (notInclude != null)
            {
                listFiles.RemoveAll(t => notInclude.Any(v => Path.GetExtension(t) == v));
            }

            return listFiles;



            //var listFiles = new List<MyInfoFile>();

            //try
            //{
            //    foreach (FileInfo fi in rootDir.GetFiles())
            //    {
            //        var infoFile = new MyInfoFile(PathStringOperations.RemoveStartFolder(fi.FullName, startDir));
            //        if ((notInclude == null) || (notInclude.All(t => t != fi.Extension)))
            //        {
            //            listFiles.Add(infoFile);
            //        }
            //    }
            //}
            //catch (UnauthorizedAccessException UAE)
            //{
            //    WriteLog(UAE.Message);
            //}
            //catch (DirectoryNotFoundException DNFE)
            //{
            //    WriteLog(DNFE.Message);
            //}

            //try
            //{
            //    foreach (DirectoryInfo di in rootDir.GetDirectories())
            //    {
            //        listFiles.AddRange(WalkDirThree(di, startDir, notInclude));
            //    }
            //}
            //catch (Exception ex)
            //{
            //    WriteLog(ex.Message);
            //}

            //return listFiles;
        }

        public async Task<List<string>> FillList(string dirPath, string mode, List<string> notInclude = null)
        {
            var rootDir = new DirectoryInfo(dirPath);
            
            if (!rootDir.Exists)
            {
                throw new DirectoryNotFoundException(string.Format("Directory {0} not found", dirPath));
            }

            var list = await WalkDirThree(rootDir, notInclude);

            for (int i = 0; i < list.Count; i++)
            {
                list[i] = PathStringOperations.RemoveStartFolder(list[i], dirPath);
            }

            return list;
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

        public void WriteLog(string text)
        {
            //if (Logs == null)
            //{
            //    Logs = new StringBuilder();
            //}
            //Logs.AppendFormat("{0}\n", text);
        }
    }
}
