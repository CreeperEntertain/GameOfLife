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
    }
}
