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
using System.Diagnostics;
using NAudio.Wave.SampleProviders;

namespace NAudioSampleSequencerForms
{
    class PatternSequencer
    {
        private readonly Pattern pattern;
        public Samples samples;
        private int tempo, samplesPerStep;

        public PatternSequencer(Pattern pattern, Samples samples)
        {
            this.pattern = pattern;
            this.samples = samples;
            this.Tempo = 120;
        }

        public int Tempo
        {
            get
            {
                return this.tempo;
            }
            set
            {
                if (this.tempo != value)
                {
                    this.tempo = value;
                    this.newTempo = true;
                }
            }
        }

        private bool newTempo;
        private int currentStep = 0;
        private double patternPosition = 0;

        public IList<MusicSampleProvider> GetNextMixerInputs(int sampleCount)
        {
            List<MusicSampleProvider> mixerInputs = new List<MusicSampleProvider>();
            int samplePos = 0;
            if (newTempo)
            {
                int samplesPerBeat = (this.samples.WaveFormat.Channels * this.samples.WaveFormat.SampleRate * 60) / tempo;
                this.samplesPerStep = samplesPerBeat / 4;
                //patternPosition = 0;
                newTempo = false;
            }

            while (samplePos < sampleCount)
            {
                double offsetFromCurrent = (currentStep - patternPosition);
                if (offsetFromCurrent < 0) offsetFromCurrent += pattern.Steps;
                int delayForThisStep = (int)(this.samplesPerStep * offsetFromCurrent);
                if (delayForThisStep >= sampleCount)
                {
                    // don't queue up any samples beyond the requested time range
                    break;
                }

                for (int note = 0; note < pattern.Notes; note++)
                {
                    if (pattern[note, currentStep] != 0)
                    {
                        var sampleProvider = samples.GetSampleProvider(note);
                        sampleProvider.DelayBy = delayForThisStep;
                        Debug.WriteLine("beat at step {0}, patternPostion={1}, delayBy {2}", currentStep, patternPosition, delayForThisStep);
                        mixerInputs.Add(sampleProvider);
                    }
                }

                samplePos += samplesPerStep;
                currentStep++;
                currentStep = currentStep % pattern.Steps;
            }

            this.patternPosition += ((double)sampleCount / samplesPerStep);
            if (this.patternPosition > pattern.Steps)
            {
                this.patternPosition -= pattern.Steps;
            }
            return mixerInputs;
        }
    }
}
