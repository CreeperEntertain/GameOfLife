using GameOfLife.Exec.Enums;

namespace GameOfLife.Exec.Structs
{
    internal struct HSV
    {
        public int H;
        public float S;
        public float V;

        public HSV(int h = 0, float s = 0, float v = 0)
        {
            H = h;
            S = s;
            V = v;
        }

        public HSV(int singleChannel, InputChannelsHSV inputChannel)
            => SetChannelInt(singleChannel, inputChannel);
        public HSV(float singleChannel, InputChannelsHSV inputChannel)
            => SetChannelFloat(singleChannel, inputChannel);
        private void SetChannelInt(int value, InputChannelsHSV channel)
        {
            ResetChannels();
            H = channel switch
            {
                InputChannelsHSV.H => value,
                _ => throw new ArgumentException("Invalid type for channel", nameof(value)),
            };
        }
        private void SetChannelFloat(float value, InputChannelsHSV channel)
        {
            ResetChannels();
            switch (channel)
            {
                case InputChannelsHSV.S: S = value; break;
                case InputChannelsHSV.V: V = value; break;
                default: throw new ArgumentException("Invalid type for channel", nameof(value));
            }
        }
        private void ResetChannels()
        {
            H = 0;
            S = V = 0f;
        }

        public override readonly string ToString()
        =>  $"H: {H}°, " +
            $"S: {Math.Round(S, 2) * 100}%, " +
            $"V: {Math.Round(V, 2) * 100}%";
    }
}