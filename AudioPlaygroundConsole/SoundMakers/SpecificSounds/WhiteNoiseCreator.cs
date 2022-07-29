using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlaygroundConsole
{
    
    class WhiteNoiseCreator<WaveType> : AudioArrayCreator where WaveType : WaveCreator, new()
    {
        public double LowFrequency = 220;
        public double HighFrequency = 880;
        public double Seconds;
        public double Step;
        public bool MultiplicativeStep;

        

        protected override IList<double> GetAudio()
        {
            double[] result = null;
            int total = 0;
            for (double i = LowFrequency; i < HighFrequency; total += 1)
            {
                var w = new WaveType() { Frequency = i, Seconds = Seconds };
                if (result == null) {
                    result = w.Audio().ToArray();
                } else
                {
                    double[] add = w.Audio().ToArray();
                    Parallel.For(0, result.Length, j =>
                    {
                        result[j] += add[j];
                    });
                }
                if (MultiplicativeStep)
                {
                    i *= Step;
                } else
                {
                    i += Step;
                }
            }
            Parallel.For(0, result.Length, i =>
            {
                result[i] /= total;
            });
            return result;
        }
    }

    class WhiteNoiseCreator2<WaveType> : AudioArrayCreator where WaveType : WaveCreator, new()
    {
        public double LowFrequency = 220;
        public double HighFrequency = 880;
        public double Seconds;
        public double Step;
        public bool MultiplicativeStep;



        protected override IList<double> GetAudio()
        {
            double[] result = null;
            int total = 0;
            Random r = new Random();
            for (double i = LowFrequency; i < HighFrequency; total += 1)
            {
                var w = new WaveType() { Frequency = i, Seconds = Seconds };
                if (result == null)
                {
                    result = w.Audio().ToArray();
                }
                else
                {
                    double[] add = w.Audio().ToArray();
                    Parallel.For(0, result.Length, j =>
                    {
                        result[j] += add[j];
                    });
                }
                i += (double)r.NextDouble() * 8f + 2.3f;
            }
            Parallel.For(0, result.Length, i =>
            {
                result[i] /= total;
            });
            return result;
        }
    }
}
