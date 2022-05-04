using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace LibraryConsoleManager
{
    internal class ExceptionHandler
    {
        public static void ShowResponse(string Name)
        {
            switch (Name)
            {
                case "FormatException":
                    Console.WriteLine($"\n[BŁĄD - {Name}] Proszę wpisywać wyłącznie liczby");
                    break;
                case "ArgumentOutOfRangeException":
                    Console.WriteLine($"\n[BŁĄD - {Name}] Wybierz wartość między 0 a 6");
                    break;
                default:
                    Console.WriteLine("\n[BŁĄD NIEZNANY] Wystąpił błąd który nie jest znany przez nasz zespół");
                    break;
            }
            for(int i = 2; i > 0; i--)
            {
                Console.Write($"\rPowrót do menu głównego za {i} sekundy");
                Thread.Sleep(1000);
            }
            Console.WriteLine("\n");
            Console.Clear();
        }
    }
}
