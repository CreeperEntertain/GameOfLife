namespace GameOfLife.Exec.Utilities
{
    internal static class ThresholdChecks
    {
        public static bool[,] Float2DGreater(float[,] floatArray, float threshold)
        {
            bool[,] boolArray = new bool[floatArray.GetLength(0), floatArray.GetLength(1)];
            for (int x = 0; x < floatArray.GetLength(0); x++)
                for (int y = 0; y < floatArray.GetLength(1); y++)
                    boolArray[x, y] = floatArray[x, y] > threshold;
            return boolArray;
        }
        public static bool[,] Float2DLower(float[,] floatArray, float threshold)
        {
            bool[,] boolArray = new bool[floatArray.GetLength(0), floatArray.GetLength(1)];
            for (int x = 0; x < floatArray.GetLength(0); x++)
                for (int y = 0; y < floatArray.GetLength(1); y++)
                    boolArray[x, y] = floatArray[x, y] < threshold;
            return boolArray;
        }

        public static bool[,] Byte2DGreater(byte[,] byteArray, float threshold)
        {
            bool[,] boolArray = new bool[byteArray.GetLength(0), byteArray.GetLength(1)];
            for (int x = 0; x < byteArray.GetLength(0); x++)
                for (int y = 0; y < byteArray.GetLength(1); y++)
                    boolArray[x, y] = byteArray[x, y] > threshold;
            return boolArray;
        }
        public static bool[,] Byte2DLower(byte[,] byteArray, float threshold)
        {
            bool[,] boolArray = new bool[byteArray.GetLength(0), byteArray.GetLength(1)];
            for (int x = 0; x < byteArray.GetLength(0); x++)
                for (int y = 0; y < byteArray.GetLength(1); y++)
                    boolArray[x, y] = byteArray[x, y] < threshold;
            return boolArray;
        }

        public static bool[,] Int2DGreater(int[,] intArray, float threshold)
        {
            bool[,] boolArray = new bool[intArray.GetLength(0), intArray.GetLength(1)];
            for (int x = 0; x < intArray.GetLength(0); x++)
                for (int y = 0; y < intArray.GetLength(1); y++)
                    boolArray[x, y] = intArray[x, y] > threshold;
            return boolArray;
        }
        public static bool[,] Int2DLower(int[,] intArray, float threshold)
        {
            bool[,] boolArray = new bool[intArray.GetLength(0), intArray.GetLength(1)];
            for (int x = 0; x < intArray.GetLength(0); x++)
                for (int y = 0; y < intArray.GetLength(1); y++)
                    boolArray[x, y] = intArray[x, y] < threshold;
            return boolArray;
        }
    }
}