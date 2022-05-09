using System;

namespace LibraryConsoleManager
{
    enum EntryType
    {
        CD, Book, Magazine
    }
    internal class LibraryEntry
    {
        private readonly uint CatalogId;
        private bool Rented;
        private bool Reserved;
        private string Title;
        private EntryType Type;
        private DateTime AdditionDate;
        private DateTime ModificationDate;

        /* Constructors */

        public LibraryEntry()
        {

        }

        public LibraryEntry(string Title, uint CatalogId, EntryType Type)
        {
            this.Title = Title;
            this.CatalogId = CatalogId;
            this.Type = Type;
            this.AdditionDate = DateTime.Now;
            this.Reserved = false;
            this.Rented = false;
        }

        public uint GetCatalogId()
        {
            return this.CatalogId;
        }

        public string GetTitle()
        {
            return this.Title;
        }

    }
}
