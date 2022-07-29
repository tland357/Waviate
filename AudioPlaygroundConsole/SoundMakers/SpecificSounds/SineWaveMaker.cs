using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlaygroundConsole
{
    class SineWaveMaker : WaveCreator
    {
        
        protected override IList<double> GetAudio()
        {
            double SamplesPerSecond = AudioFileWriter.numsamples;
            uint totalSamples = (uint)Math.Round(SamplesPerSecond * Seconds);
            double WavesPerSample = Frequency/*WavesPerSecond*/ * (1.0 / SamplesPerSecond);
            double[] result = new double[totalSamples];
            Parallel.For(0, totalSamples, i => {
                result[i] = (double)Math.Sin(i * WavesPerSample * Math.PI);
            });
            return result;
        }
    }
}
