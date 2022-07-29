using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Waviate.GUI;
using Waviate.Model.EvolutionAlgo;
using Waviate.Model;
using System.Runtime.InteropServices;



namespace Waviate
{
    public partial class WaviateApp : Form
    {
        public WaviateApp()
        {
            InitializeComponent();
            InitTheme();
            EvolutionAlgorithm.OnSpawnedPopulation += PlaceSoundControllers;
            
            EvolutionAlgorithm.OnClearedPopulation += ClearUI;
            MutatorBackgroundWorker.RunWorkerCompleted += NextGenControllers;
            EvolutionAlgorithm.OnUpdateProgress += (sender, args) =>
            {
                MutatorBackgroundWorker.ReportProgress(args.ProgressPercentage);
            };
                
        }
        public void InitTheme()
        {
            splitContainer1.Panel2.BackColor = WaviateColors.WavMidnight;
            splitContainer1.Panel1.BackColor = WaviateColors.WavDarkPurp;
            EvolveStart.BackColor = WaviateColors.WavPink;
            NumberOfSounds.SliderMin = 6;
            NumberOfSounds.SliderMax = 48;
            NumberOfSounds.SliderValue = 16;
            NumberOfSounds.NumberOfDecimalPlaces = 0;
            NumberOfSounds.Label = "Number of Sounds";
            Timesetter.SliderMin = 0.1;
            Timesetter.SliderMax = 5.0;
            Timesetter.SliderValue = 1.0;
            Timesetter.NumberOfDecimalPlaces = 1;
            Timesetter.Label = "Clip Length (seconds)";
            Seeder.SliderMin = 0;
            Seeder.SliderMax = 256;
            Seeder.Label = "Seed";
            Seeder.NumberOfDecimalPlaces = 0;
            Seeder.SliderValue = 128;
            MutatorSlider.SliderMin = 0.01;
            MutatorSlider.SliderMax = 1;
            MutatorSlider.NumberOfDecimalPlaces = 2;
            FullscreenOrNot_CheckedChanged(null, null);
            
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ShowScrollBar(IntPtr hWnd, int wBar, bool bShow);
        private enum ScrollBarDirection
        {
            SB_HORZ = 0,
            SB_VERT = 1,
            SB_CTL = 2,
            SB_BOTH = 3
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x85)
            {
                ShowScrollBar(splitContainer1.Panel2.Handle, (int)ScrollBarDirection.SB_BOTH, false);
            }
            base.WndProc(ref m);
        }
        const int RatioHeightToWidth = 8;
        public void PlaceSoundControllers(object Population, EventArgs e)
        {
            int width = splitContainer1.Panel2.Width;
            int height = 250;
            List<SoundCreature> populus = Population as List<SoundCreature>;
            if (populus != null)
            {
                for (int i = 0; i < populus.Count; i += 1)
                {
                    splitContainer1.Panel2.Controls.Add(new IndividualSoundController()
                    {
                        Width = width,
                        Height = height,
                        Location = new Point(0, i * height),
                        SoundCreator = populus[i],

                    });
                }
            }
            EvolveStart.Text = "Next Gen";
        }

        void NextGenControllers(object Population, EventArgs e)
        {
            int width = splitContainer1.Panel2.Width;
            int height = 250;
            splitContainer1.Panel2.Controls.Clear();
            List<SoundCreature> populus = EvolutionAlgorithm.CurrentPopulation;
            if (populus != null)
            {
                for (int i = 0; i < populus.Count; i += 1)
                {
                    splitContainer1.Panel2.Controls.Add(new IndividualSoundController()
                    {
                        Width = width,
                        Height = height,
                        Location = new Point(0, i * height),
                        SoundCreator = populus[i],

                    });
                }
            }
        }
        void ClearUI(object Population, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            EvolveStart.Text = "Start";
        }


        private void splitContainer1_Panel2_SizeChanged(object sender, EventArgs e)
        {
            int height = 250;
            int width = splitContainer1.Panel2.Width;
            int i = 0;
            foreach (IndividualSoundController cont in splitContainer1.Panel2.Controls)
            {
                cont.Width = width;
                cont.Height = height;
                cont.Location = new Point(0, height * i++);
            }
        }

        private void splitContainer1_Panel2_Scroll(object sender, ScrollEventArgs e)
        {
            foreach (IndividualSoundController cont in splitContainer1.Panel2.Controls)
            {
                cont.Repaint();
            }
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {
            foreach (IndividualSoundController cont in splitContainer1.Panel2.Controls)
            {
                cont.Repaint();
            }
        }

        private void splitContainer1_Resize(object sender, EventArgs e)
        {
            splitContainer1.SplitterDistance = 260;
            splitTopFromBottom.SplitterDistance = 50;
            EscapeApp.Location = new Point(splitTopFromBottom.Panel1.Right - EscapeApp.Width, 0);
            FullscreenOrNot.Location = new Point(splitTopFromBottom.Panel1.Right - EscapeApp.Width - FullscreenOrNot.Width, 0);
            UpdateFullscreenText();
            EvolveStart.Location = new Point((splitContainer1.SplitterDistance - EvolveStart.Width) / 2, splitContainer1.Panel1.Height - EvolveStart.Height - 5);
            StartOver.Location = new Point((splitContainer1.SplitterDistance - StartOver.Width) / 2, splitContainer1.Panel1.Height - EvolveStart.Height - StartOver.Height - 10);
            NumberOfSounds.Location = new Point((splitContainer1.SplitterDistance - NumberOfSounds.Width) / 2, splitContainer1.Panel1.Height - EvolveStart.Height - StartOver.Height - NumberOfSounds.Height - 15);
            Timesetter.Location = new Point((splitContainer1.SplitterDistance - Timesetter.Width) / 2, splitContainer1.Panel1.Height - EvolveStart.Height - StartOver.Height - NumberOfSounds.Height - Timesetter.Height - 20);
            Seeder.Location = new Point((splitContainer1.SplitterDistance - Seeder.Width) / 2, splitContainer1.Panel1.Height - EvolveStart.Height - StartOver.Height - NumberOfSounds.Height - Timesetter.Height - Seeder.Height - 25);
            MutatorSlider.Location = new Point((splitContainer1.SplitterDistance - MutatorSlider.Width) / 2, splitContainer1.Panel1.Height - EvolveStart.Height - StartOver.Height - NumberOfSounds.Height - Timesetter.Height - Seeder.Height - MutatorSlider.Height - 30);
        }

        private void EvolveStart_Click(object sender, EventArgs e)
        {
            (sender as CheckBox).Checked = false;
            
            if (!EvolutionAlgorithm.Started)
            {
                EvolutionAlgorithm.Start((int)NumberOfSounds.SliderValue, (int)Seeder.SliderValue);
            } else
            {
                
                MutatorBackgroundWorker.RunWorkerAsync();
                splitContainer1.Panel2.Controls.Clear();
            }
            
        }

        private void EscapeApp_Click(object sender, EventArgs e)
        {
            (sender as CheckBox).Checked = false;
            Application.Exit();
        }

        private void FullscreenOrNot_CheckedChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                FullscreenOrNot.Text = "FULLSCREEN";
                this.WindowState = FormWindowState.Normal;
            } else { 
                FullscreenOrNot.Text = "WINDOWED";
                this.WindowState = FormWindowState.Maximized;
            }
        }

        void UpdateFullscreenText()
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                FullscreenOrNot.Text = "WINDOWED";
            }
            else
            {
                FullscreenOrNot.Text = "FULLSCREEN";
            }
        }

        bool dragging = false;
        Point dragCursorPoint;
        Point dragFormPoint;

        private void TopOfScreen_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }
        private void TopOfScreen_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (dragging)
            {
                if (WindowState == FormWindowState.Maximized)
                {
                    WindowState = FormWindowState.Normal;
                }
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void TopOfScreen_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dragging = false;
            Console.WriteLine(Cursor.Position);
            if (Cursor.Position.Y == 0)
            {
                WindowState = FormWindowState.Maximized;
            }
        }
        bool barDrag;
        int NumSongs;
        double SongRatio;
        const int MinSongs = 6, MaxSongs = 48;
        private void NumSongsDragMouseDown(object sender, MouseEventArgs e)
        {
            barDrag = true;
            NumSongsDragMouseMove(sender, e);
        }

        private void NumSongsDragMouseMove(object sender, MouseEventArgs e)
        {
            var bar = sender as Control;
            if (bar != null && barDrag)
            {
                double ratio = IkaStaticMath.Clamp((double)e.Location.X / bar.Width,0.0,1.0);
                Console.WriteLine(ratio);
                SongRatio = ratio;
                NumSongs = (int)Math.Round(ratio * (MaxSongs - MinSongs) + MinSongs);
                bar.Text = NumSongs.ToString();
                NumberOfSounds.Invalidate();
            }
        }

        private void NumberOfSounds_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(WaviateColors.WavPink), 0, 0, (int)(e.ClipRectangle.Width * SongRatio), e.ClipRectangle.Height);
            e.Graphics.FillRectangle(new SolidBrush(WaviateColors.WavPurple), (int)(e.ClipRectangle.Width * SongRatio), 0, (int)(e.ClipRectangle.Width * (1 - SongRatio)), e.ClipRectangle.Height);
        }

        private void NumSongsDragMouseUp(object sender, MouseEventArgs e)
        {
            barDrag = false;
        }





        bool timeDrag;
        double TimeSet;
        double TimeRatio;
        const double MinTime = .1, MaxTime = 5.0;
        private void TimeDragMouseDown(object sender, MouseEventArgs e)
        {
            timeDrag = true;
            TimeDragMouseMove(sender, e);
        }

        private void TimeDragMouseMove(object sender, MouseEventArgs e)
        {
            var bar = sender as Control;
            if (bar != null && timeDrag)
            {
                double ratio = IkaStaticMath.Clamp((double)e.Location.X / bar.Width, 0.0, 1.0);

                TimeRatio = ratio;
                Console.WriteLine(e.Location);
                TimeSet = Math.Round((ratio * (MaxTime - MinTime) + MinTime) * 10) / 10.0;
                bar.Text = "" + TimeSet.ToString();
                if (bar.Text.Length < 2)
                {
                    bar.Text = bar.Text + ".0";
                }
                Timesetter.Invalidate();
            }
        }

        private void EvolveStart_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void StartOver_Click(object sender, EventArgs e)
        {
            EvolutionAlgorithm.Reset();
        }

        private void SetTimeLength(object sender, AudioPlaygroundConsole.Waviate.GUI.Slider.SliderEventArgs e)
        {
            EvolutionAlgorithm.TimeLength = e.newValue;
        }

        private void MutatorBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int i = 0;
            List<int> survivingIndices = new List<int>();
            foreach (Control controller in splitContainer1.Panel2.Controls)
            {
                var cont = controller as IndividualSoundController;
                if (cont != null && cont.KillSave.Checked)
                {
                    survivingIndices.Add(i);
                }
                i += 1;
            }
            EvolutionAlgorithm.NextGeneration(survivingIndices, (int)NumberOfSounds.SliderValue, MutatorSlider.SliderValue);
        }

        private void MutatorBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //TODO make progress bar of some kind
            progressBar1.Value = e.ProgressPercentage;
        }

        private void MutatorSlider_SliderValueChanged(object sender, AudioPlaygroundConsole.Waviate.GUI.Slider.SliderEventArgs e)
        {

        }

        private void TimeSet_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(WaviateColors.WavPink), 0, 0, (int)(e.ClipRectangle.Width * TimeRatio), e.ClipRectangle.Height);
            e.Graphics.FillRectangle(new SolidBrush(WaviateColors.WavPurple), (int)(e.ClipRectangle.Width * TimeRatio), 0, (int)(e.ClipRectangle.Width * (1 - SongRatio)), e.ClipRectangle.Height);
        }

        private void TimeDragMouseUp(object sender, MouseEventArgs e)
        {
            timeDrag = false;
        }
    }
}

