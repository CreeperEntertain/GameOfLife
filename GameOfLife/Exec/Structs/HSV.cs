namespace GameOfLife.Exec.Structs
{
    internal struct HSV
    {
        public byte H { get; set; }
        public byte S { get; set; }
        public byte V { get; set; }

        public HSV(byte h = 0, byte s = 0, byte v = 0)
        {
            H = h;
            S = s;
            V = v;
        }
    }
}