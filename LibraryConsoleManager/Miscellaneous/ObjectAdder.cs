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
        ///Return list of all classes implementing given type along their name
        ///</summary>
        ///<returns>
        ///List of Type's and string's
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
        ///Return list of all classes implementing given type along their name for user to pick for creater
        ///</summary>
        ///<returns>
        ///Created object of T type
        ///</returns>
        public T ShowOptionsToUser<T>()
        {
            int choice;
            List<Tuple<Type, String>> Options = GetImplementating(typeof(T));

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\nProszę wybrać rodzaj dodawanego elementu:\n");


            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (Tuple<Type, String> Opt in Options)
                Console.WriteLine($"   {Options.IndexOf(Opt)+1}. {Opt.Item2}");
            Console.WriteLine($"   0. Inny niezdefiniowany element");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("\nWybór: ");
            Console.ForegroundColor = ConsoleColor.Cyan;

            choice = Int32.Parse(Console.ReadLine());
            Type Target = (choice != 0) ? Options[choice-1].Item1 : typeof(T);

            return (T) ReadObjects.Read(Target);
        }
    }
}
