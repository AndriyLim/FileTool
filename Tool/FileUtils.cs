using System.Collections.Generic;

namespace Tool
{
    /// <summary>
    /// create file with some data
    /// </summary>
    /// <typeparam name="T">generic type</typeparam>
    class FileUtils<T>
    {
        private readonly IFileList<T> _fileList;

        public FileUtils(IFileList<T> list)
        {
            _fileList = list;
        }

        /// <summary>
        /// create file with data
        /// </summary>
        /// <param name="dirPath">directory path</param>
        /// <param name="mode">list mode</param>
        /// <param name="fileName">new file name</param>
        /// <param name="notInclude">mask file list</param>
        public async void DoIt(string dirPath, string mode, string fileName, List<string> notInclude = null)
        {
            var list = await _fileList.FillList(dirPath, mode, notInclude);
            _fileList.CreateFile(list, fileName);
        }
    }
}
