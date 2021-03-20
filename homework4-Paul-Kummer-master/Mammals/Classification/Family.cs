using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mammals.Classification
{
    public class Family : IClassificationItem
    {
        public string Name { get; set; }
        public List<Genus> Genera { get; set; }

        public IEnumerable<IClassificationItem> Children => Genera;

        public Family(string name)
        {
            this.Name = name;
            this.Genera = new List<Genus>();
        }
        public override string ToString()
        {
            return this.Name;
        }
    }
}
