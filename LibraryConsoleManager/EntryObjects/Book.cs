using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryConsoleManager
{
    internal class Book : LibraryEntry
    {
        private Author Author;
        private int PublicationYear;
        private int ISBN;

        public Book(string Title, string FirstName, string LastName, uint CatalogId, int ISBN, int Year) : base(Title, CatalogId, EntryType.Book)
        {
            this.Author = new Author(FirstName, LastName);
            this.ISBN = ISBN;
            this.PublicationYear = Year;
        }

    }
}
