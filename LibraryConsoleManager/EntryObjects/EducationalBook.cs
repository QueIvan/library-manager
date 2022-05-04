using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryConsoleManager
{
    internal class EducationalBook : Book
    {
        private string Field;
        private string Difficulty;

        public EducationalBook(string Field, string Difficulty, string Title, string FirstName, string LastName, uint CatalogId, int ISBN, int Year) : base (Title, FirstName, LastName, CatalogId, ISBN, Year)
        {
            this.Field = Field;
            this.Difficulty = Difficulty;
        }

    }
}
