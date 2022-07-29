using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace AudioPlaygroundConsole
{
    class WavePlayer
    {
        static WaveOut waveOut;
        
        static public void PlayAudio(string URL)
        {
            SoundPlayer player = new SoundPlayer(URL);
            player.Play();
        }

        private static void WaveOut_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            Console.WriteLine("Stopped!");
        }
    }
}
