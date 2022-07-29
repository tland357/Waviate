using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlaygroundConsole
{
	struct MusicNote
	{
		public MusicNote(double freq = 440)
		{
			frequency = freq;
		}
		
		public MusicNote GetInterval(double halfSteps)
		{
			const double s = 16f / 15f;
			return new MusicNote(frequency * (double)Math.Pow(s, halfSteps));
			
		}
		public double frequency { get; private set; }
		public static implicit operator double(MusicNote note)
		{
			return note.frequency;
		}
	}
}
