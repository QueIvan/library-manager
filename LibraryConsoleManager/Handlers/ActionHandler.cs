using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryConsoleManager
{
    internal class ActionHandler
    {
        public void AddItem<T>()
        {
            Inputs.ReadObject<T>();
        }
        public void DeleteItem()
        {

        }
        public void ShowAll()
        {

        }
        public void ShowMatching()
        {

        }
    }
}
