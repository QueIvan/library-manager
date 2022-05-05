using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryConsoleManager
{
    internal class Author
    {
        private string FirstName;
        private string LastName;
        private string CompanyName;

        public Author(string FirstName, string LastName, string CompanyName)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.CompanyName = CompanyName;
        }

        public Author(string FirstName, string LastName)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
        }

        public Author(string CompanyName)
        {
            this.CompanyName = CompanyName;
        }
    }
}
