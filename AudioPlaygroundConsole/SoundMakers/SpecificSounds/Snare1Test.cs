using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpNoise.Models;

namespace AudioPlaygroundConsole
{
    class Snare1Test : WaveCreator
    {
        public int Seed;
        public double ExponentFalloff = 0.8f;
        public double StartingVolume = 0.7f;
        protected override IList<double> GetAudio()
        {
            int TotalFrames = (int)Math.Round(AudioFileWriter.numsamples * Seconds);
            double[] result = new double[TotalFrames];
            Random r = new Random(Seed);
            double tot = StartingVolume;
            for (int i = 0; i < TotalFrames; i += 1) {
                double x = (double)((r.NextDouble() - .5) * 2);
                result[i] = x * tot;
                tot *= ExponentFalloff;
            }
            return result;
        }
    }

    class Snare2Test : WaveCreator
    {
        public int Seed;
        public double ExponentFalloff = 0.8f;
        protected override IList<double> GetAudio()
        {
            int TotalFrames = (int)Math.Round(AudioFileWriter.numsamples * Seconds);
            double[] result = new double[TotalFrames];
            Random r = new Random(Seed);
            double tot = 48f;
            SharpNoise.Modules.RidgedMulti multi = new SharpNoise.Modules.RidgedMulti();
            multi.Frequency = 1;
            for (int i = 0; i < TotalFrames; i += 1)
            {
                double x = IkaStaticMath.Clamp((double)multi.GetValue(Math.Pow(i,0.2), 0, 0) * 1f, -1 ,1);
                result[i] = x * tot;
                tot *= ExponentFalloff;
            }
            return result;
        }
    }
}
