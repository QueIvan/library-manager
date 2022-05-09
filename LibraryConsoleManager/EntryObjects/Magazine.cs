using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryConsoleManager
{
    [DisplayName("Magazyn")]
    internal class Magazine : LibraryEntry
    {
        private Author Author;
        private DateTime ReleaseDate;

        public Magazine([DisplayName("tytuł")] string Title, [DisplayName("nazwę wydawcy")] string CompanyName, [DisplayName("numer katalogowy")] uint CatalogId, [DisplayName("rok wydania")] DateTime Date) : base(Title, CatalogId, EntryType.CD)
        {
            this.Author = new Author(CompanyName);
            this.ReleaseDate = Date;
        }

    }
}
