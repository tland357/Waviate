using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Waviate
{
    public partial class WaviateSplashScreen : Form
    {
        public bool ShouldOpen;
        public WaviateSplashScreen()
        {
            InitializeComponent();
        }
        public static void ColorToHSV(Color color, out double hue, out double saturation, out double value)
        {
            int max = Math.Max(color.R, Math.Max(color.G, color.B));
            int min = Math.Min(color.R, Math.Min(color.G, color.B));

            hue = color.GetHue();
            saturation = (max == 0) ? 0 : 1d - (1d * min / max);
            value = max / 255d;
        }

        public static Color ColorFromHSV(double hue, double saturation, double value)
        {
            int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
            double f = hue / 60 - Math.Floor(hue / 60);

            value = value * 255;
            int v = Convert.ToInt32(value);
            int p = Convert.ToInt32(value * (1 - saturation));
            int q = Convert.ToInt32(value * (1 - f * saturation));
            int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));

            if (hi == 0)
                return Color.FromArgb(255, v, t, p);
            else if (hi == 1)
                return Color.FromArgb(255, q, v, p);
            else if (hi == 2)
                return Color.FromArgb(255, p, v, t);
            else if (hi == 3)
                return Color.FromArgb(255, p, q, v);
            else if (hi == 4)
                return Color.FromArgb(255, t, p, v);
            else
                return Color.FromArgb(255, v, p, q);
        }
        Bitmap bp;
        private void HueAdjust(double amount, PictureBox p)
        {
            bp = p.Image as Bitmap;
            for (int i = 0; i < bp.Width; i += 1) { 
                for (int j = 0; j < bp.Height; j += 1)
                {
                    Color c = bp.GetPixel(i, j);
                    double hue, sat, val;
                    ColorToHSV(c, out hue, out sat, out val);
                    Color r = ColorFromHSV((hue + amount) % 360.0, sat, val);
                    bp.SetPixel(i, j, r);   
                }
            }
        }
        private void HueShiftImage() { 
            var im = pictureBox1.Image;
            Bitmap bm = new Bitmap(im);
            pictureBox1.Image = bm;
            pictureBox1.Update();
            HueAdjust(64, pictureBox1);
            pictureBox1.Update();
        }

        private void WaviateSplashScreen_Load(object sender, EventArgs e)
        {
            
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(4000);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        }

        private void pictureBox1_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WaviateApp app = new WaviateApp();
            app.ShowDialog();
        }
    }
}
