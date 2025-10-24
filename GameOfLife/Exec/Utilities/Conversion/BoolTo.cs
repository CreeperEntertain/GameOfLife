namespace GameOfLife.Exec.Utilities.Conversion
{
    internal static class BoolTo
    {
        static int xScale;
        static int yScale;
        public static byte[,] Byte2D(bool[,] boolArray)
        {
            xScale = boolArray.GetLength(0);
            yScale = boolArray.GetLength(1);
            byte[,] byteArray = new byte[xScale, yScale];
            for (int x = 0; x < xScale; x++)
                for (int y = 0; y < yScale; y++)
                    byteArray[x, y] = boolArray[x, y] ? (byte)255 : (byte)0;
            return byteArray;
        }
        public static int[,] Int2D(bool[,] boolArray)
        {
            xScale = boolArray.GetLength(0);
            yScale = boolArray.GetLength(1);
            int[,] intArray = new int[xScale, yScale];
            for (int x = 0; x < xScale; x++)
                for (int y = 0; y < yScale; y++)
                    intArray[x, y] = boolArray[x, y] ? 359 : 0;
            return intArray;
        }
        public static float[,] Float2D(bool[,] boolArray)
        {
            xScale = boolArray.GetLength(0);
            yScale = boolArray.GetLength(1);
            float[,] floatArray = new float[xScale, yScale];
            for (int x = 0; x < xScale; x++)
                for (int y = 0; y < yScale; y++)
                    floatArray[x, y] = boolArray[x, y] ? 1f : 0f;
            return floatArray;
        }
    }
}