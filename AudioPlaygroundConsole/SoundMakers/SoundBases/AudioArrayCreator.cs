using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;
namespace AudioPlaygroundConsole
{
    public abstract class AudioArrayCreator
    {
        public int Length
        {
            get => Audio().Count;
        }
        bool AudioCalculated = false;
        double[] calculatedAudio;
        public void MakeDirty()
        {
            calculatedAudio = null;
            AudioCalculated = false;
            OnDirtied(this, null);
        }
        public event EventHandler OnDirtied;
        public IList<double> Audio()
        {
            IList<double> Data;
            if (AudioCalculated)
            {
                Data = calculatedAudio;
            } else
            {
                Data = GetAudio();
                calculatedAudio = Data.ToArray();
                AudioCalculated = true;
            }
            
            if (AudioFileWriter.numchannels == 2)
            {
                Data = AudioFileWriter.Weave(Data);
            }
            if (Filters != null)
            {
                foreach (var filter in Filters)
                {
                    filter.Alter(ref Data);
                }
            }
            return Data;
        }
        protected abstract IList<double> GetAudio();

        public IEnumerable<Filter> Filters;

    }
}
