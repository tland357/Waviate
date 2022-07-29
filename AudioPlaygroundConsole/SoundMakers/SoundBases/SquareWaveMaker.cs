using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlaygroundConsole
{
    class SquareWaveMaker : WaveCreator
    {
        protected override IList<double> GetAudio()
        {
            double SamplesPerSecond = AudioFileWriter.numsamples;
            uint totalSamples = (uint)Math.Round(SamplesPerSecond * Seconds);
            double WavesPerSample = Frequency/*WavesPerSecond*/ * (1.0 / SamplesPerSecond);
            double SamplesPerWave = 1.0 / WavesPerSample;
            double[] result = new double[totalSamples];
            Parallel.For(0, totalSamples, i => {
                result[i] = (double)i % SamplesPerWave > SamplesPerWave / 2.0 ? 1.0f : -1.0f;
            });
            return result;
        }
    }

    class SawWaveMaker : WaveCreator
    {
        protected override IList<double> GetAudio()
        {
            double SamplesPerSecond = AudioFileWriter.numsamples;
            uint totalSamples = (uint)Math.Round(SamplesPerSecond * Seconds);
            double WavesPerSample = (double)Frequency/*WavesPerSecond*/ * (1.0f / SamplesPerSecond);
            double SamplesPerWave = 1.0f / WavesPerSample;
            double[] result = new double[totalSamples];
            Parallel.For(0, totalSamples, i => {
                result[i] = (i % SamplesPerWave) / SamplesPerWave * 2 - 1;
            });
            return result;
        }
    }
}
