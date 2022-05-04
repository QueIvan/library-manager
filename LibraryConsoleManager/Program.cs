using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryConsoleManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MenuUtils.RunMenu();
            Console.Write("\nAby zakończyć program, wciśnij dowolny przycisk...");
            Console.ReadLine();
        }
    }
}
