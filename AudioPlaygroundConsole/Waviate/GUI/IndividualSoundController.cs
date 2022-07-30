using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Waviate.Model;
using Waviate.Model.EvolutionAlgo;

namespace Waviate.GUI
{
    public partial class IndividualSoundController : UserControl
    {
        public IndividualSoundController()
        {
            InitializeComponent();
            KillOrSaveChanged(KillSave, null);
            this.BackColor = WaviateColors.WavMidnight;
            SaveAudio.BackColor = WaviateColors.WavDarkPurp;

        }
        SoundCreature soundcreature;

        public SoundCreature SoundCreator
        {
            get { return soundcreature; }
            set
            {
                if (soundcreature != null)
                {
                    //Cleanup after last creature
                }
                if (value != null)
                {
                    soundcreature = value;
                    waveViewer1.DisplayData(value, EvolutionAlgorithm.Volume);
                    soundcreature.OnDirtied += Repaint;
                    Repaint();
                }
            }
        }
        void UpdateNumber(SoundCreature creature)
        {
            label1.Text = creature?.Lifetime.ToString() ?? "0";
        }
        private void KillOrSaveChanged(object sender, EventArgs e)
        {
            var check = sender as CheckBox;
            if (check != null)
            {
                check.Text = check.Checked ? "SURVIVE" : "KILL";
                check.BackColor = check.Checked ? WaviateColors.WavDarkPurp : WaviateColors.WavPink;
            }
        }

        private void IndividualSoundController_Resize(object sender, EventArgs e)
        {
            waveViewer1.Width = this.Width - waveViewer1.Left - 30;
            waveViewer1.Height = this.Height - 10;
            waveViewer1.Location = new Point(waveViewer1.Location.X,5);
            KillSave.Font = new Font(KillSave.Font.FontFamily, 0.065f * this.Height, FontStyle.Bold);
        }
        public void Repaint(object sender = null, EventArgs e = null)
        {
            waveViewer1.Invalidate();
            
        }

        private void SaveAudio_Click(object sender, EventArgs e)
        {
            SaveAudio.Checked = false;
            saveFileDialog1.FileName = String.Format("{0}_{1}", SoundCreator.FirstName, SoundCreator.LastName);
            var result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK && SoundCreator != null)
            {
                AudioFileWriter.Create(SoundCreator, saveFileDialog1.FileName);
            }
        }

        private void PlayAudio_Click(object sender, EventArgs e)
        {
            if (SoundCreator == null) return;
            Repaint();
            PlayAudio.Checked = false;
            string exeurl = System.Reflection.Assembly.GetEntryAssembly().Location;
            StringBuilder url = new StringBuilder(exeurl);
            while (url[url.Length - 1] != '\\' && url[url.Length - 1] != '/')
            {
                url.Remove(url.Length - 1, 1);

            }
            url.Append("temp.wav");
            string saveURL = url.ToString();
            AudioFileWriter.Create(SoundCreator, saveURL);
            AudioPlaygroundConsole.WavePlayer.PlayAudio(saveURL);
            
        }

        private void waveViewer1_Paint(object sender, PaintEventArgs e)
        {
            label1.Text = String.Format("Generations Alive: {0}", SoundCreator.Lifetime);
            NameShower.Text = String.Format("{0} {1}", SoundCreator.FirstName, SoundCreator.LastName);
        }

        private void Deleter_Click(object sender, EventArgs e)
        {
            Deleter.Checked = false;
            if (SoundCreator != null)
            {
                EvolutionAlgorithm.CurrentPopulation.Remove(SoundCreator);
                if (EvolutionAlgorithm.CurrentPopulation.Count == 0) EvolutionAlgorithm.Reset();
                var wavApp = WaviateApp.ActiveForm as WaviateApp;
                wavApp.NextGenControllers(EvolutionAlgorithm.CurrentPopulation, null);
            }
        }
    }
}
