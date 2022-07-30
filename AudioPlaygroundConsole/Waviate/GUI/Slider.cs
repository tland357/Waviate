using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AudioPlaygroundConsole.Waviate.GUI
{
    public partial class Slider : UserControl
    {
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), DefaultValue(0), Category("Data"),]
        public double SliderMin
        {
            get;
            set;
        }
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), DefaultValue(1), Category("Data"),]
        public double SliderMax
        {
            get;
            set;
        }
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), DefaultValue("None"), Category("Data"),]
        public string Label
        {
            get => label1.Text;
            set => label1.Text = value;
        }
        double rat;
        public double Ratio { get
            {
                return rat;
            }
            set
            {
                rat = value;
                if (rat > 1.0) rat = 1.0;
                if (rat < 0.0) rat = 0.0;
                if (SliderValueChanged != null)
                {
                    SliderValueChanged(this, new SliderEventArgs(Ratio, SliderValue));
                }
                label2.Text = CorrectedDecimalString(SliderValue);
            }
        }
        public class SliderEventArgs : EventArgs
        {
            public SliderEventArgs(double ratio, double val)
            {
                newValue = val;
                newRatio = ratio;
            }
            public double newValue
            {
                get;
                private set;
            }
            public double newRatio
            {
                get;
                private set;
            }
        }
        public delegate void SliderEvent(object sender, SliderEventArgs e);
        public double SliderValue
        {
            get
            {
                double val = SliderMin + rat * (SliderMax - SliderMin);
                if (NumberOfDecimalPlaces < 0) return val;
                else
                {
                    double tenPower = 1;
                    for (int i = 0; i < NumberOfDecimalPlaces; i += 1)
                    {
                        tenPower *= 10;
                    }
                    return Math.Round(val * tenPower) / tenPower;
                }
            }
            set
            {
                //if (value < SliderMin) value = SliderMin;
                //if (value > SliderMax) value = SliderMax;
                Ratio = (value - SliderMin) / (SliderMax - SliderMin);
            }
        }
        public event SliderEvent SliderValueChanged;
        public Slider()
        {
            InitializeComponent();
            Slider_Resize(this, null);
            
        }
        bool MouseDrag = false;
        private void label2_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDrag = true;
            label2_MouseMove(sender, e);
        }
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), DefaultValue(0), Category("Data"),]
        public int NumberOfDecimalPlaces
        {
            get;
            set;
        }
        int FindCharInString(string s, char c)
        {
            for (int i = 0; i < s.Length; i += 1)
            {
                if (s[i] == c) return i;
            }
            return -1;
        }
        string CorrectedDecimalString(double x)
        {
            string s = x.ToString();
            StringBuilder sb = new StringBuilder(s);
            if (NumberOfDecimalPlaces > 0)
            {
                int periodLocation = FindCharInString(s, '.');
                if (periodLocation != -1)
                {
                    int numberOfPlacesPresent = s.Length - 1 - periodLocation;
                    for (int i = 0; i < NumberOfDecimalPlaces - numberOfPlacesPresent; i += 1)
                    {
                        sb.Append('0');
                    }
                } else
                {
                    sb.Append('.');
                    for (int i = 0; i < NumberOfDecimalPlaces; i += 1)
                    {
                        sb.Append('0');
                    }
                }
            }
            return sb.ToString();
        }

        private void label2_MouseMove(object sender, MouseEventArgs e)
        {
            var bar = sender as Control;
            if (MouseDrag && bar != null && this.Enabled)
            {
                Ratio = (double)e.Location.X / bar.Width;
                label2.Text = SliderValue.ToString();
                panel1.Invalidate();
            }

        }

        private void label2_MouseUp(object sender, MouseEventArgs e)
        {
            MouseDrag = false;
        }

        private void panel1_paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(WaviateColors.WavPink), 0, 0, (int)(e.ClipRectangle.Width * Ratio), e.ClipRectangle.Height);
            e.Graphics.FillRectangle(new SolidBrush(WaviateColors.WavPurple), (int)(e.ClipRectangle.Width * Ratio), 0, (int)(e.ClipRectangle.Width * (1 - Ratio)), e.ClipRectangle.Height);
        }

        private void Slider_Resize(object sender, EventArgs e)
        {
            label2.Location = new Point((panel1.Width - label2.Width) / 2, panel1.Height - label2.Height);
        }

        private void Slider_EnabledChanged(object sender, EventArgs e)
        {
            label1.ForeColor = Enabled ? Color.White : Color.Black;
        }
    }
}
