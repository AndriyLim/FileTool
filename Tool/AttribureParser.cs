using System.Collections.Generic;
using System.Linq;

namespace Tool
{
    /// <summary>
    /// class to parse string array to list
    /// </summary>
    public static class AttribureParser
    {
        /// <summary>
        /// parse іекштп array to list
        /// </summary>
        /// <param name="args">string array</param>
        /// <param name="attrCount">list size</param>
        /// <returns>string list</returns>
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
