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
        private List<SampleControlCollection> sccList;

        public Form1()
        {
            InitializeComponent();
            tempo = Convert.ToInt32(tempoTextBox.Text); 
            PatternDataGridInitialization();
        }

        private void masterPlaybackButton_Click(object sender, EventArgs e)
        {
            Play();
        }

        private void newSampleMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void patternDataGrid_CellContentClick(object sender, EventArgs e)
        {

        }

        private void Play()
        {
            if (waveOut != null)
            {
                Stop();
            }
            waveOut = new WaveOut();
            this.patternSequencer = new PatternSampleProvider(pattern);
            this.patternSequencer.Tempo = tempo;
            waveOut.Init(patternSequencer);
            waveOut.Play();
        }

        private void PatternDataGridInitialization()
        {
            patternDataGrid.ColumnCount = 17;
            patternDataGrid.RowCount = 4;
            patternDataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(patternDataGrid_CellClick);
            var notes = new string[] { "Kick", "Snare", "Closed Hats", "Open Hats" };
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

        private void stopPlaybackButton_Click(object sender, EventArgs e)
        {
            Stop();
        }

        private void Stop()
        {
            if (waveOut != null)
            {
                this.patternSequencer = null;
                waveOut.Dispose();
                waveOut = null;
            }
        }

        private void setTempoButton_Click(object sender, EventArgs e)
        {
            tempo = Convert.ToInt32(tempoTextBox.Text);
        }
    }
}
