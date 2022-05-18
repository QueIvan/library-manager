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
        /* List of all entries */
        private static List<LibraryEntry> Entries = new List<LibraryEntry>();

        ///<summary>
        ///Add new entry using Inputs.cs class
        ///</summary>
        public void AddItem<T>()
        {
            T CreatedObject = (AppDomain.CurrentDomain.GetAssemblies().SelectMany(s => s.GetTypes()).Where(t => typeof(T).IsAssignableFrom(t) && t != typeof(T)).Count() > 0) ? new ObjectAdder().ShowOptionsToUser<T>():ReadObjects.Read<T>();
            LibraryEntry Entry = CreatedObject as LibraryEntry;
            Entries.Add(Entry);
        }

        ///<summary>
        ///Delete entry using title or katalog id
        ///</summary>
        public void DeleteItem()
        {
            string InputValue;
            int IntValue;

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Podaj część tytułu lub numer katalogowy aby usunąć obiekt: ");
            Console.Write("     Zapytanie: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            InputValue = Console.ReadLine();

            // Check if input is integer
            if (int.TryParse(InputValue, out IntValue)) { 
                //Check if we found any matches
                if (Entries.Where(ent => ent.GetCatalogId() == IntValue).Count() > 0)
                    Entries.Remove(Entries.Where(ent => ent.GetCatalogId() == IntValue).ToList()[0]);
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nNie znaleziono obiektu do usunięcia");
                }
            }
            else
            {
                //Get all entries that contains given string
                List<LibraryEntry> Matching = Entries.Where(ent => StringUtils.StringContains(ent.GetTitle(), InputValue)).ToList();
                LibraryEntry Target;
                string decision;

                //Check if we got any matches
                if (Matching.Count != 0)
                {
                    /*
                     * If we have more than one match, we show them to user for them to decide
                     * Else we just mark one for deletion
                     */
                    if (Matching.Count > 1)
                    {
                        int choice;
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("\nZnaleziono więcej niż 1 pasujący wynik, proszę wybrać poprawny obiekt z listy poniżej:\n");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        foreach (LibraryEntry ent in Matching)
                            Console.WriteLine($"     {Matching.IndexOf(ent) + 1}. Tytuł: {ent.GetTitle()}, Numer Katalogowy: {ent.GetCatalogId()}");
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write("\nWybór: ");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        choice = Int32.Parse(Console.ReadLine()) - 1;
                        Target = Entries[Entries.IndexOf(Matching[choice])];
                    }
                    else
                        Target = Entries[Entries.IndexOf(Matching[0])];

                    //Making sure user want to delete it

                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("\nCzy na pewno chcesz usunąć ten obiekt?");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"\n     Tytuł: {Target.GetTitle()}, Numer Katalogowy: {Target.GetCatalogId()}\n");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("Wybór (T/N): ");
                    Console.ForegroundColor = ConsoleColor.Cyan;

                    decision = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.DarkCyan;

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
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nNie znaleziono obiektu do usunięcia");
                }

            }
        }

        ///<summary>
        ///Show all entries in memory
        ///</summary>
        public void ShowAll()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\nLista wszystkich obiektów w bibliotece\n");
            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (LibraryEntry entry in Entries)
                Console.WriteLine(entry.ToString());

            MenuUtils.WaitToContinue();
        }

        ///<summary>
        ///Show status of given entry
        ///</summary>
        public void ShowStatus()
        {
            int choice;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\nWybierz numer obiektu\n");

            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (LibraryEntry entry in Entries)
                Console.WriteLine($"     {Entries.IndexOf(entry) + 1}. Tytuł: {entry.GetTitle()}, Numer Katalogowy: {entry.GetCatalogId()}");

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("\nWybór: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            choice = Int32.Parse(Console.ReadLine());

            Console.WriteLine(Entries[choice - 1].GetState());

            MenuUtils.WaitToContinue();
        }

        ///<summary>
        ///Show all entries in memory of given type
        ///</summary>
        public void ShowMatching()
        {
            int choice;
            //Get all classes that implement LibraryEntry.cs
            List<Tuple<Type, String>> Options = new ObjectAdder().GetImplementating(typeof(LibraryEntry));

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\nWybierz typ do wyszukania:\n");
            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (Tuple<Type, String> entry in Options)
                Console.WriteLine($"     {Options.IndexOf(entry) + 1}. {entry.Item2}");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("\nWybór: ");

            choice = Int32.Parse(Console.ReadLine());
            List<LibraryEntry> Matching = Entries.Where(ent => ent.GetType() == Options[choice - 1].Item1).ToList();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\nLista znalezionych obiektów w bibliotece\n");
            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (LibraryEntry entry in Matching)
                Console.WriteLine(entry.ToString());

            MenuUtils.WaitToContinue();
        }
    }
}
