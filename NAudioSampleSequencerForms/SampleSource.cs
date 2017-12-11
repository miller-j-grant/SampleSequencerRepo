/***************************************************************************************
    Title: NAudioWPFDemo Source Code
    Author: Mark Heath
    Date: November 4, 2017
    Availability: http://naudio.codeplex.com/SourceControl/latest#readme.txt
***************************************************************************************/

using System;
using NAudio.Wave;

namespace NAudioSampleSequencerForms
{
    class SampleSource
    {
        public static SampleSource CreateFromWaveFile(string fileName)
        {
            using (var reader = new WaveFileReader(fileName))
            {
                var sp = reader.ToSampleProvider();
                var sourceSamples = (int)(reader.Length / (reader.WaveFormat.BitsPerSample / 8));
                var sampleData = new float[sourceSamples];
                int n = sp.Read(sampleData, 0, sourceSamples);
                if (n != sourceSamples)
                {
                    throw new InvalidOperationException(String.Format("Couldn't read the whole sample, expected {0} samples, got {1}", n, sourceSamples));
                }
                var ss = new SampleSource(sampleData, sp.WaveFormat);
                return ss;
            }
        }

        public SampleSource(float[] sampleData, WaveFormat waveFormat) :
            this(sampleData, waveFormat, 0, sampleData.Length)
        {
        }

        public SampleSource(float[] sampleData, WaveFormat waveFormat, int startIndex, int length)
        {
            this.SampleData = sampleData;
            this.SampleWaveFormat = waveFormat;
            this.StartIndex = startIndex;
            this.Length = length;
        }

        // Sample data
        public float[] SampleData { get; private set; }

        // Format of sampleData
        public WaveFormat SampleWaveFormat { get; private set; }

        /// Index of the first sample to play
        public int StartIndex { get; private set; }

        /// Number of valid samples
        public int Length { get; private set; }
    }
}
