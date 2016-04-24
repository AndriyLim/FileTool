using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tool
{
    /// <summary>
    /// interface of file list
    /// </summary>
    /// <typeparam name="T">generic</typeparam>
    interface IFileList<T>
    {
        /// <summary>
        /// Fill file list from base directory
        /// </summary>
        /// <param name="dirPath">base directory path</param>
        /// <param name="mode">type of list</param>
        /// <param name="needExt">mask list of files</param>
        /// <returns>file list in need mode</returns>
        Task<List<T>> FillList(string dirPath, string mode, List<string> needExt);

        /// <summary>
        /// create file with input data
        /// </summary>
        /// <param name="fileList">list of data</param>
        /// <param name="fileName">filename</param>
        void CreateFile(List<T> fileList, string fileName);
    }
}
