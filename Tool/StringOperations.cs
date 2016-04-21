using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool
{
    public static class PathStringOperations
    {
        public static string RemoveStartFolder(string path, string startFolder)
        {
            return startFolder == string.Empty ? path : path.Replace(startFolder, "");
        }

        public static string AddStringToPath(string path, string simpleString)
        {
            return path + simpleString;
        }

        public static string ReversePath(string path)
        {
            var stringArray = path.Split(new[] { '\\' }).Reverse();
            return String.Join("\\", stringArray);
        }

        public static string ReversePathString(string path)
        {
            var stringArray = path.ToCharArray().Reverse();
            return String.Join(string.Empty, stringArray);
        }
    }
}
