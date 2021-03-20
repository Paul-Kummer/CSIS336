using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mammals.Classification
{
    public class Genus : IClassificationItem
    {
        public string Name { get; set; }
        public List<Species> Species { get; set; }

        public IEnumerable<IClassificationItem> Children => Species;

        public Genus(string name)
        {
            this.Name = name;
            this.Species = new List<Species>();
        }
        public override string ToString()
        {
            return this.Name;
        }
    }
}
