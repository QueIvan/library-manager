using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace LibraryConsoleManager
{
    internal class ExceptionHandler
    {
        ///<summary>
        ///Wyświetl predefiniowaną odpowiedz do wyrzuconych wątków
        ///</summary>
        public static void ShowResponse(Exception Exc)
        {
            string Name = Exc.GetType().Name;
            switch (Name)
            {
                case "FormatException":
                    Console.WriteLine($"\n[BŁĄD - {Name}] Proszę wpisywać wyłącznie liczby");
                    break;
                case "ArgumentOutOfRangeException":
                    Console.WriteLine($"\n[BŁĄD - {Name}] Argument spoza zakresu");
                    break;
                default:
                    Console.WriteLine($"\n[BŁĄD NIEZNANY] {Exc.Message}");
                    Thread.Sleep(15000);
                    break;
            }
        }
    }
}
