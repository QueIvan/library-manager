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

        public CD(string Title, string FirstName, string LastName, uint CatalogId, int ISBN, DateTime Date) : base(Title, CatalogId, EntryType.CD)
        {
            this.Director = new Author(FirstName, LastName);
            this.ReleaseDate = Date;
            this.ISBN = ISBN;
        }

    }
}
