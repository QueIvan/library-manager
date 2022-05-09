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
        /// Konwertujemy zmienna logiczną na jej odpowiednik jako zmienna tekstowa
        /// </summary>
        /// <returns>
        /// Wartość tekstową zmiennej logicznej
        /// </returns>
        public static string BooleanConvert(bool status)
        {
            return (status) ? "Tak" : "Nie";
        }

        /// <summary>
        /// Jeżeli liczba jest w zakresie 0-10, dodajemy poprzedzające zero
        /// </summary>
        /// <returns>
        /// Liczbe po zmianie
        /// </returns>
        public static string LeadingZeroAddition(int number)
        {
            return (number > 0 && number < 10) ? $"0{number}" : $"{number}";
        }

        /// <summary>
        /// Metoda sprawdzająca czy dany ciąg znaków występuje w sprawdzanym tekscie
        /// </summary>
        /// <returns>
        /// Czy ciąg znaków jest w sprawdzanym tekście
        /// </returns>
        public static bool StringContains(string target, string match)
        {
            return Regex.IsMatch(target.ToLower(), $".*{match.ToLower()}.*");
        }
    }
}
