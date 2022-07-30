using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
        Random pageRand = new Random();
        public WaviateApp()
        {
            InitializeComponent();
            InitTheme();
            EvolutionAlgorithm.OnSpawnedPopulation += PlaceSoundControllers;
            
            EvolutionAlgorithm.OnClearedPopulation += ClearUI;
            MutatorBackgroundWorker.RunWorkerCompleted += NextGenControllers;
            EvolutionAlgorithm.OnUpdateProgress += (sender, args) =>
            {
                addedCreature = sender as SoundCreature;
                MutatorBackgroundWorker.ReportProgress(args.ProgressPercentage);
            };

            RendererBackgroundWorker.RunWorkerAsync();
        }
        SoundCreature addedCreature;
        public void InitTheme()
        {
            splitContainer1.Panel2.BackColor = WaviateColors.WavMidnight;
            splitContainer1.Panel1.BackColor = WaviateColors.WavDarkPurp;
            EvolveStart.BackColor = WaviateColors.WavPink;
            NumberOfSounds.SliderMin = 3;
            
            Timesetter.SliderMin = 0.1;
            Timesetter.SliderMax = 5.0;
            Timesetter.SliderValue = 1.0;
            Timesetter.NumberOfDecimalPlaces = 1;
            Timesetter.Label = "Clip Length (seconds)";
            Seeder.SliderMin = 0;
            Seeder.SliderMax = 256;
            Seeder.Label = "Seed";
            Seeder.NumberOfDecimalPlaces = 0;
            Seeder.SliderValue = pageRand.Next(0, 256);
            MutatorSlider.SliderMin = 0.01;
            MutatorSlider.SliderMax = 1;
            MutatorSlider.NumberOfDecimalPlaces = 2;
            MutatorSlider.SliderValue = 0.05;
            FullscreenOrNot_CheckedChanged(null, null);
            CrossBreedActive.Checked = true;
            NewestGenCheck.Checked = true;
            MutateCheck.Checked = true;
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
            int width = splitContainer1.Panel2.Width - 30;
            int height = 300;
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

        public void NextGenControllers(object Population, EventArgs e)
        {
            int width = splitContainer1.Panel2.Width - 30;
            int height = 300;
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
            Seeder.Enabled = NumberOfSounds.Enabled = true;
            StartOver.Enabled = false;
            StartOver.BackColor = WaviateColors.WavDarkPurp;
        }


        private void splitContainer1_Panel2_SizeChanged(object sender, EventArgs e)
        {
            int height = 300;
            int width = splitContainer1.Panel2.Width - 30;
            int i = 0;
            foreach (IndividualSoundController cont in splitContainer1.Panel2.Controls)
            {
                cont.Width = width;
                cont.Height = height;
                cont.Location = new Point(0, height * i++);
            }
        }
        bool Repaint = true;
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
            splitContainer1.SplitterDistance = 300;
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
            MutateCheck.Location = new Point((splitContainer1.SplitterDistance - MutateCheck.Width) / 2, MutatorSlider.Top - MutateCheck.Height - 5);
            NewestGenCheck.Location = new Point((splitContainer1.SplitterDistance - NewestGenCheck.Width) / 2, MutateCheck.Top - NewestGenCheck.Height - 5);
            CrossBreedActive.Location = new Point((splitContainer1.SplitterDistance - CrossBreedActive.Width) / 2, NewestGenCheck.Top - CrossBreedActive.Height - 5);
            BirthRateSlider.Location = new Point((splitContainer1.SplitterDistance - BirthRateSlider.Width) / 2, CrossBreedActive.Top - BirthRateSlider.Height - 5);
        }

        private void EvolveStart_Click(object sender, EventArgs e)
        {
            (sender as CheckBox).Checked = false;
            
            if (!EvolutionAlgorithm.Started)
            {
                EvolutionAlgorithm.Start((int)NumberOfSounds.SliderValue, (int)Seeder.SliderValue);
                Seeder.Enabled = NumberOfSounds.Enabled = false;
                StartOver.Enabled = true;
                StartOver.BackColor = WaviateColors.WavPink;
            } else
            {
                
                MutatorBackgroundWorker.RunWorkerAsync();
            }
        }

        private void EscapeApp_Click(object sender, EventArgs e)
        {
            (sender as CheckBox).Checked = false;
            Close();
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
            List<int> killedIndices = new List<int>();
            foreach (Control controller in splitContainer1.Panel2.Controls)
            {
                var cont = controller as IndividualSoundController;
                if (cont != null && !cont.KillSave.Checked)
                {
                    killedIndices.Add(i);
                }
                i += 1;
            }
            EvolutionAlgorithm.NextGeneration(killedIndices, (int)NumberOfSounds.SliderValue, MutatorSlider.SliderValue);
        }

        private void MutatorBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //TODO make progress bar of some kind
            if (progressBar1.Value == 0 || progressBar1.Value == 100)
            {
                splitContainer1.Panel2.Controls.Clear();
            }
            int percent = e.ProgressPercentage;
            if (percent > 100) percent = 100;
            if (percent < 0) percent = 0;
            progressBar1.Value = percent;

            
            
            
        }

        private void MutatorSlider_SliderValueChanged(object sender, AudioPlaygroundConsole.Waviate.GUI.Slider.SliderEventArgs e)
        {

        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            var sen = sender as CheckBox;
            if (sen != null)
            {
                sen.BackColor = sen.Checked ? WaviateColors.WavPink : WaviateColors.WavMidnight;
                sen.Text = sen.Checked ? "Mutates" : "No Mutation";
                if (!sen.Checked && !CrossBreedActive.Checked)
                {
                    CrossBreedActive.Checked = true;
                }
                MutatorSlider.Enabled = sen.Checked;
                EvolutionAlgorithm.Mutates = sen.Checked;
            }
        }

        int storedBirthRate = 1;
        private void CrossBreedActive_CheckedChanged(object sender, EventArgs e)
        {
            var sen = sender as CheckBox;
            if (sen != null)
            {
                sen.BackColor = sen.Checked ? WaviateColors.WavPink : WaviateColors.WavMidnight;
                sen.Text = sen.Checked ? "Cross Breeds" : "No Cross Breed";
                if (!sen.Checked && !MutateCheck.Checked)
                {
                    MutateCheck.Checked = true;
                }
                if (!sen.Checked)
                {
                    storedBirthRate = (int)BirthRateSlider.SliderValue;
                    BirthRateSlider.SliderValue = 1;
                    BirthRateSlider.Enabled = false;
                } else
                {
                    BirthRateSlider.SliderValue = storedBirthRate;
                    BirthRateSlider.Enabled = true;
                }
                EvolutionAlgorithm.Breeds = sen.Checked;
            }
        }

        private void NewestGenCheck_CheckedChanged(object sender, EventArgs e)
        {
            var sen = sender as CheckBox;
            if (sen != null)
            {
                sen.BackColor = sen.Checked ? WaviateColors.WavPink : WaviateColors.WavMidnight;
                sen.Text = sen.Checked ? "Newest Gen Only" : "All Generations";
                EvolutionAlgorithm.OnlyRecentGeneration = sen.Checked;
            }
        }
        bool FormOpen = true;
        private void RendererBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (FormOpen)
            {
                foreach (Control control in splitContainer1.Panel2.Controls)
                {
                    var controller = control as IndividualSoundController;
                    controller.Repaint();
                    Thread.Sleep(25);
                }
            }
        }

        private void BirthRateSlider_SliderValueChanged(object sender, AudioPlaygroundConsole.Waviate.GUI.Slider.SliderEventArgs e)
        {
            //storedBirthRate = (int)e.newValue;
        }

        private void WaviateApp_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormOpen = false;
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

