namespace GameOfLife.Exec.Structs
{
    internal struct HSV(int h = 0, float s = 0, float v = 0)
    {
        public int H = h;
        public float S = s;
        public float V = v;

        public override readonly string ToString()
        =>  $"H: {H}, " +
            $"S: {Math.Round(S, 2) * 100}%, " +
            $"V: {Math.Round(V, 2) * 100}%";
    }
}