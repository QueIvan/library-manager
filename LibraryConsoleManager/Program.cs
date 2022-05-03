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
            int choice = 9;
            do 
            {
                Console.WriteLine("Witamy w bibliotece. wybierz co chcesz zrobić:");
                Console.WriteLine("1-dodaj książkę");
                Console.WriteLine("2-dodaj płytę");
                Console.WriteLine("3-dodaj czasopismo");
                Console.WriteLine("4-usuń pozycję");
                Console.WriteLine("5-wyświetl wszystkie pozycje");
                Console.WriteLine("6-wyświetl wszystkie pozycje danego podtypu");
                Console.WriteLine("0-wyjście");
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception) { Console.WriteLine("proszę podać cyfrę"); };
                switch (choice)
                {
                    case 1:
                        //addbook();
                         break;
                    case 2:
                         //addCD();
                         break;
                    case 3:
                        //addmagazine();
                        break;
                    case 4:
                        //delete();
                        break;
                    case 5:
                        //show-all();
                        break;
                    case 6:
                        //show-specyfic-all();
                        break;
                    default:
                        Console.WriteLine("proszę podać numer z listy");
                        break;
                }
            }
            while (choice!=0); 
        }
    }
}
