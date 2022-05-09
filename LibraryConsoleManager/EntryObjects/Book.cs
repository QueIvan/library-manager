using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryConsoleManager
{
    [DisplayName("Książka")]
    internal class Book : LibraryEntry
    {
        private Author Author;
        private int PublicationYear;
        private int ISBN;

        public Book()
        {

        }
        public Book([DisplayName("tytuł")]string Title, [DisplayName("imie")] string FirstName, [DisplayName("nazwisko")] string LastName, [DisplayName("numer katalogowy")] uint CatalogId, [DisplayName("numer ISBN")] int ISBN, [DisplayName("rok wydania")] int Year) : base(Title, CatalogId, EntryType.Book)
        {
            this.Author = new Author(FirstName, LastName);
            this.PublicationYear = Year;
            this.ISBN = ISBN;
        }

    }
}
