using System;
using System.Drawing;
using System.Windows.Forms;
using NAudio.Wave;
using System.Windows.Input;
using System.ComponentModel;
using System.Collections.Generic;

namespace NAudioSampleSequencerForms
{
    public partial class Form1 : Form
    {
        private IWavePlayer waveOut;
        private Pattern pattern;
        private PatternSampleProvider patternSequencer;
        private int tempo;
        private List<string> notes;
        private List<SampleControlCollection> sccList;

        public Form1()
        {
            InitializeComponent();

            tempo = Convert.ToInt32(tempoTextBox.Text);
            sccList = new List<SampleControlCollection>();
            notes = new List<string>();

            //patternDataGrid initialization
            patternDataGrid.ColumnCount = 17;
            patternDataGrid.RowCount = 4;

            patternDataGrid.CellClick += new DataGridViewCellEventHandler(patternDataGrid_CellClick);

            notes.Add("kick-trimmed.wav");
            notes.Add("snare-trimmed.wav");
            notes.Add("closed-hats-trimmed.wav");
            notes.Add("open-hats-trimmed.wav");

            this.pattern = new Pattern(notes, 16);

            // auto-setup with a simple example beat
            this.pattern[0, 0] = this.pattern[0, 8] = 127;
            this.pattern[1, 4] = this.pattern[1, 12] = 127;
            for (int n = 0; n < pattern.Steps; n++)
            {
                this.pattern[2, n] = 127;
            }

            DrawNoteNames();
            DrawPattern();

            //SampleControlCollection initialization
            string[] defaultFiles = { "D:\\VS Workspace\\NAudioSampleSequencerForms\\NAudioSampleSequencerForms\\Samples\\kick-trimmed.wav",
                "D:\\VS Workspace\\NAudioSampleSequencerForms\\NAudioSampleSequencerForms\\Samples\\snare-trimmed.wav",
                "D:\\VS Workspace\\NAudioSampleSequencerForms\\NAudioSampleSequencerForms\\Samples\\closed-hat-trimmed.wav",
                "D:\\VS Workspace\\NAudioSampleSequencerForms\\NAudioSampleSequencerForms\\Samples\\open-hat-trimmed.wav"};

            for (int i = 0; i < 4; i++)
            {
                SampleControlCollection scc = new SampleControlCollection();
                sccList.Add(scc);
                scc.Name = "scc" + (sccList.Count - 1);
                scc.Location = new Point(0, 350 + (100 * (sccList.Count - 1)));
                scc.AddToComboBox(defaultFiles[i]);

                this.Controls.Add(scc);
            }

            patternSequencer = new PatternSampleProvider(pattern);
        }

        /// <summary>
        /// The masterPlaybackButton_Click event handler calls the Play function to start playback.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void masterPlaybackButton_Click(object sender, EventArgs e)
        {
            Play();
        }

        /// <summary>
        /// The newSampleMenuItem_Click event handler creates a new SampleControlCollection and adds a new sample to the 
        /// PatternSampleProvider set to a default file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newSampleMenuItem_Click(object sender, EventArgs e)
        {
            string defaultFile = "D:\\VS Workspace\\NAudioSampleSequencerForms\\NAudioSampleSequencerForms\\Samples\\snare-trimmed.wav";

            SampleControlCollection scc = new SampleControlCollection();
            sccList.Add(scc);
            scc.Name = "scc" + (sccList.Count - 1);
            scc.Location = new Point(0, 350 + (100 * (sccList.Count - 1)));
            scc.AddToComboBox(defaultFile);

            //notes.Add("snare-trimmed.wav");

            this.Controls.Add(scc);

            patternSequencer.Samples.AddNewSample(defaultFile);

            AddNewSampleRow();
        }

        private void patternDataGrid_CellContentClick(object sender, EventArgs e)
        {

        }

        private void patternDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell cell = patternDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex];
            PatternIndex pi = (PatternIndex)cell.Tag;

            pattern[pi.Note, pi.Step] = pattern[pi.Note, pi.Step] == 0 ? (byte)127 : (byte)0;
            if (GetBackColor(pi.Note, pi.Step) == false)
            {
                cell.Style.BackColor = Color.LightSalmon;
            }
            else
            {
                cell.Style.BackColor = Color.White;
            }
        }

        /// <summary>
        /// The stopPlaybackButton_Click event handler calls the Stop function to halt playback.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void stopPlaybackButton_Click(object sender, EventArgs e)
        {
            Stop();
        }

        /// <summary>
        /// The setTempoButton_Click event handler sets the tempo variable to the current value of the tempoBox TextBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void setTempoButton_Click(object sender, EventArgs e)
        {
            tempo = Convert.ToInt32(tempoTextBox.Text);
        }

        /// <summary>
        /// The setSampleButton_Click event handler iterates through each sample and sets it to what the current
        /// SelectedItem of its corresponding ComboBox is.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void setSamplesButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < sccList.Count; i++)
            {
                //Set new note name
                String str = sccList[i].sampleSourceComboBox.SelectedItem.ToString();
                Char delimiter = '\\';
                String[] substrings = str.Split(delimiter);
                notes[i] = substrings[substrings.Length - 1];
                patternDataGrid.Rows[i].Cells[0].Value = notes[i];

                //Set sample
                patternSequencer.Samples.setSample(str, i);
            }
        }

        /// <summary>
        /// The clearPatternButton_Click event handler sets every (note,step) pairing in the Pattern to 0, erasing the
        /// intent to play a sample on the pairing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearPatternButton_Click(object sender, EventArgs e)
        {
            for (int step = 0; step < pattern.Steps; step++)
            {
                for (int note = 0; note < pattern.Notes; note++)
                {
                    if (GetBackColor(note, step) == true)
                    {
                        this.pattern[note, step] = 0;
                    }
                }
            }

            DrawPattern();
        }

        /// <summary>
        /// The AddNewSampleRow function creates a new row in the DataGridView that represents the new sample added by
        /// the user.
        /// </summary>
        private void AddNewSampleRow()
        {
            string defaultSample = "snare-trimmed.wav";
            var oldPattern = this.pattern;

            this.patternDataGrid.Rows.Add();
            notes.Add(defaultSample);
            this.pattern = new Pattern(notes, 16);

            for (int n = 0; n < oldPattern.Notes; n++)
            {
                for (int j = 0; j < oldPattern.Steps; j++)
                {
                    this.pattern[n, j] = oldPattern[n, j];
                }
            }

            DrawNoteNames();
            DrawPattern();
        }

        /// <summary>
        /// The Play function starts playback of the drum machine.
        /// </summary>
        private void Play()
        {
            if (waveOut != null)
            {
                Stop();
            }
            waveOut = new WaveOut();
            this.patternSequencer.Reset(pattern);
            this.patternSequencer.Tempo = tempo;
            waveOut.Init(patternSequencer);
            waveOut.Play();
        }

        /// <summary>
        /// The DrawNoteNames function changes the values of the left most column to be the names of the samples currently
        /// set by the user.
        /// </summary>
        private void DrawNoteNames()
        {
            for (int note = 0; note < pattern.Notes; note++)
            {
                patternDataGrid.Rows[note].Cells[0].Value = pattern.NoteNames[note];
            }
        }

        /// <summary>
        /// The DrawPattern function changes the color of all DataGridView cells that are meant to play a sample on its beat
        /// to LightSalmon. Otherwise, the cell is the color White.
        /// </summary>
        private void DrawPattern()
        {
            for (int step = 0; step < pattern.Steps; step++)
            {
                for (int note = 0; note < pattern.Notes; note++)
                {
                    if (GetBackColor(note, step) == true)
                    {
                        patternDataGrid.Rows[note].Cells[step + 1].Style.BackColor = Color.LightSalmon;
                    }
                    else
                    {
                        patternDataGrid.Rows[note].Cells[step + 1].Style.BackColor = Color.White;
                    }
                    patternDataGrid.Rows[note].Cells[step + 1].Tag = new PatternIndex(note, step);

                }
            }
        }

        /// <summary>
        /// The GetBackColor function checks if a (note,step) pairing in the Pattern is true, meaning
        /// a sample is meant to be played on that (note,step) pairing, or false.
        /// </summary>
        /// <param name="note"> note is the row on the DataGridView, or the sample that is being played. </param>
        /// <param name="step"> step is the column on the DataGridView, or the beat that the sample is played. </param>
        /// <returns> true if the sample is to be played on the (note,step) pairing. false if the sample is not to
        /// be played on the (note,step) pairing. </returns>
        private bool GetBackColor(int note, int step)
        {
            if (pattern[note, step] == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        class PatternIndex
        {
            public PatternIndex(int note, int step)
            {
                this.Note = note;
                this.Step = step;
            }
            public int Note { get; private set; }
            public int Step { get; private set; }
        }

        /// <summary>
        /// The Stop function stops the playback of the drum machine.
        /// </summary>
        private void Stop()
        {
            if (waveOut != null)
            {
                waveOut.Dispose();
                waveOut = null;
            }
        }
    }
}
