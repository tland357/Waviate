using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlaygroundConsole
{
    class SqueezeGrinder : AudioArrayCreator
    {
        public double length;
        public Func<double, double> frequencyShape;
        public Func<double, double> volumeShape;
        public Func<double, double> minimumDroneShape;
        public double speedup;
        protected override IList<double> GetAudio()
        {
            var outers = new ArbitraryWaveCreator()
            {
                ValueLookup = (a, t) =>
                {
                    double mt = (minimumDroneShape != null ? minimumDroneShape(t) : 1);
                    double ft = (frequencyShape != null ? frequencyShape(t + mt) : 50);
                    double vt = (volumeShape != null ? volumeShape(t) : 1);
                    return Math.Sin(Math.Round(speedup*ft)) * vt;
                },
                FrequencyLookup = a =>
                {

                    return 1;
                },
                Seconds = length
            };
            return outers.Audio();
        }
    }
}
