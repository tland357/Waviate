using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Waviate.GUI
{ 
/// <summary>
/// Control for viewing waveforms
/// </summary>
    public class WaveViewer : System.Windows.Forms.UserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;
        IList<double> Data;
        static double vol;
        static double[] emptyarray = new double[] { 0 };
        public void DisplayData(AudioPlaygroundConsole.AudioArrayCreator soundData, double volume)
        {
            if (soundData == null)
            {
                Data = emptyarray;
            } else
            {
                Data = soundData.Audio();
            }
            vol = volume;
        }
        /// <summary>
        /// Creates a new WaveViewer control
        /// </summary>
        public WaveViewer()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();
            this.DoubleBuffered = true;
            BackColor = Color.Black;
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        static Color LerpColor(Color x, Color y, double t)
        {
            if (t > 1) t = 1;
            if (t < 0) t = 0;
            if (double.IsNaN(t)) t = 0.5;
            int r = (int)(x.R * t + y.R * (1-t));
            int g = (int)(x.G * t + y.G * (1 - t));
            int b = (int)(x.B * t + y.B * (1 - t));
            return Color.FromArgb(r, g, b);
        }
        /// <summary>
        /// <see cref="Control.OnPaint"/>
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            if (Data != null && this.Height >= e.ClipRectangle.Height)
            {
                var aud = Data;
                int length = aud.Count;

                float middleY = (e.ClipRectangle.Top + e.ClipRectangle.Bottom) / 2.0f;
                double DistY = e.ClipRectangle.Height / 2;
                for (float x = e.ClipRectangle.X; x < e.ClipRectangle.Right; x += 1)
                {
                    float xAcross = (x - e.ClipRectangle.X) / e.ClipRectangle.Width;
                    int sample = (int)Math.Floor(xAcross * length);
                    double audioAtSample = aud[sample];
                    Color drawColor = LerpColor(WaviateColors.WavPink, WaviateColors.WavDarkPurp, Math.Abs(audioAtSample));

                        e.Graphics.DrawLine(new Pen(drawColor, 1), x, middleY, x, (float)(DistY * audioAtSample / vol) + middleY);

                    
                }
            }

            base.OnPaint(e);
        }



        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // WaveViewer
            // 
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "WaveViewer";
            this.Size = new System.Drawing.Size(499, 150);
            this.ResumeLayout(false);

        }

        #endregion
    }
}