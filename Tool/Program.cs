using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Path is NULL. Try again.");
                return;
            }

            var attr = AttribureParser.Parse(args, 3);
            string dirPath = attr[0];
            string mode = attr[1];
            string fileName = attr[2];

            var fileList = new FileList();

            var list = fileList.FillList(dirPath, mode, new List<string> {".cs", ".sln"});
            fileList.CreateFile(list.Result, fileName);

            switch (mode)
            {
                case "all":
                    Console.WriteLine("All");
                    break;
                case "срр":
                    Console.WriteLine("Cpp");
                    break;
                case "reversed1":
                    Console.WriteLine("Reversed1");
                    break;
                default:
                    Console.WriteLine("Mode is not set. Default mode is \"all\"");
                    break;
            }

            Console.WriteLine("{0} - {1}", dirPath, mode);

            //try
            //{
            //    //dirPath = @"c:\windows\assembly";

            //    FileArrayExtensinon2 fa = new FileArrayExtensinon2(dirPath);
            //    StringBuilder rezult = new StringBuilder(fa.GetRezult().ToString());

            //    FileStream fs = new FileStream("1.txt", FileMode.Create, FileAccess.Write);
            //    StreamWriter sr = new StreamWriter(fs);
            //    sr.Write(rezult);
            //    Console.WriteLine(rezult);

            //    sr.Close();
            //    fs.Close();
            //}
            //catch (DirectoryNotFoundException DNFEx)
            //{
            //    Console.WriteLine(DNFEx.Message);
            //}
            //catch (UnauthorizedAccessException UAEx)
            //{
            //    Console.WriteLine(UAEx.Message);
            //}
            //catch (PathTooLongException PathEx)
            //{
            //    Console.WriteLine(PathEx.Message);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
        }
    }
}
