using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlaygroundConsole
{
    class Combiner : AudioArrayCreator
    {
        AudioArrayCreator[] b;
        public Combiner(params AudioArrayCreator[] a)
        {
            
        }
        public Combiner(IList<AudioArrayCreator> a)
        {
            if (a.Count == 0)
            {
                throw new ArgumentException("Must include one audio array creator");
            }
            b = a.ToArray();
        }
        protected override IList<double> GetAudio()
        {
            if (b.Length == 0) return null;
            List<double> result = new List<double>();
            for (int i = 0; i < b.Length; i++)
            {
                double total = 0;
                for (int j = 0; j < b.Length; j++)
                {
                    total += b[j].Audio()[i] / b.Length;
                }
                result.Add(total);
            }
            return result;
        }
    }
}
