namespace NAudioSampleSequencerForms
{
    partial class SampleControlCollection
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
            this.sampleSourceComboBox = new System.Windows.Forms.ComboBox();
            this.dividerLabel = new System.Windows.Forms.Label();
            this.browseButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sampleSourceComboBox
            // 
            this.sampleSourceComboBox.FormattingEnabled = true;
            this.sampleSourceComboBox.Location = new System.Drawing.Point(25, 35);
            this.sampleSourceComboBox.Name = "sampleSourceComboBox";
            this.sampleSourceComboBox.Size = new System.Drawing.Size(250, 24);
            this.sampleSourceComboBox.TabIndex = 0;
            // 
            // dividerLabel
            // 
            this.dividerLabel.AutoSize = true;
            this.dividerLabel.Location = new System.Drawing.Point(3, 83);
            this.dividerLabel.Name = "dividerLabel";
            this.dividerLabel.Size = new System.Drawing.Size(998, 17);
            this.dividerLabel.TabIndex = 1;
            this.dividerLabel.Text = "---------------------------------------------------------------------------------" +
    "--------------------------------------------------------------------------------" +
    "-------------------------------------";
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(281, 36);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 24);
            this.browseButton.TabIndex = 2;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // SampleControlCollection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.dividerLabel);
            this.Controls.Add(this.sampleSourceComboBox);
            this.Name = "SampleControlCollection";
            this.Size = new System.Drawing.Size(1000, 100);
            this.Load += new System.EventHandler(this.SampleControlCollection_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox sampleSourceComboBox;
        private System.Windows.Forms.Label dividerLabel;
        private System.Windows.Forms.Button browseButton;
    }
}
