using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpNoise;

namespace AudioPlaygroundConsole
{
    
    class BulletSoundEffect : AudioArrayCreator
    {
        public double Falloff = 0.95f;
        protected override IList<double> GetAudio()
        {
            List<double> res = new List<double>();
            double tot = 1f;
            for (int i = 0; i < 82000; i += 1) {
                double noiseResult = (double)SharpNoise.NoiseGenerator.ValueCoherentNoise3D(0.2f * i, 0, 0, 5);
                noiseResult *= 8;
                noiseResult = (double)Math.Round(noiseResult);
                noiseResult /= 8f;
                res.Add((double)noiseResult * tot);
                tot *= Falloff;
            }
            return res;
        }
    }
}
