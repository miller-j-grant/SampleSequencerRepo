﻿/***************************************************************************************
    Title: NAudioWPFDemo Source Code
    Author: Mark Heath
    Date: November 4, 2017
    Availability: http://naudio.codeplex.com/SourceControl/latest#readme.txt
***************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAudioSampleSequencerForms
{
    public class Pattern
    {
        private byte[,] hits;
        private List<string> noteNames;

        public Pattern(IEnumerable<string> notes, int steps)
        {
            this.noteNames = new List<string>(notes);
            this.Steps = steps;
            hits = new byte[Notes, steps];
        }

        public int Steps { get; private set; }

        public int Notes
        {
            get { return noteNames.Count; }
        }

        public byte this[int note, int step]
        {
            get { return hits[note, step]; }
            set
            {
                if (hits[note, step] != value)
                {
                    hits[note, step] = value;
                    if (PatternChanged != null)
                    {
                        PatternChanged(this, EventArgs.Empty);
                    }
                }
            }
        }

        public event EventHandler PatternChanged;

        public IList<string> NoteNames { get { return this.noteNames.AsReadOnly(); } }
    }
}
