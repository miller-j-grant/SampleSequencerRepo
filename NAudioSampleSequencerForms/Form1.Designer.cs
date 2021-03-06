﻿namespace NAudioSampleSequencerForms
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.fileDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.newSampleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newPatternMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearPatternMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tempoLabel = new System.Windows.Forms.ToolStripLabel();
            this.tempoTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.setTempoButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.masterPlaybackButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.stopPlaybackButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.setSamplesButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.patternDataGrid = new System.Windows.Forms.DataGridView();
            this.patternLabel = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.patternDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileDropDownButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(982, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // fileDropDownButton
            // 
            this.fileDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fileDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newSampleMenuItem,
            this.newPatternMenuItem,
            this.clearPatternMenuItem});
            this.fileDropDownButton.Image = ((System.Drawing.Image)(resources.GetObject("fileDropDownButton.Image")));
            this.fileDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fileDropDownButton.Name = "fileDropDownButton";
            this.fileDropDownButton.Size = new System.Drawing.Size(46, 24);
            this.fileDropDownButton.Text = "File";
            // 
            // newSampleMenuItem
            // 
            this.newSampleMenuItem.Name = "newSampleMenuItem";
            this.newSampleMenuItem.Size = new System.Drawing.Size(181, 26);
            this.newSampleMenuItem.Text = "New Sample";
            //this.newSampleMenuItem.Click += new System.EventHandler(this.newSampleMenuItem_Click);
            // 
            // newPatternMenuItem
            // 
            this.newPatternMenuItem.Name = "newPatternMenuItem";
            this.newPatternMenuItem.Size = new System.Drawing.Size(181, 26);
            this.newPatternMenuItem.Text = "New Pattern";
            this.newPatternMenuItem.Click += new System.EventHandler(this.newPatternMenuItem_Click);
            // 
            // clearPatternMenuItem
            // 
            this.clearPatternMenuItem.Name = "clearPatternMenuItem";
            this.clearPatternMenuItem.Size = new System.Drawing.Size(181, 26);
            this.clearPatternMenuItem.Text = "Clear Pattern";
            // 
            // toolStrip2
            // 
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tempoLabel,
            this.tempoTextBox,
            this.setTempoButton,
            this.toolStripSeparator2,
            this.toolStripSeparator1,
            this.masterPlaybackButton,
            this.toolStripSeparator5,
            this.stopPlaybackButton,
            this.toolStripSeparator3,
            this.toolStripSeparator4,
            this.setSamplesButton,
            this.toolStripSeparator6,
            this.toolStripSeparator7});
            this.toolStrip2.Location = new System.Drawing.Point(0, 27);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(982, 27);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tempoLabel
            // 
            this.tempoLabel.Name = "tempoLabel";
            this.tempoLabel.Size = new System.Drawing.Size(55, 24);
            this.tempoLabel.Text = "Tempo";
            // 
            // tempoTextBox
            // 
            this.tempoTextBox.Name = "tempoTextBox";
            this.tempoTextBox.Size = new System.Drawing.Size(100, 27);
            this.tempoTextBox.Text = "120";
            // 
            // setTempoButton
            // 
            this.setTempoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.setTempoButton.Image = ((System.Drawing.Image)(resources.GetObject("setTempoButton.Image")));
            this.setTempoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.setTempoButton.Name = "setTempoButton";
            this.setTempoButton.Size = new System.Drawing.Size(84, 24);
            this.setTempoButton.Text = "Set Tempo";
            this.setTempoButton.Click += new System.EventHandler(this.setTempoButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // masterPlaybackButton
            // 
            this.masterPlaybackButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.masterPlaybackButton.Image = ((System.Drawing.Image)(resources.GetObject("masterPlaybackButton.Image")));
            this.masterPlaybackButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.masterPlaybackButton.Name = "masterPlaybackButton";
            this.masterPlaybackButton.Size = new System.Drawing.Size(120, 24);
            this.masterPlaybackButton.Text = "Master Playback";
            this.masterPlaybackButton.Click += new System.EventHandler(this.masterPlaybackButton_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 27);
            // 
            // stopPlaybackButton
            // 
            this.stopPlaybackButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.stopPlaybackButton.Image = ((System.Drawing.Image)(resources.GetObject("stopPlaybackButton.Image")));
            this.stopPlaybackButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stopPlaybackButton.Name = "stopPlaybackButton";
            this.stopPlaybackButton.Size = new System.Drawing.Size(106, 24);
            this.stopPlaybackButton.Text = "Stop Playback";
            this.stopPlaybackButton.Click += new System.EventHandler(this.stopPlaybackButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 27);
            // 
            // setSamplesButton
            // 
            this.setSamplesButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.setSamplesButton.Image = ((System.Drawing.Image)(resources.GetObject("setSamplesButton.Image")));
            this.setSamplesButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.setSamplesButton.Name = "setSamplesButton";
            this.setSamplesButton.Size = new System.Drawing.Size(116, 24);
            this.setSamplesButton.Text = "Set All Samples";
            this.setSamplesButton.Click += new System.EventHandler(this.setSamplesButton_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 27);
            // 
            // patternDataGrid
            // 
            this.patternDataGrid.AllowUserToOrderColumns = true;
            this.patternDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.patternDataGrid.Location = new System.Drawing.Point(12, 89);
            this.patternDataGrid.Name = "patternDataGrid";
            this.patternDataGrid.RowTemplate.Height = 24;
            this.patternDataGrid.Size = new System.Drawing.Size(956, 319);
            this.patternDataGrid.TabIndex = 2;
            // 
            // patternLabel
            // 
            this.patternLabel.AutoSize = true;
            this.patternLabel.Location = new System.Drawing.Point(12, 69);
            this.patternLabel.Name = "patternLabel";
            this.patternLabel.Size = new System.Drawing.Size(67, 17);
            this.patternLabel.TabIndex = 3;
            this.patternLabel.Text = "Pattern 1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(982, 553);
            this.Controls.Add(this.patternLabel);
            this.Controls.Add(this.patternDataGrid);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.patternDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton fileDropDownButton;
        private System.Windows.Forms.ToolStripMenuItem newSampleMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel tempoLabel;
        private System.Windows.Forms.ToolStripTextBox tempoTextBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton masterPlaybackButton;
        private System.Windows.Forms.DataGridView patternDataGrid;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton stopPlaybackButton;
        private System.Windows.Forms.ToolStripButton setTempoButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton setSamplesButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem newPatternMenuItem;
        private System.Windows.Forms.Label patternLabel;
        private System.Windows.Forms.ToolStripMenuItem clearPatternMenuItem;
    }
}

