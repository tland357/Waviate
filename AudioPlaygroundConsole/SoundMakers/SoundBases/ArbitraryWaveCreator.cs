using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlaygroundConsole
{
    class ArbitraryWaveCreator : WaveCreator
    {
        public Func<double, double, double> ValueLookup = (x, t) => 0;
        public Func<double, double> FrequencyLookup = null; //GetFrequencyOverFullLengthOfAudio
        protected override IList<double> GetAudio()
        {
            if (ValueLookup != null)
            {
                double SamplesPerSecond = AudioFileWriter.numsamples;
                uint totalSamples = (uint)Math.Round(SamplesPerSecond * Seconds);
                double[] result = new double[totalSamples];
                double track = 0f;
                for (int i = 0; i < totalSamples; i += 1)
                {
                    double t = (double)i / (double)totalSamples;
                    double WavesPerSample = (FrequencyLookup == null ? (double)Frequency : FrequencyLookup(t) * 1.0f / SamplesPerSecond);
                    double SamplesPerWave = 1.0f / WavesPerSample;

                    result[i] = IkaStaticMath.Clamp(ValueLookup(track,t), -1f, 1f);
                    track += WavesPerSample;
                    track %= 1f;
                }
                return result;
            }
            return new double[AudioFileWriter.numsamples];
        }
    }
}
