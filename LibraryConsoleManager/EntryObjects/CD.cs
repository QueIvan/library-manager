using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryConsoleManager
{
    internal class CD : LibraryEntry
    {
        private Author Director;
        private DateTime ReleaseDate;
        private int ISBN;

        public CD([DisplayName("tytuł")] string Title, [DisplayName("imie")] string FirstName, [DisplayName("nazwisko")] string LastName, [DisplayName("numer katalogowy")] uint CatalogId, [DisplayName("numer ISBN")] int ISBN, [DisplayName("datę wydania")] DateTime Date) : base(Title, CatalogId, EntryType.CD)
        {
            this.Director = new Author(FirstName, LastName);
            this.ReleaseDate = Date;
            this.ISBN = ISBN;
        }

    }
}
