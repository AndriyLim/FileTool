using System.Collections.Generic;

namespace Tool
{
    class FileUtils<T>
    {
        private readonly IFileList<T> _fileList;

        public FileUtils(IFileList<T> list)
        {
            _fileList = list;
        }

        public async void DoIt(string dirPath, string mode, string fileName, List<string> notInclude = null)
        {
            var list = await _fileList.FillList(dirPath, mode, notInclude);
            _fileList.CreateFile(list, fileName);
        }
    }
}
