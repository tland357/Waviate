using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlaygroundConsole
{

	abstract class GenericMixer : AudioArrayCreator
	{
		public IList<AudioArrayCreator> audioArrays;
	}
	class Appender : GenericMixer
	{
		protected override IList<double> GetAudio()
		{
			IList<double> result = new List<double>();
			foreach (var aud in audioArrays)
			{
				foreach (var o in aud.Audio())
				{
					result.Add(o);
				}
			}
			return result;
		}
	}

	class Mixer : GenericMixer
	{
		public Func<double, double, double> MixFunction;
		protected override IList<double> GetAudio()
		{
			List<double> result = new List<double>();
			foreach (var aud in audioArrays)
			{
				var audio = aud.Audio();
				
				for (int i = 0; i < result.Count; i += 1)
				{
					if (i < audio.Count)
					{
						result[i] = MixFunction(result[i], audio[i]);
					}
				}
				while (result.Count < audio.Count)
				{
					result.Add(audio[result.Count]);
				}
			}
			return result;
		}
	}
}
