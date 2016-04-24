using System;
using System.Collections.Generic;
using System.IO;

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

            string str = args[1];


            var attr = AttribureParser.Parse(args, 3);
            string dirPath = attr[0];
            string mode = attr[1];
            string fileName = attr[2];

            try
            {
                var util = new FileUtils<string>(new FileList());

                util.DoIt(dirPath, mode, fileName/*, new List<string> { ".cs", ".sln", ".cache", ".exe" }*/);

                Console.WriteLine("{0} - {1}", dirPath, mode);
            }
            catch (DirectoryNotFoundException DNFEx)
            {
                Console.WriteLine(DNFEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
