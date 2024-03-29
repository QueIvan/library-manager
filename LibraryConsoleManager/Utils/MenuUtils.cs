﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace LibraryConsoleManager
{
    internal class MenuUtils
    {
        /// <summary>
        /// Check if number is in a given Range
        /// </summary>
        /// <returns>If number is in range</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private static bool IsNumberInRange(int Choice)
        {
            if (Choice >= 0 && Choice <= 7) return true;
            else throw new ArgumentOutOfRangeException();
        }

        /// <summary>
        /// Show main menu of our program
        /// </summary>
        private static void ShowMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Witamy w bibliotece. Wybierz co chcesz zrobić:\n");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   1. Dodaj książkę");
            Console.WriteLine("   2. Dodaj płytę");
            Console.WriteLine("   3. Dodaj czasopismo");
            Console.WriteLine("   4. Usuń pozycję");
            Console.WriteLine("   5. Wyświetl wszystkie pozycje");
            Console.WriteLine("   6. Wyświetl wszystkie pozycje danego typu");
            Console.WriteLine("   7. Wyświetl status pozycji");
            Console.WriteLine("   0. Wyjście");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("\nWybór: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
        }

        /// <summary>
        /// Main app method
        /// </summary>
        public static void RunMenu()
        {
            ActionHandler AH = new ActionHandler();
            int Choice = -1;
            ShowMenu();

            while(Choice == -1)
            {
                try
                {
                    Choice = Int32.Parse(Console.ReadLine());
                    if (IsNumberInRange(Choice))
                    {
                        if(Choice != 0) MenuUtils.Clean(1, "Poprawna opcja, przechodzimy dalej");
                        if (Choice == 1) AH.AddItem<Book>();
                        else if (Choice == 2) AH.AddItem<CD>();
                        else if (Choice == 3) AH.AddItem<Magazine>();
                        else if (Choice == 4) AH.DeleteItem();
                        else if (Choice == 5) AH.ShowAll();
                        else if (Choice == 6) AH.ShowMatching();
                        else if (Choice == 7) AH.ShowStatus();
                        else if (Choice == 0) break;
                    }
                }catch (Exception ex)
                {
                    ExceptionHandler.ShowResponse(ex);
                }

                MenuUtils.Clean(2, "Powrót do menu głównego");
                if (Choice != -1) Choice = -1;
                ShowMenu();
            }
        }

        /// <summary>
        /// Method used to clear console after given timeout
        /// </summary>
        public static void Clean(int Timeout, String message = "")
        {
            Console.WriteLine(" ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            if (!message.Equals("")) Console.WriteLine($"{message},");
            for (int i = Timeout; i > 0; i--)
            {
                Console.Write($"\rZmiana ekranu za {i} sekundy");
                Thread.Sleep(1000);
            }
            Console.WriteLine("\n");
            Console.Clear();
        }

        /// <summary>
        /// Method that halts console awaiting any click
        /// </summary>
        public static void WaitToContinue()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\nWciśnij dowolny przycisk, aby kontynyować...");
            Console.ReadLine();
        }
    }
}
