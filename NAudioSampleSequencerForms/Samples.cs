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
        private List<SampleSource> sampleSources;
        private WaveFormat waveFormat;
        private List<string> filePaths;

        public Samples()
        {
            SampleSource kickSample = SampleSource.CreateFromWaveFile("D:/VS Workspace/NAudioSampleSequencerForms/NAudioSampleSequencerForms/Samples/kick-trimmed.wav");
            SampleSource snareSample = SampleSource.CreateFromWaveFile("D:/VS Workspace/NAudioSampleSequencerForms/NAudioSampleSequencerForms/Samples/snare-trimmed.wav");
            SampleSource closedHatsSample = SampleSource.CreateFromWaveFile("D:/VS Workspace/NAudioSampleSequencerForms/NAudioSampleSequencerForms/Samples/closed-hat-trimmed.wav");
            SampleSource openHatsSample = SampleSource.CreateFromWaveFile("D:/VS Workspace/NAudioSampleSequencerForms/NAudioSampleSequencerForms/Samples/open-hat-trimmed.wav");
            sampleSources = new List<SampleSource>();
            filePaths = new List<string>();

            filePaths.Add("D:/VS Workspace/NAudioSampleSequencerForms/NAudioSampleSequencerForms/Samples/kick-trimmed.wav");
            filePaths.Add("D:/VS Workspace/NAudioSampleSequencerForms/NAudioSampleSequencerForms/Samples/snare-trimmed.wav");
            filePaths.Add("D:/VS Workspace/NAudioSampleSequencerForms/NAudioSampleSequencerForms/Samples/closed-hat-trimmed.wav");
            filePaths.Add("D:/VS Workspace/NAudioSampleSequencerForms/NAudioSampleSequencerForms/Samples/open-hat-trimmed.wav");

            sampleSources.Add(kickSample);
            sampleSources.Add(snareSample);
            sampleSources.Add(closedHatsSample);
            sampleSources.Add(openHatsSample);
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

        public string GetFilePath(int sampleNum)
        {
            return filePaths[sampleNum];
        }

        public void AddNewSample(string filepath)
        {
            SampleSource newSample = SampleSource.CreateFromWaveFile(filepath);
            sampleSources.Add(newSample);
            filePaths.Add(filepath);
        }
    }
}
