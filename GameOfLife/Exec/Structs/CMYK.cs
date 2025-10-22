using GameOfLife.Exec.Enums;

namespace GameOfLife.Exec.Structs
{
    internal struct CMYK
    {
        public float C;
        public float M;
        public float Y;
        public float K;

        public CMYK(float c = 0, float m = 0, float y = 0, float k = 1)
        {
            C = c;
            M = m;
            Y = y;
            K = k;
        }

        public CMYK(float singleChannel, InputChannelsCMYK inputChannel)
            => SetChannelFloat(singleChannel, inputChannel);
        private void SetChannelFloat(float value, InputChannelsCMYK channel)
        {
            C = M = Y = 0f;
            K = 1f;
            switch(channel)
            {
                case InputChannelsCMYK.C: C = value; break;
                case InputChannelsCMYK.M: M = value; break;
                case InputChannelsCMYK.Y: Y = value; break;
                case InputChannelsCMYK.K: K = value; break;
                default: throw new ArgumentException("Invalid type for channel", nameof(value));
            }
        }

        public override readonly string ToString()
        =>  $"C: {Math.Round(C, 2) * 100}%, " +
            $"M: {Math.Round(M, 2) * 100}%, " +
            $"Y: {Math.Round(Y, 2) * 100}%, " +
            $"K: {Math.Round(K, 2) * 100}%";
    }
}