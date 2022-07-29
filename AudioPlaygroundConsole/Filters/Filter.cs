using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlaygroundConsole
{
    public abstract class Filter
    {
        abstract public void Alter(ref IList<double> Data);
    }
}
