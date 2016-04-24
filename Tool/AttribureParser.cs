using System.Collections.Generic;
using System.Linq;

namespace Tool
{
    public static class AttribureParser
    {
        static public List<string> Parse(string[] args, int attrCount)
        {
            var list = args.Count() <= attrCount ? args.ToList() : args.Take(attrCount).ToList();
            while (list.Count < attrCount)
            {
                list.Add(null);
            }
            return list;
        }
    }
}
