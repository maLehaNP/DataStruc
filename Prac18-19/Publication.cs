using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prac18_19
{
    [Serializable]
    abstract public class Publication : IComparable<Publication>
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public Publication(string name,
                           string author)
        {
            this.Name = name;
            this.Author = author;
        }

        public int CompareTo(Publication other)
        {
            return this.Author.Split()[0].CompareTo(other.Author);
        }

        abstract public override string ToString();
        public bool IsAuthor(string surname)
        {
            if (Author.Split()[0].Equals(surname))
            {
                return true;
            }
            else return false;
        }
    }
}
