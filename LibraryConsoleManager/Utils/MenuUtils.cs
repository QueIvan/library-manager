﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryConsoleManager
{
    internal class MenuUtils
    {
        public static bool IsNumberInRange(int Choice)
        {
            if (Choice >= 0 && Choice <= 6) return true;
            else throw new ArgumentOutOfRangeException();
        }
        public static void ShowMenu()
        {
            Console.WriteLine("\nWitamy w bibliotece. wybierz co chcesz zrobić:\n");
            Console.WriteLine("   1. Dodaj książkę");
            Console.WriteLine("   2. Dodaj płytę");
            Console.WriteLine("   3. Dodaj czasopismo");
            Console.WriteLine("   4. Usuń pozycję");
            Console.WriteLine("   5. Wyświetl wszystkie pozycje");
            Console.WriteLine("   6. Wyświetl wszystkie pozycje danego podtypu");
            Console.WriteLine("   0. Wyjście");
            Console.Write("\nWybór: ");
        }
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
                        if (Choice >= 1 && Choice <= 3) AH.AddItem();
                        else if (Choice == 4) AH.DeleteItem();
                        else if (Choice == 5) AH.ShowAll();
                        else if (Choice == 6) AH.ShowMatching();
                    }
                }catch (Exception ex)
                {
                    ExceptionHandler.ShowResponse(ex.GetType().Name);
                    if (Choice != -1) Choice = -1;
                    ShowMenu();
                }
            }
        }
    }
}