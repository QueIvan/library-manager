using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryConsoleManager
{
    internal class Magazine : LibraryEntry
    {
        private Author Author;
        private DateTime ReleaseDate;

        public Magazine(string Title, string CompanyName, uint CatalogId, DateTime Date) : base(Title, CatalogId, EntryType.CD)
        {
            this.Author = new Author(CompanyName);
            this.ReleaseDate = Date;
        }

    }
}
