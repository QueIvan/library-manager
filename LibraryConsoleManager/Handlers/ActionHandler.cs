using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace LibraryConsoleManager
{
    internal class ActionHandler
    {
        private static List<LibraryEntry> Entries = new List<LibraryEntry>();
        public ActionHandler()
        {
            Entries.Add(new PopularBook("Ja i ty", "Sci-Fi", "Jan", "Szewczyk", 123123, 3213, 1999));
            Entries.Add(new PopularBook("Ty i ja", "Sci-Fi", "Jan", "Szewczyk", 312321, 3213, 1999));
            Entries.Add(new EducationalBook("Biologia", "średnio-zaawansowany", "ty", "Jan", "Szewczyk", 654123, 3213, 1999));
            Entries.Add(new EducationalBook("Informatyka", "podstawa", "Ja", "Jan", "Szewczyk", 456205, 3213, 1999));
            Entries.Add(new Book("Ty i ja #232", "Jan", "Szewczyk", 665464, 3213, 1999));
        }
        public void AddItem<T>()
        {
            T CreatedObject = (AppDomain.CurrentDomain.GetAssemblies().SelectMany(s => s.GetTypes()).Where(t => typeof(T).IsAssignableFrom(t) && t != typeof(T)).Count() > 0) ? new ObjectAdder().ShowOptionsToUser<T>():ReadObjects.Read<T>();
            LibraryEntry Entry = CreatedObject as LibraryEntry;
            Entries.Add(Entry);
        }
        public void DeleteItem()
        {
            string InputValue;
            int IntValue;

            Console.WriteLine("Podaj część tytułu lub numer katalogowy aby usunąć obiekt: ");
            Console.Write("     Zapytanie: ");
            InputValue = Console.ReadLine();

            if (int.TryParse(InputValue, out IntValue))
                Entries.Remove(Entries.Where(ent => ent.GetCatalogId() == IntValue).ToList()[0]);
            else
            {
                List<LibraryEntry> Matching = Entries.Where(ent => StringUtils.StringContains(ent.GetTitle(), InputValue)).ToList();
                if(Matching.Count > 1)
                {
                    int choice;
                    Console.WriteLine("\nZnaleziono więcej niż 1 pasujący wynik, proszę wybrać poprawny obiekt z listy poniżej:\n");
                    foreach (LibraryEntry ent in Matching)
                        Console.WriteLine($"     {Matching.IndexOf(ent) + 1}. Tytuł: {ent.GetTitle()}, Numer Katalogowy: {ent.GetCatalogId()}");
                    Console.Write("\nWybór: ");
                    choice = Int32.Parse(Console.ReadLine());
                    Entries.RemoveAt(choice - 1);
                    Console.WriteLine("Pomyślnie usunięto element z tablicy");
                }
            }
        }
        public void ShowAll()
        {
            Console.WriteLine("\nLista wszystkich obiektów w bibliotece\n");
            foreach(LibraryEntry entry in Entries)
                Console.WriteLine($"     {Entries.IndexOf(entry) + 1}. Tytuł: {entry.GetTitle()}, Numer Katalogowy: {entry.GetCatalogId()}");

            MenuUtils.WaitToContinue();
        }
        public void ShowMatching()
        {
            int choice;
            List<Tuple<Type, String>> Options = new ObjectAdder().GetImplementating(typeof(LibraryEntry));

            Console.WriteLine("\nWybierz typ do wyszukania:\n");
            foreach (Tuple<Type, String> entry in Options)
                Console.WriteLine($"     {Options.IndexOf(entry)+1}. {entry.Item2}");
            Console.Write("\nWybór: ");

            choice = Int32.Parse(Console.ReadLine());
            List<LibraryEntry> Matching = Entries.Where(ent =>ent.ToString().Equals(Options[choice - 1].Item1.ToString())).ToList();

            Console.WriteLine("\nLista znalezionych obiektów w bibliotece\n");
            foreach (LibraryEntry entry in Matching)
                Console.WriteLine($"     {Matching.IndexOf(entry) + 1}. Tytuł: {entry.GetTitle()}, Numer Katalogowy: {entry.GetCatalogId()}");

            MenuUtils.WaitToContinue();
        }
    }
}
