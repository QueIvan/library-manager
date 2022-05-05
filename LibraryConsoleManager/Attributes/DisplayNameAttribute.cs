using System;

namespace LibraryConsoleManager
{
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