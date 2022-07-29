using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlaygroundConsole
{
    class Reverb : Filter
    {
        public double ReverbFrameFalloff = .95f;
        public override void Alter(ref IList<double> Data)
        {
            int AddedFrames = (int)Math.Ceiling(Math.Log(.05) / Math.Log(Math.Abs(ReverbFrameFalloff)));
            double[] temp = new double[Data.Count + AddedFrames];
            for (int i = 0; i < Data.Count; i += 1)
            {
                double falloff = 1.0f;
                if (ReverbFrameFalloff > 0)
                {
                    for (int j = 0; j < AddedFrames; j += 1)
                    {
                        temp[i + j] += Data[i] * falloff;
                        falloff *= ReverbFrameFalloff;
                    }
                } else
                {
                    
                    for (int j = 0; j < AddedFrames; j += 1)
                    {
                        temp[i + AddedFrames - 1 - j] += Data[i] * falloff;
                        falloff *= ReverbFrameFalloff;
                    }
                }
                
            }
            Data = temp;
        }
    }
}
