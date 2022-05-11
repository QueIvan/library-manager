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
        /// <summary>
        /// Convert boolean to it's string representation
        /// </summary>
        /// <returns>
        /// String value of status
        /// </returns>
        public static string BooleanConvert(bool status)
        {
            return (status) ? "Tak" : "Nie";
        }

        /// <summary>
        /// If number is between 0 and 10, we add leading zero to it
        /// </summary>
        /// <returns>
        /// Correct display number
        /// </returns>
        public static string LeadingZeroAddition(int number)
        {
            return (number > 0 && number < 10) ? $"0{number}" : $"{number}";
        }

        /// <summary>
        /// Method used to check if string contains query
        /// </summary>
        /// <returns>
        /// If string contains query
        /// </returns>
        public static bool StringContains(string target, string match)
        {
            return Regex.IsMatch(target.ToLower(), $".*{match.ToLower()}.*");
        }
    }
}
