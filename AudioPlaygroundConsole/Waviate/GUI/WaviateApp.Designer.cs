namespace Waviate
{
    partial class WaviateApp
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WaviateApp));
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.BirthRateSlider = new AudioPlaygroundConsole.Waviate.GUI.Slider();
			this.NewestGenCheck = new System.Windows.Forms.CheckBox();
			this.CrossBreedActive = new System.Windows.Forms.CheckBox();
			this.MutateCheck = new System.Windows.Forms.CheckBox();
			this.MutatorSlider = new AudioPlaygroundConsole.Waviate.GUI.Slider();
			this.Seeder = new AudioPlaygroundConsole.Waviate.GUI.Slider();
			this.NumberOfSounds = new AudioPlaygroundConsole.Waviate.GUI.Slider();
			this.Timesetter = new AudioPlaygroundConsole.Waviate.GUI.Slider();
			this.StartOver = new System.Windows.Forms.CheckBox();
			this.EvolveStart = new System.Windows.Forms.CheckBox();
			this.splitTopFromBottom = new System.Windows.Forms.SplitContainer();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.EscapeApp = new System.Windows.Forms.CheckBox();
			this.FullscreenOrNot = new System.Windows.Forms.CheckBox();
			this.MutatorBackgroundWorker = new System.ComponentModel.BackgroundWorker();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.RendererBackgroundWorker = new System.ComponentModel.BackgroundWorker();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitTopFromBottom)).BeginInit();
			this.splitTopFromBottom.Panel1.SuspendLayout();
			this.splitTopFromBottom.Panel2.SuspendLayout();
			this.splitTopFromBottom.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.IsSplitterFixed = true;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.BirthRateSlider);
			this.splitContainer1.Panel1.Controls.Add(this.NewestGenCheck);
			this.splitContainer1.Panel1.Controls.Add(this.CrossBreedActive);
			this.splitContainer1.Panel1.Controls.Add(this.MutateCheck);
			this.splitContainer1.Panel1.Controls.Add(this.MutatorSlider);
			this.splitContainer1.Panel1.Controls.Add(this.Seeder);
			this.splitContainer1.Panel1.Controls.Add(this.NumberOfSounds);
			this.splitContainer1.Panel1.Controls.Add(this.Timesetter);
			this.splitContainer1.Panel1.Controls.Add(this.StartOver);
			this.splitContainer1.Panel1.Controls.Add(this.EvolveStart);
			this.splitContainer1.Panel1MinSize = 345;
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.AutoScroll = true;
			this.splitContainer1.Panel2.Scroll += new System.Windows.Forms.ScrollEventHandler(this.splitContainer1_Panel2_Scroll);
			this.splitContainer1.Panel2.SizeChanged += new System.EventHandler(this.splitContainer1_Panel2_SizeChanged);
			this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
			this.splitContainer1.Size = new System.Drawing.Size(1942, 959);
			this.splitContainer1.SplitterDistance = 345;
			this.splitContainer1.SplitterWidth = 5;
			this.splitContainer1.TabIndex = 0;
			this.splitContainer1.Resize += new System.EventHandler(this.splitContainer1_Resize);
			// 
			// BirthRateSlider
			// 
			this.BirthRateSlider.BackColor = System.Drawing.Color.Transparent;
			this.BirthRateSlider.Label = "Birth Rate";
			this.BirthRateSlider.Location = new System.Drawing.Point(7, 5);
			this.BirthRateSlider.Margin = new System.Windows.Forms.Padding(5);
			this.BirthRateSlider.Name = "BirthRateSlider";
			this.BirthRateSlider.Ratio = 0D;
			this.BirthRateSlider.Size = new System.Drawing.Size(333, 127);
			this.BirthRateSlider.SliderMax = 4D;
			this.BirthRateSlider.SliderMin = 1D;
			this.BirthRateSlider.SliderValue = 1D;
			this.BirthRateSlider.TabIndex = 16;
			this.toolTip1.SetToolTip(this.BirthRateSlider, "Indicates the number of children created from a cross breed.\r\nThis number is alwa" +
        "ys 1 when sounds don\'t cross breed.\r\n");
			this.BirthRateSlider.SliderValueChanged += new AudioPlaygroundConsole.Waviate.GUI.Slider.SliderEvent(this.BirthRateSlider_SliderValueChanged);
			// 
			// NewestGenCheck
			// 
			this.NewestGenCheck.Appearance = System.Windows.Forms.Appearance.Button;
			this.NewestGenCheck.Font = new System.Drawing.Font("Energy Dome NBP", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.NewestGenCheck.ForeColor = System.Drawing.Color.White;
			this.NewestGenCheck.Location = new System.Drawing.Point(12, 188);
			this.NewestGenCheck.Name = "NewestGenCheck";
			this.NewestGenCheck.Size = new System.Drawing.Size(333, 45);
			this.NewestGenCheck.TabIndex = 15;
			this.NewestGenCheck.Text = "Newest Generation";
			this.NewestGenCheck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.NewestGenCheck, "Indicates whether we should breed new sounds from all sounds in\r\nthe list, or onl" +
        "y sounds from the most recent generation (lowest number)");
			this.NewestGenCheck.UseVisualStyleBackColor = true;
			this.NewestGenCheck.CheckedChanged += new System.EventHandler(this.NewestGenCheck_CheckedChanged);
			// 
			// CrossBreedActive
			// 
			this.CrossBreedActive.Appearance = System.Windows.Forms.Appearance.Button;
			this.CrossBreedActive.Font = new System.Drawing.Font("Energy Dome NBP", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CrossBreedActive.ForeColor = System.Drawing.Color.White;
			this.CrossBreedActive.Location = new System.Drawing.Point(9, 140);
			this.CrossBreedActive.Name = "CrossBreedActive";
			this.CrossBreedActive.Size = new System.Drawing.Size(333, 45);
			this.CrossBreedActive.TabIndex = 14;
			this.CrossBreedActive.Text = "Cross Breed";
			this.CrossBreedActive.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.CrossBreedActive, resources.GetString("CrossBreedActive.ToolTip"));
			this.CrossBreedActive.UseVisualStyleBackColor = true;
			this.CrossBreedActive.CheckedChanged += new System.EventHandler(this.CrossBreedActive_CheckedChanged);
			// 
			// MutateCheck
			// 
			this.MutateCheck.Appearance = System.Windows.Forms.Appearance.Button;
			this.MutateCheck.Font = new System.Drawing.Font("Energy Dome NBP", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MutateCheck.ForeColor = System.Drawing.Color.White;
			this.MutateCheck.Location = new System.Drawing.Point(12, 239);
			this.MutateCheck.Name = "MutateCheck";
			this.MutateCheck.Size = new System.Drawing.Size(333, 45);
			this.MutateCheck.TabIndex = 13;
			this.MutateCheck.Text = "Mutates";
			this.MutateCheck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.MutateCheck, "If this is enabled, sounds will mutate some from their predecessors.\r\nIf sounds a" +
        "re not being cross bred, they must mutate or else sounds\r\nbeing born will be exa" +
        "ct clones of their parents.");
			this.MutateCheck.UseVisualStyleBackColor = true;
			this.MutateCheck.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// MutatorSlider
			// 
			this.MutatorSlider.BackColor = System.Drawing.Color.Transparent;
			this.MutatorSlider.Label = "Mutation Amount";
			this.MutatorSlider.Location = new System.Drawing.Point(4, 292);
			this.MutatorSlider.Margin = new System.Windows.Forms.Padding(5);
			this.MutatorSlider.Name = "MutatorSlider";
			this.MutatorSlider.NumberOfDecimalPlaces = 2;
			this.MutatorSlider.Ratio = 0.040404040404040407D;
			this.MutatorSlider.Size = new System.Drawing.Size(333, 127);
			this.MutatorSlider.SliderMax = 1D;
			this.MutatorSlider.SliderMin = 0.01D;
			this.MutatorSlider.SliderValue = 0.05D;
			this.MutatorSlider.TabIndex = 10;
			this.toolTip1.SetToolTip(this.MutatorSlider, "Amount each sound should mutate when bred from their predecessors.\r\nThe higher th" +
        "e value, the more a sound will differ from its parent(s).");
			this.MutatorSlider.SliderValueChanged += new AudioPlaygroundConsole.Waviate.GUI.Slider.SliderEvent(this.MutatorSlider_SliderValueChanged);
			// 
			// Seeder
			// 
			this.Seeder.BackColor = System.Drawing.Color.Transparent;
			this.Seeder.Label = "Seed";
			this.Seeder.Location = new System.Drawing.Point(4, 426);
			this.Seeder.Margin = new System.Windows.Forms.Padding(5);
			this.Seeder.Name = "Seeder";
			this.Seeder.Ratio = 0.5859375D;
			this.Seeder.Size = new System.Drawing.Size(333, 127);
			this.Seeder.SliderMax = 256D;
			this.Seeder.SliderMin = 0D;
			this.Seeder.SliderValue = 150D;
			this.Seeder.TabIndex = 9;
			this.toolTip1.SetToolTip(this.Seeder, "Chooses a seed for the random number generator. If the seed is the same on two ru" +
        "ns, \r\nthe sounds generated will be the same as well. You can use the same seed t" +
        "o recover\r\nthe original sound group.\r\n");
			// 
			// NumberOfSounds
			// 
			this.NumberOfSounds.BackColor = System.Drawing.Color.Transparent;
			this.NumberOfSounds.Label = "Number Of Sounds";
			this.NumberOfSounds.Location = new System.Drawing.Point(9, 694);
			this.NumberOfSounds.Margin = new System.Windows.Forms.Padding(5);
			this.NumberOfSounds.Name = "NumberOfSounds";
			this.NumberOfSounds.Ratio = 0D;
			this.NumberOfSounds.Size = new System.Drawing.Size(333, 127);
			this.NumberOfSounds.SliderMax = 32D;
			this.NumberOfSounds.SliderMin = 3D;
			this.NumberOfSounds.SliderValue = 3D;
			this.NumberOfSounds.TabIndex = 8;
			this.toolTip1.SetToolTip(this.NumberOfSounds, "The number of sounds created for the original generation.");
			// 
			// Timesetter
			// 
			this.Timesetter.BackColor = System.Drawing.Color.Transparent;
			this.Timesetter.Label = "Clip Length (Seconds)";
			this.Timesetter.Location = new System.Drawing.Point(4, 560);
			this.Timesetter.Margin = new System.Windows.Forms.Padding(5);
			this.Timesetter.Name = "Timesetter";
			this.Timesetter.NumberOfDecimalPlaces = 1;
			this.Timesetter.Ratio = 0.18367346938775508D;
			this.Timesetter.Size = new System.Drawing.Size(333, 127);
			this.Timesetter.SliderMax = 5D;
			this.Timesetter.SliderMin = 0.1D;
			this.Timesetter.SliderValue = 1D;
			this.Timesetter.TabIndex = 7;
			this.toolTip1.SetToolTip(this.Timesetter, "The playback length of the sound in seconds. This value can be changed at\r\nany ti" +
        "me and affects the play audio button and the save button.");
			this.Timesetter.SliderValueChanged += new AudioPlaygroundConsole.Waviate.GUI.Slider.SliderEvent(this.SetTimeLength);
			// 
			// StartOver
			// 
			this.StartOver.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.StartOver.Appearance = System.Windows.Forms.Appearance.Button;
			this.StartOver.Enabled = false;
			this.StartOver.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.StartOver.Font = new System.Drawing.Font("Energy Dome NBP", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.StartOver.ForeColor = System.Drawing.Color.White;
			this.StartOver.Location = new System.Drawing.Point(12, 826);
			this.StartOver.Margin = new System.Windows.Forms.Padding(0);
			this.StartOver.Name = "StartOver";
			this.StartOver.Size = new System.Drawing.Size(333, 56);
			this.StartOver.TabIndex = 1;
			this.StartOver.Text = "Restart";
			this.StartOver.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.toolTip1.SetToolTip(this.StartOver, "Deletes all sounds in the workspace");
			this.StartOver.UseVisualStyleBackColor = true;
			this.StartOver.Click += new System.EventHandler(this.StartOver_Click);
			// 
			// EvolveStart
			// 
			this.EvolveStart.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.EvolveStart.Appearance = System.Windows.Forms.Appearance.Button;
			this.EvolveStart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.EvolveStart.Font = new System.Drawing.Font("Energy Dome NBP", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.EvolveStart.ForeColor = System.Drawing.Color.White;
			this.EvolveStart.Location = new System.Drawing.Point(12, 897);
			this.EvolveStart.Margin = new System.Windows.Forms.Padding(0);
			this.EvolveStart.Name = "EvolveStart";
			this.EvolveStart.Size = new System.Drawing.Size(333, 56);
			this.EvolveStart.TabIndex = 0;
			this.EvolveStart.Text = "Start";
			this.EvolveStart.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.toolTip1.SetToolTip(this.EvolveStart, "Starts the evolution process and creates the next generation of sounds.");
			this.EvolveStart.UseVisualStyleBackColor = true;
			this.EvolveStart.CheckedChanged += new System.EventHandler(this.EvolveStart_CheckedChanged);
			this.EvolveStart.SizeChanged += new System.EventHandler(this.splitContainer1_Resize);
			this.EvolveStart.TextChanged += new System.EventHandler(this.splitContainer1_Resize);
			this.EvolveStart.Click += new System.EventHandler(this.EvolveStart_Click);
			this.EvolveStart.Resize += new System.EventHandler(this.splitContainer1_Resize);
			// 
			// splitTopFromBottom
			// 
			this.splitTopFromBottom.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitTopFromBottom.IsSplitterFixed = true;
			this.splitTopFromBottom.Location = new System.Drawing.Point(0, 0);
			this.splitTopFromBottom.Margin = new System.Windows.Forms.Padding(0);
			this.splitTopFromBottom.Name = "splitTopFromBottom";
			this.splitTopFromBottom.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitTopFromBottom.Panel1
			// 
			this.splitTopFromBottom.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.splitTopFromBottom.Panel1.Controls.Add(this.progressBar1);
			this.splitTopFromBottom.Panel1.Controls.Add(this.EscapeApp);
			this.splitTopFromBottom.Panel1.Controls.Add(this.FullscreenOrNot);
			this.splitTopFromBottom.Panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TopOfScreen_MouseDown);
			this.splitTopFromBottom.Panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TopOfScreen_MouseMove);
			this.splitTopFromBottom.Panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TopOfScreen_MouseUp);
			// 
			// splitTopFromBottom.Panel2
			// 
			this.splitTopFromBottom.Panel2.Controls.Add(this.splitContainer1);
			this.splitTopFromBottom.Size = new System.Drawing.Size(1942, 1035);
			this.splitTopFromBottom.SplitterDistance = 71;
			this.splitTopFromBottom.SplitterWidth = 5;
			this.splitTopFromBottom.TabIndex = 0;
			// 
			// progressBar1
			// 
			this.progressBar1.Dock = System.Windows.Forms.DockStyle.Left;
			this.progressBar1.ForeColor = System.Drawing.Color.Tomato;
			this.progressBar1.Location = new System.Drawing.Point(0, 0);
			this.progressBar1.Margin = new System.Windows.Forms.Padding(4);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(840, 71);
			this.progressBar1.TabIndex = 0;
			// 
			// EscapeApp
			// 
			this.EscapeApp.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.EscapeApp.Appearance = System.Windows.Forms.Appearance.Button;
			this.EscapeApp.AutoSize = true;
			this.EscapeApp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.EscapeApp.Font = new System.Drawing.Font("Energy Dome NBP", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.EscapeApp.ForeColor = System.Drawing.Color.White;
			this.EscapeApp.Location = new System.Drawing.Point(2226, 0);
			this.EscapeApp.Margin = new System.Windows.Forms.Padding(0);
			this.EscapeApp.Name = "EscapeApp";
			this.EscapeApp.Size = new System.Drawing.Size(151, 60);
			this.EscapeApp.TabIndex = 1;
			this.EscapeApp.Text = "EXIT";
			this.EscapeApp.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.toolTip1.SetToolTip(this.EscapeApp, "Close Waviate");
			this.EscapeApp.UseVisualStyleBackColor = true;
			this.EscapeApp.Click += new System.EventHandler(this.EscapeApp_Click);
			// 
			// FullscreenOrNot
			// 
			this.FullscreenOrNot.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.FullscreenOrNot.Appearance = System.Windows.Forms.Appearance.Button;
			this.FullscreenOrNot.AutoSize = true;
			this.FullscreenOrNot.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.FullscreenOrNot.Font = new System.Drawing.Font("Energy Dome NBP", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FullscreenOrNot.ForeColor = System.Drawing.Color.White;
			this.FullscreenOrNot.Location = new System.Drawing.Point(872, 0);
			this.FullscreenOrNot.Margin = new System.Windows.Forms.Padding(0);
			this.FullscreenOrNot.Name = "FullscreenOrNot";
			this.FullscreenOrNot.Size = new System.Drawing.Size(342, 60);
			this.FullscreenOrNot.TabIndex = 2;
			this.FullscreenOrNot.Text = "FULLSCREEN";
			this.FullscreenOrNot.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.toolTip1.SetToolTip(this.FullscreenOrNot, "Change the window mode of the application.");
			this.FullscreenOrNot.UseVisualStyleBackColor = true;
			this.FullscreenOrNot.CheckedChanged += new System.EventHandler(this.FullscreenOrNot_CheckedChanged);
			// 
			// MutatorBackgroundWorker
			// 
			this.MutatorBackgroundWorker.WorkerReportsProgress = true;
			this.MutatorBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.MutatorBackgroundWorker_DoWork);
			this.MutatorBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.MutatorBackgroundWorker_ProgressChanged);
			// 
			// toolTip1
			// 
			this.toolTip1.BackColor = System.Drawing.Color.Black;
			this.toolTip1.ForeColor = System.Drawing.Color.White;
			// 
			// RendererBackgroundWorker
			// 
			this.RendererBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.RendererBackgroundWorker_DoWork);
			// 
			// WaviateApp
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Tomato;
			this.ClientSize = new System.Drawing.Size(1942, 1035);
			this.Controls.Add(this.splitTopFromBottom);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "WaviateApp";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "WaviateApp";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WaviateApp_FormClosing);
			this.splitContainer1.Panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.splitTopFromBottom.Panel1.ResumeLayout(false);
			this.splitTopFromBottom.Panel1.PerformLayout();
			this.splitTopFromBottom.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitTopFromBottom)).EndInit();
			this.splitTopFromBottom.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitTopFromBottom;
        private System.Windows.Forms.CheckBox EvolveStart;
        private System.Windows.Forms.CheckBox EscapeApp;
        private System.Windows.Forms.CheckBox StartOver;
        private System.Windows.Forms.CheckBox FullscreenOrNot;
        private AudioPlaygroundConsole.Waviate.GUI.Slider Timesetter;
        private AudioPlaygroundConsole.Waviate.GUI.Slider NumberOfSounds;
        private AudioPlaygroundConsole.Waviate.GUI.Slider Seeder;
        private AudioPlaygroundConsole.Waviate.GUI.Slider MutatorSlider;
        private System.ComponentModel.BackgroundWorker MutatorBackgroundWorker;
        private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.CheckBox MutateCheck;
		private System.Windows.Forms.CheckBox NewestGenCheck;
		private System.Windows.Forms.CheckBox CrossBreedActive;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.ComponentModel.BackgroundWorker RendererBackgroundWorker;
		private AudioPlaygroundConsole.Waviate.GUI.Slider BirthRateSlider;
	}
}