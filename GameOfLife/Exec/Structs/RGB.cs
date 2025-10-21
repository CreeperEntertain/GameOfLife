using GameOfLife.Exec.Enums;
using System.Globalization;

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
        public RGB(string hexCode)
        {
            ReadOnlySpan<char> span = hexCode.StartsWith('#') ? hexCode.AsSpan(1) : hexCode.AsSpan();

            if (span.Length != 6)
                throw new ArgumentException("hexCode must have exactly 6 hex digits after optional '#'.", nameof(hexCode));

            for (int i = 0; i < 6; i++)
                if (!Uri.IsHexDigit(span[i]))
                    throw new ArgumentException("hexCode must contain only hex digits.", nameof(hexCode));

            R = byte.Parse(span.Slice(0, 2), NumberStyles.HexNumber);
            G = byte.Parse(span.Slice(2, 2), NumberStyles.HexNumber);
            B = byte.Parse(span.Slice(4, 2), NumberStyles.HexNumber);
        }

        public readonly string Hex(bool upperCase = true, OutputChannels channel = OutputChannels.All)
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

        public override readonly string ToString()
        =>  $"R: {R}, " +
            $"G: {G}, " +
            $"B: {B} | " +
            $"{Hex()}";
    }
}