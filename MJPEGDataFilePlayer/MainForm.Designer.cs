namespace MJPEGDataFilePlayer
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.framePrevButton = new System.Windows.Forms.Button();
            this.frameNextButton = new System.Windows.Forms.Button();
            this.frameCountLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.playRadioButton = new System.Windows.Forms.RadioButton();
            this.pauseRadioButton = new System.Windows.Forms.RadioButton();
            this.stopRadioButton = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.fpsTextBox = new System.Windows.Forms.MaskedTextBox();
            this.saveImgButton = new System.Windows.Forms.Button();
            this.saveImgtoolTip = new System.Windows.Forms.ToolTip(this.components);
            this.trackBar = new MJPEGDataFilePlayer.TrackBarCustom();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(725, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.fileToolStripMenuItem.Text = "File(&F)";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.openToolStripMenuItem.Text = "Open(&O)";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.exitToolStripMenuItem.Text = "Exit(&X)";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.BackColor = System.Drawing.Color.DimGray;
            this.pictureBox.Location = new System.Drawing.Point(12, 27);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(701, 379);
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            this.pictureBox.SizeChanged += new System.EventHandler(this.pictureBox_SizeChanged);
            // 
            // framePrevButton
            // 
            this.framePrevButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.framePrevButton.Location = new System.Drawing.Point(12, 412);
            this.framePrevButton.Name = "framePrevButton";
            this.framePrevButton.Size = new System.Drawing.Size(45, 23);
            this.framePrevButton.TabIndex = 2;
            this.framePrevButton.Text = "<";
            this.framePrevButton.UseVisualStyleBackColor = true;
            this.framePrevButton.Click += new System.EventHandler(this.framePrevButton_Click);
            // 
            // frameNextButton
            // 
            this.frameNextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.frameNextButton.Location = new System.Drawing.Point(668, 412);
            this.frameNextButton.Name = "frameNextButton";
            this.frameNextButton.Size = new System.Drawing.Size(45, 23);
            this.frameNextButton.TabIndex = 3;
            this.frameNextButton.Text = ">";
            this.frameNextButton.UseVisualStyleBackColor = true;
            this.frameNextButton.Click += new System.EventHandler(this.frameNextButton_Click);
            // 
            // frameCountLabel
            // 
            this.frameCountLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.frameCountLabel.AutoSize = true;
            this.frameCountLabel.Location = new System.Drawing.Point(363, 459);
            this.frameCountLabel.Name = "frameCountLabel";
            this.frameCountLabel.Size = new System.Drawing.Size(35, 12);
            this.frameCountLabel.TabIndex = 5;
            this.frameCountLabel.Text = "##/##";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(317, 459);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "Frame:";
            // 
            // playRadioButton
            // 
            this.playRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.playRadioButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.playRadioButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("playRadioButton.BackgroundImage")));
            this.playRadioButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.playRadioButton.Location = new System.Drawing.Point(13, 449);
            this.playRadioButton.Name = "playRadioButton";
            this.playRadioButton.Size = new System.Drawing.Size(37, 36);
            this.playRadioButton.TabIndex = 9;
            this.playRadioButton.UseVisualStyleBackColor = true;
            this.playRadioButton.CheckedChanged += new System.EventHandler(this.playRadioButton_CheckedChanged);
            // 
            // pauseRadioButton
            // 
            this.pauseRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pauseRadioButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.pauseRadioButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pauseRadioButton.BackgroundImage")));
            this.pauseRadioButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pauseRadioButton.Location = new System.Drawing.Point(56, 449);
            this.pauseRadioButton.Name = "pauseRadioButton";
            this.pauseRadioButton.Size = new System.Drawing.Size(37, 36);
            this.pauseRadioButton.TabIndex = 10;
            this.pauseRadioButton.UseVisualStyleBackColor = true;
            this.pauseRadioButton.CheckedChanged += new System.EventHandler(this.playRadioButton_CheckedChanged);
            // 
            // stopRadioButton
            // 
            this.stopRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.stopRadioButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.stopRadioButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("stopRadioButton.BackgroundImage")));
            this.stopRadioButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.stopRadioButton.Checked = true;
            this.stopRadioButton.Location = new System.Drawing.Point(99, 449);
            this.stopRadioButton.Name = "stopRadioButton";
            this.stopRadioButton.Size = new System.Drawing.Size(37, 36);
            this.stopRadioButton.TabIndex = 11;
            this.stopRadioButton.TabStop = true;
            this.stopRadioButton.UseVisualStyleBackColor = true;
            this.stopRadioButton.CheckedChanged += new System.EventHandler(this.playRadioButton_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(155, 460);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "FPS:";
            // 
            // fpsTextBox
            // 
            this.fpsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.fpsTextBox.Location = new System.Drawing.Point(187, 456);
            this.fpsTextBox.Name = "fpsTextBox";
            this.fpsTextBox.Size = new System.Drawing.Size(46, 19);
            this.fpsTextBox.TabIndex = 14;
            this.fpsTextBox.Text = "30";
            // 
            // saveImgButton
            // 
            this.saveImgButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("saveImgButton.BackgroundImage")));
            this.saveImgButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.saveImgButton.Location = new System.Drawing.Point(676, 449);
            this.saveImgButton.Name = "saveImgButton";
            this.saveImgButton.Size = new System.Drawing.Size(37, 36);
            this.saveImgButton.TabIndex = 15;
            this.saveImgButton.UseVisualStyleBackColor = true;
            this.saveImgButton.Click += new System.EventHandler(this.saveImgButton_Click);
            // 
            // trackBar
            // 
            this.trackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar.Location = new System.Drawing.Point(63, 413);
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(599, 45);
            this.trackBar.TabIndex = 7;
            this.trackBar.ValueChanged += new System.EventHandler(this.trackBar_ValueChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 493);
            this.Controls.Add(this.saveImgButton);
            this.Controls.Add(this.fpsTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.stopRadioButton);
            this.Controls.Add(this.pauseRadioButton);
            this.Controls.Add(this.playRadioButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.frameCountLabel);
            this.Controls.Add(this.frameNextButton);
            this.Controls.Add(this.framePrevButton);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.trackBar);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "MJPEG Data File Player";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button framePrevButton;
        private System.Windows.Forms.Button frameNextButton;
        private System.Windows.Forms.Label frameCountLabel;
        private System.Windows.Forms.Label label3;
        private MJPEGDataFilePlayer.TrackBarCustom trackBar;
        private System.Windows.Forms.RadioButton playRadioButton;
        private System.Windows.Forms.RadioButton pauseRadioButton;
        private System.Windows.Forms.RadioButton stopRadioButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox fpsTextBox;
        private System.Windows.Forms.Button saveImgButton;
        private System.Windows.Forms.ToolTip saveImgtoolTip;
    }
}

