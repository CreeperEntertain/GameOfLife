namespace GameOfLife.Exec.Structs
{
    internal struct HSV
    {
        public int H { get; set; }
        public float S { get; set; }
        public float V { get; set; }

        public HSV(int h = 0, float s = 0, float v = 0)
        {
            H = h;
            S = s;
            V = v;
        }

        public override string ToString()
        =>  $"H: {H}, " +
            $"S: {Math.Round(S, 2) * 100}%, " +
            $"V: {Math.Round(V, 2) * 100}%";
    }
}