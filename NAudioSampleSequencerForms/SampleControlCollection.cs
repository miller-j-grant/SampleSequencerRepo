using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NAudioSampleSequencerForms
{
    public partial class SampleControlCollection : UserControl
    {
        public SampleControlCollection()
        {
            InitializeComponent();
            // Associate the event-handling method with the 
            // SelectedIndexChanged event.
            this.sampleSourceComboBox.SelectedIndexChanged +=
                new System.EventHandler(sampleSourceComboBox_SelectedIndexChanged);
        }

        private void SampleControlCollection_Load(object sender, EventArgs e)
        {

        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            //Stream myStream = null;
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "C:\\";
            openFileDialog.Filter = "wav files (*.wav)|*.wav|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                sampleSourceComboBox.Items.Add(filePath);
            }
        }

        private void sampleSourceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void AddToComboBox(string str)
        {
            sampleSourceComboBox.Items.Add(str);
            sampleSourceComboBox.SelectedItem = str;
        }
    }
}
