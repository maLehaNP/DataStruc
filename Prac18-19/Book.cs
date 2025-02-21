using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prac18_19
{
    [Serializable]
    class Book : Publication
    {
        public int Year { get; set; }
        public string Publisher { get; set; }
        public Book(string name, string author, int year, string publisher) : base(name, author)
        {
            this.Year = year;
            this.Publisher = publisher;
        }
        public override string ToString()
        {
            return $"Книга {Author} {Name}. - {Publisher}.: {Year}.";
        }
    }
}
