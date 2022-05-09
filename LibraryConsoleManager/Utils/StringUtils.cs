using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LibraryConsoleManager
{
    internal class StringUtils
    {
        public static string BooleanConvert(bool status)
        {
            return (status) ? "Tak" : "Nie";
        }

        public static string LeadingZeroAddition(int number)
        {
            return (number > 0 && number < 10) ? $"0{number}" : $"{number}";
        }
        public static string FillSpace(uint id, int size)
        {
            int SpaceCount = size - $"{id}".Length;
            return $"{String.Concat(Enumerable.Repeat(" ", SpaceCount))}{id}";
        }

        public static bool StringContains(string target, string match)
        {
            return Regex.IsMatch(target.ToLower(), $".*{match.ToLower()}.*");
        }
    }
}
