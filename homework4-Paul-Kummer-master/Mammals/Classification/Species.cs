using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mammals.Classification
{
    public class Species : IClassificationItem
    {
        public string Name { get; set; }
        public string CommonName { get; set; }
        public string Author { get; set; }
        public string Date { get; set; }
        public IEnumerable<IClassificationItem> Children => new List<Species>();
        public override string ToString()
        {
            return this.Name;
        }
    }
}
