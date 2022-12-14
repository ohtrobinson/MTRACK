namespace libmtrack.Tracker;

public struct Sample
{
    public byte[] Data;
    public bool Stereo;
    public bool SixteenBit;
    public uint SampleRate;
    public uint DataLengthInSamples;

    public float Multiplier;

    public bool Loop;
    public uint LoopStart;
    public uint LoopEnd;

    public bool Unsigned;
    public bool UseAlternativeStereoMethod;

    public Sample(byte[] data, bool stereo, bool sixteenBit, uint sampleRate, bool loop, uint loopStart = 0, int loopEnd = -1, bool unsigned = false, bool useAlternativeStereoMethod = false)
    {
        Data = data;
        Stereo = stereo;
        SixteenBit = sixteenBit;
        SampleRate = sampleRate;
        DataLengthInSamples = (uint) (data.Length / (stereo ? 2 : 1) / (sixteenBit ? 2 : 1));
        Multiplier = sampleRate / TrackPlayer.CalculateSampleRate(PianoKey.C, Octave.Octave5, sampleRate, 1);
        Loop = loop;
        LoopStart = loopStart;
        LoopEnd = loopEnd == -1 ? DataLengthInSamples : (uint) loopEnd;
        Unsigned = unsigned;
        UseAlternativeStereoMethod = useAlternativeStereoMethod;
        
        Console.WriteLine(DataLengthInSamples);
    }
}