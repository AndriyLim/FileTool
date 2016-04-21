using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Tool
{
    interface IFileListBase<T>
    {
        Task<List<T>> FillList(string dirPath, string mode, List<string> notInclude);

        Task<List<string>> WalkDirThree(DirectoryInfo rootDir, List<string> notInclude);

        void CreateFile(List<T> fileList, string fileName);

        void WriteLog(string text);
    }
}
