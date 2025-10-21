namespace GameOfLife.Exec.Structs
{
    internal struct HSV(int h = 0, float s = 0, float v = 0)
    {
        public int H { get; set; } = h;
        public float S { get; set; } = s;
        public float V { get; set; } = v;

        public override readonly string ToString()
        =>  $"H: {H}, " +
            $"S: {Math.Round(S, 2) * 100}%, " +
            $"V: {Math.Round(V, 2) * 100}%";
    }
}