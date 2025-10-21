namespace GameOfLife.Exec.Structs
{
    internal struct CMYK(float c = 0, float m = 0, float y = 0, float k = 1)
    {
        public float C { get; set; } = c;
        public float M { get; set; } = m;
        public float Y { get; set; } = y;
        public float K { get; set; } = k;

        public override readonly string ToString()
        =>  $"C: {Math.Round(C, 2) * 100}%, " +
            $"M: {Math.Round(M, 2) * 100}%, " +
            $"Y: {Math.Round(Y, 2) * 100}%, " +
            $"K: {Math.Round(K, 2) * 100}%";
    }
}