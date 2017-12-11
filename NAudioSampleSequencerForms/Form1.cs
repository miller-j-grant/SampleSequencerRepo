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
            string[] defaultFiles = { "D:/VS Workspace/NAudioSampleSequencerForms/NAudioSampleSequencerForms/Samples/kick-trimmed.wav",
                "D:/VS Workspace/NAudioSampleSequencerForms/NAudioSampleSequencerForms/Samples/snare-trimmed.wav",
                "D:/VS Workspace/NAudioSampleSequencerForms/NAudioSampleSequencerForms/Samples/closed-hat-trimmed.wav",
                "D:/VS Workspace/NAudioSampleSequencerForms/NAudioSampleSequencerForms/Samples/open-hat-trimmed.wav"};

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

        private void masterPlaybackButton_Click(object sender, EventArgs e)
        {
            Play();
        }

        private void newSampleMenuItem_Click(object sender, EventArgs e)
        {
            string defaultFile = "D:/VS Workspace/NAudioSampleSequencerForms/NAudioSampleSequencerForms/Samples/snare-trimmed.wav";

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

        private void stopPlaybackButton_Click(object sender, EventArgs e)
        {
            Stop();
        }

        private void setTempoButton_Click(object sender, EventArgs e)
        {
            tempo = Convert.ToInt32(tempoTextBox.Text);
        }

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

            //for (int k = 0; k < pattern.Steps; k++)
            //{
            //    this.pattern[pattern.Notes - 1, k] = 0;
            //}

            DrawNoteNames();
            DrawPattern();
        }

        private void Play()
        {
            if (waveOut != null)
            {
                Stop();
            }
            waveOut = new WaveOut();
            //this.patternSequencer = new PatternSampleProvider(pattern);
            this.patternSequencer.Reset(pattern);
            this.patternSequencer.Tempo = tempo;
            waveOut.Init(patternSequencer);
            waveOut.Play();
        }

        private void DrawNoteNames()
        {
            for (int note = 0; note < pattern.Notes; note++)
            {
                patternDataGrid.Rows[note].Cells[0].Value = pattern.NoteNames[note];
            }
        }

        private void DrawPattern()
        {
            for (int step = 0; step < pattern.Steps; step++)
            {
                for (int note = 0; note < pattern.Notes; note++)
                {
                    if (GetBackColor(note, step) == false)
                    {
                        patternDataGrid.Rows[note].Cells[step+1].Style.BackColor = Color.LightSalmon;
                    }
                    patternDataGrid.Rows[note].Cells[step + 1].Tag = new PatternIndex(note, step);

                }
            }
        }

        private bool GetBackColor(int note, int step)
        {
            if (pattern[note, step] == 0)
            {
                return true;
            }
            else
            {
                return false;
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

        private void Stop()
        {
            if (waveOut != null)
            {
                //this.patternSequencer = null;
                waveOut.Dispose();
                waveOut = null;
            }
        }
    }
}
