using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Threading.Tasks;
using MathFloat;
using Waviate;

namespace AudioPlaygroundConsole
{
    class Program
    {
        static double ChannelFilterer(int i, bool right)
        {
            return 1;
            double Dist = 1.45f;
            double FrequencySpin = 44100f / 5.53f;
            if (right)
            {
                return ((double)Math.Cos(i / FrequencySpin) + Dist) / (Dist + 1);
            } else
            {
                return (Dist - (double)Math.Cos(i / FrequencySpin)) / (Dist + 1);
            }
        }

        static void LaunchWaviate()
        {
            //Waviate.WaviateSplashScreen splash = new Waviate.WaviateSplashScreen();
            //splash.ShowDialog();
            WaviateApp app = new WaviateApp();
            Application.Run(app);
        }
        //static void Main(string[] args)
        //{
        //    
        //    AudioFileWriter.numchannels = 2;
        //    string fileOut = "D:\\Downloads\\audioArrayTest.wav";
        //    string fileIn = @"D:\Downloads\Dukto\Gamemaster Audio - ProSound Mini Pack\Gamemaster Audio - ProSound Mini Pack\Gamemaster Audio - ProSound Mini Pack\Gamemaster Audio - ProSound Mini Pack\Voice\troll_monster_hurt_pain_02.wav";
        //    Filter[] filters = new Filter[] {  };
        //    var reader = new FileReader() { URL = fileIn };
        //    var audioIn = reader.Audio();
        //    var turb = new SharpNoise.Modules.RidgedMulti();
        //    Random r = new Random();
        //    int numberOfPaths = 2;
        //    int derivativeDepth = 0;
        //    double skew;
        //    ArbitraryWaveCreator creator = null;
        //    List<AudioArrayCreator> creatorList = new List<AudioArrayCreator>();
        //    for (int i = 0; i < numberOfPaths + derivativeDepth; i++)
        //    {
        //        double x = 0, y = 0;
        //        double dx = 0, dy = 0;
        //
        //        turb.GetValue(x, y, 0);
        //        double negate = r.Next() % 2 == 0 ? 1 : -1; // 1;
        //        double ddx = negate * (double)r.Next() / (double)int.MaxValue;
        //        double ddy = negate * (double)r.Next() / (double)int.MaxValue;
        //        dx += ddx;
        //        dy += ddy;
        //        x += dx;
        //        y += dy;
        //        double z = turb.GetValue(x, y, 0);
        //        if (creator == null)
        //        {
        //            var outer = new ArbitraryWaveCreator()
        //            {
        //                ValueLookup = (a, t) =>
        //                {
        //
        //                    return (double)Math.Sin(2 * Math.PI * t + z);
        //                },
        //                FrequencyLookup = a =>
        //                {
        //
        //                    return 120;// + 8 * i * i; //20000 * (double)Math.Pow(i, 24);
        //            },
        //                Seconds = 5
        //            };
        //            creator = outer;
        //            creatorList.Add(creator);
        //        }
        //        
        //    }
        //    Combiner comb = new Combiner(creatorList);
        //
        //    var outers = new ArbitraryWaveCreator()
        //    {
        //        ValueLookup = (a, t) =>
        //        {
        //
        //            return (double)Math.Sin(2 * Math.PI * a);
        //        },
        //        FrequencyLookup = a =>
        //        {
        //
        //            return 120;// + 8 * i * i; //20000 * (double)Math.Pow(i, 24);
        //        },
        //        Seconds = 5
        //    };
        //    AudioFileWriter.Create(comb, fileOut);
        //    var audioOut = comb.Audio();
        //    AudioFileWriter.ChannelFilter = ChannelFilterer;
        //    //AudioFileWriter.Create(new BulletSoundEffect() { Falloff = 0.9998f }, fileOut);
        //    //AudioFileWriter.Create(new FileReader() { URL = fileIn, Filters = new Filter[] { } }, fileOut);
        //    WavePlayer.PlayAudio(fileOut);
        //    Console.ReadKey();
        //}
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Contains("Waviate") || true)
            {
                LaunchWaviate();
                return;
            }
            AudioFileWriter.numchannels = 2;
            string fileOut = "D:\\Downloads\\SqueezeGrind15.wav";
            string fileIn = @"D:\Downloads\Dukto\Gamemaster Audio - ProSound Mini Pack\Gamemaster Audio - ProSound Mini Pack\Gamemaster Audio - ProSound Mini Pack\Gamemaster Audio - ProSound Mini Pack\Voice\troll_monster_hurt_pain_02.wav";
            Filter[] filters = new Filter[] { };
            var reader = new FileReader() { URL = fileIn };
            var audioIn = reader.Audio();
            var turb = new SharpNoise.Modules.RidgedMulti();
            Random r = new Random();
            int numberOfPaths = 2;
            int derivativeDepth = 0;
            double skew;
            ArbitraryWaveCreator creator = null;
            List<AudioArrayCreator> creatorList = new List<AudioArrayCreator>();
            var SqueezeGrind = new SqueezeGrinder()
            {
                length = 20,
                frequencyShape = (x) => {
                    double g = Math.Sin(180 * x);
                    return 12 * (g * g * g * g) + 144;
                },
                speedup = .1,
                minimumDroneShape = (x) =>
                {
                    double b = .001;
                    double sin = Math.Sin(18 * Math.Sin(63.172 / (x * x)) * x);
                    return 1 - b * sin * sin;
                },
                volumeShape = (x) => .1
            };
            AudioFileWriter.Create(SqueezeGrind, fileOut);
            var audioOut = SqueezeGrind.Audio();
            AudioFileWriter.ChannelFilter = ChannelFilterer;
            //AudioFileWriter.Create(new BulletSoundEffect() { Falloff = 0.9998f }, fileOut);
            //AudioFileWriter.Create(new FileReader() { URL = fileIn, Filters = new Filter[] { } }, fileOut);
            WavePlayer.PlayAudio(fileOut);
            AudioVisualizer.DisplayChart(audioOut);
            Console.ReadKey();
        }
    }
}
