using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryConsoleManager
{
    [DisplayName("Książka edukacyjna")]
    internal class EducationalBook : Book
    {
        private string Field;
        private string Difficulty;

        public EducationalBook([DisplayName("dziedzine")] string Field, [DisplayName("poziom zaawansowania")] string Difficulty, [DisplayName("tytuł")] string Title, [DisplayName("imie")] string FirstName, [DisplayName("nazwisko")] string LastName, [DisplayName("numer katalogowy")] uint CatalogId, [DisplayName("numer ISBN")] int ISBN, [DisplayName("rok wydania")] int Year) : base (Title, FirstName, LastName, CatalogId, ISBN, Year)
        {
            this.Field = Field;
            this.Difficulty = Difficulty;
        }

    }
}
