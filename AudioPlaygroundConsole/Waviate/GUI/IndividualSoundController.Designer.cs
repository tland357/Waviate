namespace Waviate.GUI
{
    partial class IndividualSoundController
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IndividualSoundController));
			this.SaveAudio = new System.Windows.Forms.CheckBox();
			this.KillSave = new System.Windows.Forms.CheckBox();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.PlayAudio = new System.Windows.Forms.CheckBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.waveViewer1 = new Waviate.GUI.WaveViewer();
			this.Deleter = new System.Windows.Forms.CheckBox();
			this.NameShower = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// SaveAudio
			// 
			this.SaveAudio.Appearance = System.Windows.Forms.Appearance.Button;
			this.SaveAudio.BackColor = System.Drawing.Color.Black;
			this.SaveAudio.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.SaveAudio.Font = new System.Drawing.Font("Energy Dome NBP", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SaveAudio.ForeColor = System.Drawing.Color.White;
			this.SaveAudio.Image = ((System.Drawing.Image)(resources.GetObject("SaveAudio.Image")));
			this.SaveAudio.Location = new System.Drawing.Point(7, 59);
			this.SaveAudio.Margin = new System.Windows.Forms.Padding(0);
			this.SaveAudio.Name = "SaveAudio";
			this.SaveAudio.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.SaveAudio.Size = new System.Drawing.Size(269, 47);
			this.SaveAudio.TabIndex = 2;
			this.SaveAudio.Text = "Save Audio";
			this.SaveAudio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.SaveAudio.UseVisualStyleBackColor = false;
			this.SaveAudio.Click += new System.EventHandler(this.SaveAudio_Click);
			// 
			// KillSave
			// 
			this.KillSave.Appearance = System.Windows.Forms.Appearance.Button;
			this.KillSave.BackColor = System.Drawing.Color.Black;
			this.KillSave.Checked = true;
			this.KillSave.CheckState = System.Windows.Forms.CheckState.Checked;
			this.KillSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.KillSave.Font = new System.Drawing.Font("Energy Dome NBP", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.KillSave.ForeColor = System.Drawing.Color.White;
			this.KillSave.Image = ((System.Drawing.Image)(resources.GetObject("KillSave.Image")));
			this.KillSave.Location = new System.Drawing.Point(7, 6);
			this.KillSave.Margin = new System.Windows.Forms.Padding(0);
			this.KillSave.Name = "KillSave";
			this.KillSave.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.KillSave.Size = new System.Drawing.Size(269, 47);
			this.KillSave.TabIndex = 0;
			this.KillSave.Text = "Survive";
			this.KillSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.KillSave.UseVisualStyleBackColor = false;
			this.KillSave.CheckedChanged += new System.EventHandler(this.KillOrSaveChanged);
			// 
			// saveFileDialog1
			// 
			this.saveFileDialog1.Filter = "Sound Files|*.wav";
			// 
			// PlayAudio
			// 
			this.PlayAudio.Appearance = System.Windows.Forms.Appearance.Button;
			this.PlayAudio.BackColor = System.Drawing.Color.Black;
			this.PlayAudio.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.PlayAudio.Font = new System.Drawing.Font("Energy Dome NBP", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PlayAudio.ForeColor = System.Drawing.Color.White;
			this.PlayAudio.Image = ((System.Drawing.Image)(resources.GetObject("PlayAudio.Image")));
			this.PlayAudio.Location = new System.Drawing.Point(7, 112);
			this.PlayAudio.Margin = new System.Windows.Forms.Padding(0);
			this.PlayAudio.Name = "PlayAudio";
			this.PlayAudio.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.PlayAudio.Size = new System.Drawing.Size(269, 47);
			this.PlayAudio.TabIndex = 3;
			this.PlayAudio.Text = "Play Audio";
			this.PlayAudio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.PlayAudio.UseVisualStyleBackColor = false;
			this.PlayAudio.Click += new System.EventHandler(this.PlayAudio_Click);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Tomato;
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 334);
			this.panel1.Margin = new System.Windows.Forms.Padding(0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(888, 6);
			this.panel1.TabIndex = 4;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Energy Dome NBP", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(7, 172);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(269, 58);
			this.label1.TabIndex = 5;
			this.label1.Text = "label1";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// waveViewer1
			// 
			this.waveViewer1.BackColor = System.Drawing.Color.Black;
			this.waveViewer1.Location = new System.Drawing.Point(280, 0);
			this.waveViewer1.Margin = new System.Windows.Forms.Padding(0);
			this.waveViewer1.Name = "waveViewer1";
			this.waveViewer1.Size = new System.Drawing.Size(608, 308);
			this.waveViewer1.TabIndex = 1;
			this.waveViewer1.Paint += new System.Windows.Forms.PaintEventHandler(this.waveViewer1_Paint);
			this.waveViewer1.MouseEnter += new System.EventHandler(this.Repaint);
			this.waveViewer1.MouseLeave += new System.EventHandler(this.Repaint);
			// 
			// Deleter
			// 
			this.Deleter.Appearance = System.Windows.Forms.Appearance.Button;
			this.Deleter.BackColor = System.Drawing.Color.Black;
			this.Deleter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.Deleter.Font = new System.Drawing.Font("Energy Dome NBP", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Deleter.ForeColor = System.Drawing.Color.White;
			this.Deleter.Image = ((System.Drawing.Image)(resources.GetObject("Deleter.Image")));
			this.Deleter.Location = new System.Drawing.Point(7, 241);
			this.Deleter.Margin = new System.Windows.Forms.Padding(0);
			this.Deleter.Name = "Deleter";
			this.Deleter.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.Deleter.Size = new System.Drawing.Size(269, 47);
			this.Deleter.TabIndex = 6;
			this.Deleter.Text = "Delete";
			this.Deleter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.Deleter.UseVisualStyleBackColor = false;
			this.Deleter.Click += new System.EventHandler(this.Deleter_Click);
			// 
			// NameShower
			// 
			this.NameShower.BackColor = System.Drawing.Color.Transparent;
			this.NameShower.Font = new System.Drawing.Font("Energy Dome NBP", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.NameShower.ForeColor = System.Drawing.Color.Tomato;
			this.NameShower.Location = new System.Drawing.Point(8, 291);
			this.NameShower.Name = "NameShower";
			this.NameShower.Size = new System.Drawing.Size(269, 58);
			this.NameShower.TabIndex = 7;
			this.NameShower.Text = "label2";
			this.NameShower.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// IndividualSoundController
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.NameShower);
			this.Controls.Add(this.Deleter);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.PlayAudio);
			this.Controls.Add(this.SaveAudio);
			this.Controls.Add(this.waveViewer1);
			this.Controls.Add(this.KillSave);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "IndividualSoundController";
			this.Size = new System.Drawing.Size(888, 340);
			this.MouseEnter += new System.EventHandler(this.Repaint);
			this.MouseLeave += new System.EventHandler(this.Repaint);
			this.Resize += new System.EventHandler(this.IndividualSoundController_Resize);
			this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.CheckBox SaveAudio;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.CheckBox PlayAudio;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.CheckBox KillSave;
        private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox Deleter;
		private System.Windows.Forms.Label NameShower;
		public WaveViewer waveViewer1;
	}
}
