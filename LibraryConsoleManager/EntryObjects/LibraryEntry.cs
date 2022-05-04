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

        public LibraryEntry(string Title, uint CatalogId, EntryType Type)
        {
            this.Title = Title;
            this.CatalogId = CatalogId;
            this.Type = Type;
            this.AdditionDate = DateTime.Now;
            this.Reserved = false;
            this.Rented = false;
        }

        /* Other methods */

        public string GetString()
        {
            string TypeName = (Type.ToString() == "Book") ? "Książka" : (Type.ToString() == "CD") ? "Płyta CD" : "Czasopisma";
            string ModificationString = (ModificationDate == DateTime.MinValue) ? "" : $"\n   Modyfikacja:  {StringUtils.LeadingZeroAddition(ModificationDate.Day)}.{StringUtils.LeadingZeroAddition(ModificationDate.Month)}.{ModificationDate.Year}";
            return $"\n{TypeName} - \"{Title}\":\n   Numer karty: {StringUtils.FillSpace(CatalogId, 11)}\n   Dodano:       {StringUtils.LeadingZeroAddition(AdditionDate.Day)}.{StringUtils.LeadingZeroAddition(AdditionDate.Month)}.{AdditionDate.Year}{ModificationString}\n   Wypożyczona:         {StringUtils.BooleanConvert(Rented)}\n   Zarezerwowana:       {StringUtils.BooleanConvert(Reserved)}";
        }

    }
}
