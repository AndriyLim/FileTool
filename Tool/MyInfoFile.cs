using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool
{
    public class MyInfoFile
    {
        public String Filename { get; set; }

        public MyInfoFile(string filename)
        {
            Filename = filename;
        }

        public override string ToString()
        {
            return Filename;
        }
    }
}
