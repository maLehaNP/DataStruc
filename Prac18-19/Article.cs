using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prac18_19
{
    [Serializable]
    class Article : Publication
    {
        public string Journal { get; set; }
        public int Number { get; set; }
        public int Year { get; set; }
        public Article(string name, string author, string journal, int number, int year) : base(name, author)
        {
            this.Journal = journal;
            this.Number = number;
            this.Year = year;
        }
        public override string ToString()
        {
            return $"Статья {Author} {Name} // {Journal}. - {Year}. - № {Number}.";
        }
    }
}
