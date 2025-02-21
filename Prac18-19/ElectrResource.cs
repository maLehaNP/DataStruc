using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prac18_19
{
    [Serializable]
    class ElectrResource: Publication
    {
        public string Link { get; set; }
        public string Annotation { get; set; }
        public ElectrResource(string name, string author, string link, string annotation) : base(name, author)
        {
            this.Link = link;
            this.Annotation = annotation;
        }
        public override string ToString()
        {
            return $"{Author} {Name} [Электронный ресурс]. – URL: {Link} ({Annotation}).";
        }
    }
}
