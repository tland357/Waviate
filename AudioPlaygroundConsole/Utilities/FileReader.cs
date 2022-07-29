using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    class FileReader : AudioPlaygroundConsole.AudioArrayCreator
    {
        public string URL;
        protected override IList<double> GetAudio()
        {
            WaveFormat wavform = new WaveFormat(AudioFileWriter.numsamples, AudioFileWriter.numchannels);
            using (FileStream stream = new FileStream(URL, FileMode.Open))
            {
                WaveFileReader reader = new WaveFileReader(stream);
                List<double> samples = new List<double>();
                while (reader.Position < reader.Length)
                {
                    samples.AddRange(reader.ReadNextSampleFrame().Select(x => (double)x).ToList());
                }
                return samples;
            }
        }
    }

