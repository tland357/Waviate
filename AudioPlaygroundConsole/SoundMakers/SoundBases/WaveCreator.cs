using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlaygroundConsole
{
    abstract class WaveCreator : AudioArrayCreator
    {
        public double Seconds;
        public double Frequency;
    }
}
