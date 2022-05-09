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
        /// <summary>
        /// Sprawdzamy czy lista jest w naszym predefiniowanym zakresie
        /// </summary>
        /// <returns>Czy liczba jest w naszym zakresie</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private bool IsNumberInRange(int Choice)
        {
            if (Choice >= 0 && Choice <= 7) return true;
            else throw new ArgumentOutOfRangeException();
        }

        /// <summary>
        /// Wyświetlamy listę opcji naszego programu
        /// </summary>
        private void ShowMenu()
        {
            Console.WriteLine("Witamy w bibliotece. wybierz co chcesz zrobić:\n");
            Console.WriteLine("   1. Dodaj książkę");
            Console.WriteLine("   2. Dodaj płytę");
            Console.WriteLine("   3. Dodaj czasopismo");
            Console.WriteLine("   4. Usuń pozycję");
            Console.WriteLine("   5. Wyświetl wszystkie pozycje");
            Console.WriteLine("   6. Wyświetl wszystkie pozycje danego typu");
            Console.WriteLine("   7. Wyświetl status pozycji");
            Console.WriteLine("   0. Wyjście");
            Console.Write("\nWybór: ");
        }

        /// <summary>
        /// Główna metoda programu odpowiadająca za rozsyłanie do odpowiednich metod po wyborze
        /// </summary>
        public void RunMenu()
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
        /// Metoda służąca do wyczyszczenia ekranu po danym odstępie czasowym
        /// </summary>
        public static void Clean(int Timeout, String message = "")
        {
            Console.WriteLine(" ");
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
        /// Metoda wstrzymująca program do wciśnięcia przycisku
        /// </summary>
        public static void WaitToContinue()
        {
            Console.Write("\nWciśnij dowolny przycisk, aby kontynyować...");
            Console.ReadLine();
        }
    }
}
