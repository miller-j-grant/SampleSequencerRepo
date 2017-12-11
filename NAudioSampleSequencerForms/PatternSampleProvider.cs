/***************************************************************************************
    Title: NAudioWPFDemo Source Code
    Author: Mark Heath
    Date: November 4, 2017
    Availability: http://naudio.codeplex.com/SourceControl/latest#readme.txt
***************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NAudio.Wave;
using NAudio.Midi;
using NAudio.Wave.SampleProviders;

namespace NAudioSampleSequencerForms
{
    class PatternSampleProvider : ISampleProvider
    {
        private MixingSampleProvider mixer;
        private WaveFormat waveFormat;
        public PatternSequencer Sequencer { get; set; }
        public Samples Samples { get; set; }

        public PatternSampleProvider(Pattern pattern)
        {
            Samples = new Samples();
            this.Sequencer = new PatternSequencer(pattern, Samples);
            this.waveFormat = Samples.WaveFormat;
            mixer = new MixingSampleProvider(waveFormat);
        }

        public void Reset(Pattern pattern)
        {
            this.Sequencer = new PatternSequencer(pattern, Samples);
            this.waveFormat = Samples.WaveFormat;
            mixer = new MixingSampleProvider(waveFormat);
        }

        public int Tempo
        {
            get
            {
                return Sequencer.Tempo;
            }
            set
            {
                Sequencer.Tempo = value;
            }
        }

        public WaveFormat WaveFormat
        {
            get { return waveFormat; }
        }

        public int Read(float[] buffer, int offset, int count)
        {
            foreach (var mixerInput in Sequencer.GetNextMixerInputs(count))
            {
                mixer.AddMixerInput(mixerInput);
            }

            // now we just need to read from the mixer
            var samplesRead = mixer.Read(buffer, offset, count);
            while (samplesRead < count)
            {
                buffer[samplesRead++] = 0;
            }
            return samplesRead;
        }
    }
}
