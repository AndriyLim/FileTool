using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool
{
    internal static class AttribureParser
    {
        static public List<string> Parse(string[] args, int attrCount)
        {
            var list = args.ToList();
            while (list.Count < attrCount)
            {
                list.Add(null);
            }
            return list;
        }
    }
}
