using System;

namespace LibraryConsoleManager
{
    enum EntryType
    {
        CD, Book, Magazine
    }
    abstract class LibraryEntry
    {
        private readonly uint CatalogId;
        private bool Rented;
        private bool Reserved;
        private string Title;
        private EntryType Type;
        private DateTime AdditionDate;

        /* Constructors */

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

        public override string ToString()
        {
            string TypeString = (Type == EntryType.CD) ? "Płyty" : (Type == EntryType.Magazine) ? "Magazynu" : "Książki";
            return $"\nDane {TypeString}:\n\n     Tytuł: {Title}\n     Numer katalogowy: {CatalogId}\n     Data Dodania: {AdditionDate}\n     Zarezerwowana: {StringUtils.BooleanConvert(Reserved)}\n     Wynajęta: {StringUtils.BooleanConvert(Rented)}";
        }

        public string GetState()
        {
            string TypeString = (Type == EntryType.CD) ? "Płyty" : (Type == EntryType.Magazine) ? "Magazynu" : "Książki";
            return $"\nStatus {TypeString}:\n\n     Zarezerwowana: {StringUtils.BooleanConvert(Reserved)}\n     Wynajęta: {StringUtils.BooleanConvert(Rented)}";
        }

    }
}
