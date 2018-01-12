/***************************************************************************************
    Title: NAudioWPFDemo Source Code (originally DrumKit.cs)
    Author: Mark Heath
    Date: November 4, 2017
    Availability: http://naudio.codeplex.com/SourceControl/latest#readme.txt
***************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace NAudioSampleSequencerForms
{
    class Samples
    {
        public List<SampleSource> sampleSources { get; set; }
        public WaveFormat waveFormat { get; set; }
        public List<string> FilePaths { get; set; }
        public int Channels { get; set; }

        public Samples()
        {
            SampleSource kickSample = SampleSource.CreateFromWaveFile("D:/VS Workspace/NAudioSampleSequencerForms/NAudioSampleSequencerForms/Samples/kick-trimmed.wav");
            SampleSource snareSample = SampleSource.CreateFromWaveFile("D:/VS Workspace/NAudioSampleSequencerForms/NAudioSampleSequencerForms/Samples/snare-trimmed.wav");
            SampleSource closedHatsSample = SampleSource.CreateFromWaveFile("D:/VS Workspace/NAudioSampleSequencerForms/NAudioSampleSequencerForms/Samples/closed-hat-trimmed.wav");
            SampleSource openHatsSample = SampleSource.CreateFromWaveFile("D:/VS Workspace/NAudioSampleSequencerForms/NAudioSampleSequencerForms/Samples/open-hat-trimmed.wav");
            sampleSources = new List<SampleSource>();
            FilePaths = new List<string>();

            FilePaths.Add("D:\\VS Workspace\\NAudioSampleSequencerForms\\NAudioSampleSequencerForms\\Samples\\kick-trimmed.wav");
            FilePaths.Add("D:\\VS Workspace\\NAudioSampleSequencerForms\\NAudioSampleSequencerForms\\Samples\\snare-trimmed.wav");
            FilePaths.Add("D:\\VS Workspace\\NAudioSampleSequencerForms\\NAudioSampleSequencerForms\\Samples\\closed-hat-trimmed.wav");
            FilePaths.Add("D:\\VS Workspace\\NAudioSampleSequencerForms\\NAudioSampleSequencerForms\\Samples\\open-hat-trimmed.wav");

            sampleSources.Add(kickSample);
            sampleSources.Add(snareSample);
            sampleSources.Add(closedHatsSample);
            sampleSources.Add(openHatsSample);

            Channels = 4;
            this.waveFormat = WaveFormat.CreateIeeeFloatWaveFormat(openHatsSample.SampleWaveFormat.SampleRate, openHatsSample.SampleWaveFormat.Channels);
        }

        public virtual WaveFormat WaveFormat
        {
            get { return waveFormat; }
        }

        public MusicSampleProvider GetSampleProvider(int note)
        {
            return new MusicSampleProvider(this.sampleSources[note]);
        }

        public void AddNewSample(string filepath)
        {
            SampleSource newSample = SampleSource.CreateFromWaveFile(filepath);
            sampleSources.Add(newSample);
            FilePaths.Add(filepath);
            Channels++;
        }

        public void setSample(string filepath, int i)
        {
            SampleSource sample = SampleSource.CreateFromWaveFile(filepath);
            sampleSources[i] = sample;
            FilePaths[i] = filepath;
        }
    }
}
