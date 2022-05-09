using System;

namespace LibraryConsoleManager
{
    /*
     * Klasa wykożystywana przy użyciu auto-formularza Inputs.cs dla klas
     */
    internal class DisplayNameAttribute : Attribute
    {
        private string Name;

        public DisplayNameAttribute(string Name)
        {
            this.Name = Name;
        }

        public string GetDisplayName()
        {
            return this.Name;
        }
    }
}