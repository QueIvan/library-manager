using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace LibraryConsoleManager
{
    internal class MenuUtils
    {
        private bool InFileOperations;

        public MenuUtils(bool SaveType)
        {
            InFileOperations = SaveType;
        }

        private bool IsNumberInRange(int Choice)
        {
            if (Choice >= 0 && Choice <= 6) return true;
            else throw new ArgumentOutOfRangeException();
        }

        private void ShowMenu()
        {
            Console.WriteLine("Witamy w bibliotece. wybierz co chcesz zrobić:\n");
            Console.WriteLine("   1. Dodaj książkę");
            Console.WriteLine("   2. Dodaj płytę");
            Console.WriteLine("   3. Dodaj czasopismo");
            Console.WriteLine("   4. Usuń pozycję");
            Console.WriteLine("   5. Wyświetl wszystkie pozycje");
            Console.WriteLine("   6. Wyświetl wszystkie pozycje danego podtypu");
            Console.WriteLine("   0. Wyjście");
            Console.Write("\nWybór: ");
        }

        public void RunMenu()
        {
            ActionHandler AH = new ActionHandler(InFileOperations);
            int Choice = -1;
            ShowMenu();

            while(Choice == -1)
            {
                try
                {
                    Choice = Int32.Parse(Console.ReadLine());
                    if (IsNumberInRange(Choice))
                    {
                        if (Choice == 1) AH.AddItem<Book>();
                        else if (Choice == 2) AH.AddItem<CD>();
                        else if (Choice == 3) AH.AddItem<Magazine>();
                        else if (Choice == 4) AH.DeleteItem();
                        else if (Choice == 5) AH.ShowAll();
                        else if (Choice == 6) AH.ShowMatching();
                        else if (Choice == 0) break;
                    }
                }catch (Exception ex)
                {
                    ExceptionHandler.ShowResponse(ex);
                }

                MenuUtils.Clean(2);
                if (Choice != -1) Choice = -1;
                ShowMenu();
            }
        }

        public static void Clean(int Timeout)
        {
            Console.WriteLine(" ");
            for (int i = Timeout; i > 0; i--)
            {
                Console.Write($"\rPowrót do menu głównego za {i} sekundy");
                Thread.Sleep(1000);
            }
            Console.WriteLine("\n");
            Console.Clear();
        }
    }
}
