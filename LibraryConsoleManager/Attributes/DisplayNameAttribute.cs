using System;

namespace LibraryConsoleManager
{
    /*
     * Attribute used to set display name of classes for creator
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