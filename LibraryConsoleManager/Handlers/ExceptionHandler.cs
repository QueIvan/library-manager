using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace LibraryConsoleManager
{
    internal class ExceptionHandler
    {
        public static void ShowResponse(Exception Exc, bool corr = true)
        {
            string Name = Exc.GetType().Name;
            switch (Name)
            {
                case "FormatException":
                    Console.WriteLine($"\n[BŁĄD - {Name}] Proszę wpisywać wyłącznie liczby");
                    break;
                case "ArgumentOutOfRangeException":
                    Console.WriteLine($"\n[BŁĄD - {Name}] Wybierz wartość między 0 a 6");
                    break;
                default:
                    Console.WriteLine($"\n[BŁĄD NIEZNANY] {Exc.Message}");
                    Thread.Sleep(15000);
                    break;
            }
        }
    }
}
