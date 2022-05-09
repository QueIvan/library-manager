using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryConsoleManager
{
    [DisplayName("Książka popularnonaukowa")]
    internal class PopularBook : Book
    {
        private string TargetGenre;

        public PopularBook([DisplayName("tytuł")] string Title, [DisplayName("kategorie")] string TargetGenre, [DisplayName("imie")] string FirstName, [DisplayName("nazwisko")] string LastName, [DisplayName("numer katalogowy")] uint CatalogId, [DisplayName("numer ISBN")] int ISBN, [DisplayName("rok wydania")] int Year) : base(Title, FirstName, LastName, CatalogId, ISBN, Year)
        {
            this.TargetGenre = TargetGenre;
        }

    }
}
