using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryConsoleManager
{
    internal class ObjectAdder
    {
        ///<summary>
        ///Zwróć listę wszystkich klas implementujących wybraną metodę oraz jej nazwę
        ///</summary>
        ///<returns>
        ///Liste klas implementujących klase
        ///</returns>
        public List<Tuple<Type, String>> GetImplementating(Type Implementation)
        {
            List<Tuple<Type, String>> OptionsList = new List<Tuple<Type, String>>();
            var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(s=>s.GetTypes()).Where(t => Implementation.IsAssignableFrom(t) && t != Implementation);
            foreach(Type type in types)
            {
                DisplayNameAttribute att = type.GetCustomAttributes(typeof(DisplayNameAttribute), true).FirstOrDefault() as DisplayNameAttribute;
                if (att != null)
                    OptionsList.Add(new Tuple<Type, String>(type, att.GetDisplayName()));
            }
            return OptionsList;
        }

        ///<summary>
        ///Wyświetl wszystkie klasy implementujące typ, do wyboru przez użytkownika
        ///</summary>
        ///<returns>
        ///Stworzony obiekt przez kreator
        ///</returns>
        public T ShowOptionsToUser<T>()
        {
            int choice;
            List<Tuple<Type, String>> Options = GetImplementating(typeof(T));

            Console.WriteLine("\nProszę wybrać rodzaj dodawanego elementu:\n");

            foreach(Tuple<Type, String> Opt in Options)
                Console.WriteLine($"   {Options.IndexOf(Opt)+1}. {Opt.Item2}");
            Console.WriteLine($"   0. Inny niezdefiniowany element");
            Console.Write("\nWybór: ");

            choice = Int32.Parse(Console.ReadLine());
            Type Target = (choice != 0) ? Options[choice-1].Item1 : typeof(T);

            return (T) ReadObjects.Read(Target);
        }
    }
}
