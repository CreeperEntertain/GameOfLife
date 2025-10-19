namespace GameOfLife.Exec.Structs
{
    internal struct CMYK
    {
        public float C { get; set; }
        public float M { get; set; }
        public float Y { get; set; }
        public float K { get; set; }

        public CMYK(float c = 0, float m = 0, float y = 0, float k = 0)
        {
            C = c;
            M = m;
            Y = y;
            K = k;
        }

        public override string ToString()
        =>  $"C: {Math.Round(C, 2) * 100}%, " +
            $"M: {Math.Round(M, 2) * 100}%, " +
            $"Y: {Math.Round(Y, 2) * 100}%, " +
            $"K: {Math.Round(K, 2) * 100}%";
    }
}