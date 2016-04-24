using System;
using System.Linq;

namespace Tool
{
    /// <summary>
    /// class with file path extension methods
    /// </summary>
    public static class PathStringOperations
    {
        /// <summary>
        /// remove base directory path from full path
        /// </summary>
        /// <param name="path">full path</param>
        /// <param name="startFolder">base directory path</param>
        /// <returns>paht list without base directory</returns>
        public static string RemoveStartFolder(this string path, string startFolder)
        {
            return startFolder == string.Empty ? path : path.Replace(startFolder, "");
        }

        /// <summary>
        /// add some string to full path
        /// </summary>
        /// <param name="path">full path</param>
        /// <param name="simpleString">string which added</param>
        /// <returns>path with some string</returns>
        public static string AddStringToPath(this string path, string simpleString)
        {
            return path + simpleString;
        }

        /// <summary>
        /// reverse all elements in full path
        /// </summary>
        /// <param name="path">full path</param>
        /// <returns>reversed path</returns>
        public static string ReverseFolderPath(this string path)
        {
            var stringArray = path.Split(new[] { '\\' }).Reverse();
            return String.Join("\\", stringArray);
        }

        /// <summary>
        /// reverse all path
        /// </summary>
        /// <param name="path">full path</param>
        /// <returns>reversed path</returns>
        public static string ReverseAllPath(this string path)
        {
            var stringArray = path.ToCharArray().Reverse();
            return String.Join(string.Empty, stringArray);
        }
    }
}
