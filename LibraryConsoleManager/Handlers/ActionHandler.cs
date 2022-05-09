using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LibraryConsoleManager
{
    internal class ActionHandler
    {
        /* Lista wszystkich pozycji */
        private static List<LibraryEntry> Entries = new List<LibraryEntry>();

        /*
         * Aby zapełnić listę powyżej proszę odkomentować konstruktor poniżej
         */

        /*
        public ActionHandler()
        {
            Entries.Add(new PopularBook("Ja i ty", "Sci-Fi", "Jan", "Szewczyk", 123123, 3213, 1999));
            Entries.Add(new PopularBook("Ty i ja", "Sci-Fi", "Jan", "Szewczyk", 312321, 3213, 1999));
            Entries.Add(new EducationalBook("Biologia", "średnio-zaawansowany", "ty", "Jan", "Szewczyk", 654123, 3213, 1999));
            Entries.Add(new EducationalBook("Informatyka", "podstawa", "Ja", "Jan", "Szewczyk", 456205, 3213, 1999));
            Entries.Add(new Book("Ty i ja #232", "Jan", "Szewczyk", 665464, 3213, 1999));
        }
         */

        ///<summary>
        ///Dodaj nową pozycję używając auto-formularza Inputs.cs
        ///</summary>
        public void AddItem<T>()
        {
            T CreatedObject = (AppDomain.CurrentDomain.GetAssemblies().SelectMany(s => s.GetTypes()).Where(t => typeof(T).IsAssignableFrom(t) && t != typeof(T)).Count() > 0) ? new ObjectAdder().ShowOptionsToUser<T>():ReadObjects.Read<T>();
            LibraryEntry Entry = CreatedObject as LibraryEntry;
            Entries.Add(Entry);
        }

        ///<summary>
        ///Usuń pozycję z listy używając części tytułu lub numeru katalogowego
        ///</summary>
        public void DeleteItem()
        {
            string InputValue;
            int IntValue;

            Console.WriteLine("Podaj część tytułu lub numer katalogowy aby usunąć obiekt: ");
            Console.Write("     Zapytanie: ");
            InputValue = Console.ReadLine();

            // Sprawdzamy czy wartość jest liczbą
            if (int.TryParse(InputValue, out IntValue)) { 
                //Sprawdzamy czy znaleziono chociaż jeden pasujący element
                if (Entries.Where(ent => ent.GetCatalogId() == IntValue).Count() > 0)
                    Entries.Remove(Entries.Where(ent => ent.GetCatalogId() == IntValue).ToList()[0]);
                else
                    Console.WriteLine("\nNie znaleziono obiektu do usunięcia");
            }
            else
            {
                //Bierzemy wszystkie pozycje których tytuł pasuje do zapytania
                List<LibraryEntry> Matching = Entries.Where(ent => StringUtils.StringContains(ent.GetTitle(), InputValue)).ToList();
                LibraryEntry Target;
                string decision;
                
                //Sprawdzamy czy znaleziono pasujące elementy
                if (Matching.Count != 0)
                {
                    /*
                     * Gdy mamy więcej niż jeden element, wyświetlamy wszystkie pasujące i dajemy możliwość wybrania
                     * W innym przypadku usuwamy jedyny wynik
                     */
                    if (Matching.Count > 1)
                    {
                        int choice;
                        Console.WriteLine("\nZnaleziono więcej niż 1 pasujący wynik, proszę wybrać poprawny obiekt z listy poniżej:\n");
                        foreach (LibraryEntry ent in Matching)
                            Console.WriteLine($"     {Matching.IndexOf(ent) + 1}. Tytuł: {ent.GetTitle()}, Numer Katalogowy: {ent.GetCatalogId()}");
                        Console.Write("\nWybór: ");
                        choice = Int32.Parse(Console.ReadLine()) - 1;
                        Target = Entries[Entries.IndexOf(Matching[choice])];
                    }else
                        Target = Entries[Entries.IndexOf(Matching[0])];

                    //Upewniamy się czy użytkownik chce usunąć dany obiekt

                    Console.WriteLine("\nCzy na pewno chcesz usunąć ten obiekt?");
                    Console.WriteLine($"\n     Tytuł: {Target.GetTitle()}, Numer Katalogowy: {Target.GetCatalogId()}\n");
                    Console.Write("Wybór (T/N): ");

                    decision = Console.ReadLine();

                    if (decision.ToLower().Equals("t") || decision.ToLower().Equals("tak"))
                    {
                        Entries.Remove(Target);
                        Console.WriteLine("\nPomyślnie usunięto element z tablicy");
                    }
                    else if (decision.ToLower().Equals("n") || decision.ToLower().Equals("nie"))
                    {
                        Console.WriteLine("\nAnuluje usuwanie");
                    }
                }
                else
                    Console.WriteLine("\nNie znaleziono obiektu do usunięcia");

            }
        }

        ///<summary>
        ///Wyświetl wszyskie elementy listy
        ///</summary>
        public void ShowAll()
        {
            Console.WriteLine("\nLista wszystkich obiektów w bibliotece\n");
            foreach(LibraryEntry entry in Entries)
                Console.WriteLine(entry.ToString());

            MenuUtils.WaitToContinue();
        }

        ///<summary>
        ///Wyświetl status wybranego elementu
        ///</summary>
        public void ShowStatus()
        {
            int choice;
            Console.WriteLine("\nWybierz numer obiektu\n");

            foreach (LibraryEntry entry in Entries)
                Console.WriteLine($"     {Entries.IndexOf(entry) + 1}. Tytuł: {entry.GetTitle()}, Numer Katalogowy: {entry.GetCatalogId()}");

            Console.Write("\nWybór: ");
            choice = Int32.Parse(Console.ReadLine());

            Console.WriteLine(Entries[choice - 1].GetState());

            MenuUtils.WaitToContinue();
        }

        ///<summary>
        ///Wyświetl wszyskie elementy listy, które spełniają wybrane kryterium
        ///</summary>
        public void ShowMatching()
        {
            int choice;
            //Pobieramy wszystkie klasy które implementują LibraryEntry.cs
            List<Tuple<Type, String>> Options = new ObjectAdder().GetImplementating(typeof(LibraryEntry));
            
            Console.WriteLine("\nWybierz typ do wyszukania:\n");
            foreach (Tuple<Type, String> entry in Options)
                Console.WriteLine($"     {Options.IndexOf(entry) + 1}. {entry.Item2}");
            Console.Write("\nWybór: ");

            choice = Int32.Parse(Console.ReadLine());
            List<LibraryEntry> Matching = Entries.Where(ent => ent.GetType() == Options[choice - 1].Item1).ToList();

            Console.WriteLine("\nLista znalezionych obiektów w bibliotece\n");
            foreach (LibraryEntry entry in Matching)
                Console.WriteLine(entry.ToString());

            MenuUtils.WaitToContinue();
        }
    }
}
