using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mammals.Classification
{
    public interface IClassificationItem
    {
        string Name { get; }
        IEnumerable<IClassificationItem> Children { get;  }
    }
}
