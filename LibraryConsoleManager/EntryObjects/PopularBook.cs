using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryConsoleManager
{
    internal class PopularBook : Book
    {
        private string Type;
        private string TargetGeneration;

        public PopularBook(string Type, string TargetGeneration, string Title, string FirstName, string LastName, uint CatalogId, int ISBN, int Year) : base(Title, FirstName, LastName, CatalogId, ISBN, Year)
        {
            this.Type = Type;
            this.TargetGeneration = TargetGeneration;
        }

    }
}
