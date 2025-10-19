using GameOfLife.Exec.Enums;

namespace GameOfLife.Exec.Structs
{
    internal struct RGB
    {

        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }

        public RGB(byte r = 0, byte g = 0, byte b = 0)
        {
            R = r;
            G = g;
            B = b;
        }

        public string Hex(bool upperCase = true, OutputChannels channel = OutputChannels.All)
        {
            switch (channel)
            {
                case OutputChannels.All: return upperCase ? $"#{R:X2}{G:X2}{B:X2}" : $"#{R:x2}{G:x2}{B:x2}";
                case OutputChannels.R: return upperCase ? $"{R:X2}" : $"{R:x2}";
                case OutputChannels.G: return upperCase ? $"{G:X2}" : $"{G:x2}";
                case OutputChannels.B: return upperCase ? $"{B:X2}" : $"{B:x2}";
                default: throw new ArgumentException("Invalid channel");
            }
        }

        public override string ToString()
        =>  $"R: {R}, " +
            $"G: {G}, " +
            $"B: {B}";
    }
}