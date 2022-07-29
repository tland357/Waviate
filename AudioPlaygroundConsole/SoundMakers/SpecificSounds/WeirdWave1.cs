using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlaygroundConsole
{
    class WeirdWave1 : ArbitraryWaveCreator
    {
        public WeirdWave1()
        {
            ValueLookup = (x, t) =>
            {
                return ((double)Math.Cos(Math.PI * 5 *x) + (2f * x - 1)) / 2f;
            };
        }
    }
}
