using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tool
{
    interface IFileList<T>
    {
        Task<List<T>> FillList(string dirPath, string mode, List<string> notInclude);

        void CreateFile(List<T> fileList, string fileName);
    }
}
