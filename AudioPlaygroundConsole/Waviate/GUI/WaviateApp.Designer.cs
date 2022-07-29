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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.StartOver = new System.Windows.Forms.CheckBox();
            this.EvolveStart = new System.Windows.Forms.CheckBox();
            this.splitTopFromBottom = new System.Windows.Forms.SplitContainer();
            this.EscapeApp = new System.Windows.Forms.CheckBox();
            this.FullscreenOrNot = new System.Windows.Forms.CheckBox();
            this.Seeder = new AudioPlaygroundConsole.Waviate.GUI.Slider();
            this.NumberOfSounds = new AudioPlaygroundConsole.Waviate.GUI.Slider();
            this.Timesetter = new AudioPlaygroundConsole.Waviate.GUI.Slider();
            this.MutatorSlider = new AudioPlaygroundConsole.Waviate.GUI.Slider();
            this.MutatorBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
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
            this.splitContainer1.Panel1.Controls.Add(this.MutatorSlider);
            this.splitContainer1.Panel1.Controls.Add(this.Seeder);
            this.splitContainer1.Panel1.Controls.Add(this.NumberOfSounds);
            this.splitContainer1.Panel1.Controls.Add(this.Timesetter);
            this.splitContainer1.Panel1.Controls.Add(this.StartOver);
            this.splitContainer1.Panel1.Controls.Add(this.EvolveStart);
            this.splitContainer1.Panel1MinSize = 260;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Scroll += new System.Windows.Forms.ScrollEventHandler(this.splitContainer1_Panel2_Scroll);
            this.splitContainer1.Panel2.SizeChanged += new System.EventHandler(this.splitContainer1_Panel2_SizeChanged);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(1462, 779);
            this.splitContainer1.SplitterDistance = 260;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.Resize += new System.EventHandler(this.splitContainer1_Resize);
            // 
            // StartOver
            // 
            this.StartOver.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.StartOver.Appearance = System.Windows.Forms.Appearance.Button;
            this.StartOver.AutoSize = true;
            this.StartOver.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.StartOver.Font = new System.Drawing.Font("Energy Dome NBP", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartOver.ForeColor = System.Drawing.Color.White;
            this.StartOver.Location = new System.Drawing.Point(25, 670);
            this.StartOver.Margin = new System.Windows.Forms.Padding(0);
            this.StartOver.Name = "StartOver";
            this.StartOver.Size = new System.Drawing.Size(210, 50);
            this.StartOver.TabIndex = 1;
            this.StartOver.Text = "Restart";
            this.StartOver.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.StartOver.UseVisualStyleBackColor = true;
            this.StartOver.Click += new System.EventHandler(this.StartOver_Click);
            // 
            // EvolveStart
            // 
            this.EvolveStart.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.EvolveStart.Appearance = System.Windows.Forms.Appearance.Button;
            this.EvolveStart.AutoSize = true;
            this.EvolveStart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.EvolveStart.Font = new System.Drawing.Font("Energy Dome NBP", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EvolveStart.ForeColor = System.Drawing.Color.White;
            this.EvolveStart.Location = new System.Drawing.Point(41, 724);
            this.EvolveStart.Margin = new System.Windows.Forms.Padding(0);
            this.EvolveStart.Name = "EvolveStart";
            this.EvolveStart.Size = new System.Drawing.Size(160, 50);
            this.EvolveStart.TabIndex = 0;
            this.EvolveStart.Text = "Start";
            this.EvolveStart.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
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
            this.splitTopFromBottom.Size = new System.Drawing.Size(1462, 841);
            this.splitTopFromBottom.SplitterDistance = 58;
            this.splitTopFromBottom.TabIndex = 0;
            // 
            // EscapeApp
            // 
            this.EscapeApp.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.EscapeApp.Appearance = System.Windows.Forms.Appearance.Button;
            this.EscapeApp.AutoSize = true;
            this.EscapeApp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.EscapeApp.Font = new System.Drawing.Font("Energy Dome NBP", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EscapeApp.ForeColor = System.Drawing.Color.White;
            this.EscapeApp.Location = new System.Drawing.Point(1672, 0);
            this.EscapeApp.Margin = new System.Windows.Forms.Padding(0);
            this.EscapeApp.Name = "EscapeApp";
            this.EscapeApp.Size = new System.Drawing.Size(123, 50);
            this.EscapeApp.TabIndex = 1;
            this.EscapeApp.Text = "EXIT";
            this.EscapeApp.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
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
            this.FullscreenOrNot.Location = new System.Drawing.Point(656, 0);
            this.FullscreenOrNot.Margin = new System.Windows.Forms.Padding(0);
            this.FullscreenOrNot.Name = "FullscreenOrNot";
            this.FullscreenOrNot.Size = new System.Drawing.Size(277, 50);
            this.FullscreenOrNot.TabIndex = 2;
            this.FullscreenOrNot.Text = "FULLSCREEN";
            this.FullscreenOrNot.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.FullscreenOrNot.UseVisualStyleBackColor = true;
            this.FullscreenOrNot.CheckedChanged += new System.EventHandler(this.FullscreenOrNot_CheckedChanged);
            // 
            // Seeder
            // 
            this.Seeder.BackColor = System.Drawing.Color.Transparent;
            this.Seeder.Label = "TEXT";
            this.Seeder.Location = new System.Drawing.Point(3, 346);
            this.Seeder.Name = "Seeder";
            this.Seeder.Ratio = 0D;
            this.Seeder.Size = new System.Drawing.Size(250, 103);
            this.Seeder.SliderValue = 0D;
            this.Seeder.TabIndex = 9;
            // 
            // NumberOfSounds
            // 
            this.NumberOfSounds.BackColor = System.Drawing.Color.Transparent;
            this.NumberOfSounds.Label = "TEXT";
            this.NumberOfSounds.Location = new System.Drawing.Point(7, 564);
            this.NumberOfSounds.Name = "NumberOfSounds";
            this.NumberOfSounds.Ratio = 0D;
            this.NumberOfSounds.Size = new System.Drawing.Size(250, 103);
            this.NumberOfSounds.SliderValue = 0D;
            this.NumberOfSounds.TabIndex = 8;
            // 
            // Timesetter
            // 
            this.Timesetter.BackColor = System.Drawing.Color.Transparent;
            this.Timesetter.Label = "TEXT";
            this.Timesetter.Location = new System.Drawing.Point(3, 455);
            this.Timesetter.Name = "Timesetter";
            this.Timesetter.Ratio = 0D;
            this.Timesetter.Size = new System.Drawing.Size(250, 103);
            this.Timesetter.SliderValue = 0D;
            this.Timesetter.TabIndex = 7;
            this.Timesetter.SliderValueChanged += new AudioPlaygroundConsole.Waviate.GUI.Slider.SliderEvent(this.SetTimeLength);
            // 
            // MutatorSlider
            // 
            this.MutatorSlider.BackColor = System.Drawing.Color.Transparent;
            this.MutatorSlider.Label = "Mutation Amount";
            this.MutatorSlider.Location = new System.Drawing.Point(3, 237);
            this.MutatorSlider.Name = "MutatorSlider";
            this.MutatorSlider.Ratio = 0D;
            this.MutatorSlider.Size = new System.Drawing.Size(250, 103);
            this.MutatorSlider.SliderValue = 0D;
            this.MutatorSlider.TabIndex = 10;
            this.MutatorSlider.SliderValueChanged += new AudioPlaygroundConsole.Waviate.GUI.Slider.SliderEvent(this.MutatorSlider_SliderValueChanged);
            // 
            // MutatorBackgroundWorker
            // 
            this.MutatorBackgroundWorker.WorkerReportsProgress = true;
            this.MutatorBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.MutatorBackgroundWorker_DoWork);
            this.MutatorBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.MutatorBackgroundWorker_ProgressChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Left;
            this.progressBar1.ForeColor = System.Drawing.Color.Tomato;
            this.progressBar1.Location = new System.Drawing.Point(0, 0);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(630, 58);
            this.progressBar1.TabIndex = 0;
            // 
            // WaviateApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Tomato;
            this.ClientSize = new System.Drawing.Size(1462, 841);
            this.Controls.Add(this.splitTopFromBottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WaviateApp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WaviateApp";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
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
    }
}