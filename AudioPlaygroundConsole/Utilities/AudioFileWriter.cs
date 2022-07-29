using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using NAudio.Wave;
using NAudio;
using System.Linq;


    class AudioFileWriter
    {
        public static int numsamples {
            get => 44100 * numchannels;
        }
        public static double numseconds(int numSamples)
        {
            return (double)numSamples / 44100f;
        }
        public static ushort numchannels = 1;
        public static ushort samplelength = 4; // in bytes
        public static uint samplerate = 22050;
        public static Func<int, bool, double> ChannelFilter; // (sampleIndex, RightChannel) -> value between 0 and 1 
        public static bool parallel;
        public static IList<double> Weave(IList<double> r)
        {
            Parallel.For(0, r.Count, i =>
            {
                //r[i] *= i % 2 == 0 ? 0 : 1;
            });
            return r;
        }
        public static void Create(AudioPlaygroundConsole.AudioArrayCreator source, string fileURL)
        {
            double[] audioData = source.Audio().ToArray();
            WaveFormat wavform = new WaveFormat(numsamples / numchannels, numchannels);
            if (numchannels == 2)
            {
                if (ChannelFilter != null)
                {
                    if (parallel)
                    {
                        Parallel.For(0, audioData.Length, i =>
                        {
                            audioData[2 * i] *= ChannelFilter(i, false);
                            audioData[2 * i + 1] *= ChannelFilter(i, true);
                        });
                    }
                    else
                    {
                        for (int i = 0; i < audioData.Length; i += 1)
                        {
                            bool right = i % 2 == 0;
                            audioData[i] *= ChannelFilter(i, right);
                        }
                    }
                }
            } 
            using (WaveFileWriter writer = new WaveFileWriter(fileURL, wavform))
            {
                writer.WriteSamples(audioData.Select(x => (float)x).ToArray(), 0, audioData.Length);
            }
        }
    }
