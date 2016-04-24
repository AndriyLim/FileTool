using System;
using System.Linq;

namespace Tool
{
    public static class PathStringOperations
    {
        public static string RemoveStartFolder(this string path, string startFolder)
        {
            return startFolder == string.Empty ? path : path.Replace(startFolder, "");
        }

        public static string AddStringToPath(this string path, string simpleString)
        {
            return path + simpleString;
        }

        public static string ReverseFolderPath(this string path)
        {
            var stringArray = path.Split(new[] { '\\' }).Reverse();
            return String.Join("\\", stringArray);
        }

        public static string ReverseAllPath(this string path)
        {
            var stringArray = path.ToCharArray().Reverse();
            return String.Join(string.Empty, stringArray);
        }
    }
}
