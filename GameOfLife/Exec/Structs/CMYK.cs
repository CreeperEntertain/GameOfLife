namespace GameOfLife.Exec.Structs
{
    internal struct CMYK
    {
        public byte C { get; set; }
        public byte M { get; set; }
        public byte Y { get; set; }
        public byte K { get; set; }

        public CMYK(byte c = 0, byte m = 0, byte y = 0, byte k = 0)
        {
            C = c;
            M = m;
            Y = y;
            K = k;
        }
    }
}