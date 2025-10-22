namespace GameOfLife.Exec.Utilities
{
    internal static class PrintImage
    {
        private static string[] thresholdChars = { "██", "  " };

        public static void VolumeAbove(ImageManager imageManager, Image image, float threshold = .5f, bool belowInstead = false)
        {
            bool[,] thresholdArray;
            if (!belowInstead)
                thresholdArray = ThresholdChecks.Float2DGreater(imageManager.Volume2D(image), threshold);
            else
                thresholdArray = ThresholdChecks.Float2DLower(imageManager.Volume2D(image), threshold);
            PrintBoolArray(thresholdArray);
        }
        public static void FromBoolArray(bool[,] boolArray)
            => PrintBoolArray(boolArray);

        private static void PrintBoolArray(bool[,] boolArray)
        {
            for (int y = 0; y < boolArray.GetLength(1); y++)
            {
                for (int x = 0; x < boolArray.GetLength(0); x++)
                    PrintThresholdChar(boolArray[x, y]);
                Console.WriteLine();
            }
        }

        private static void PrintThresholdChar(bool boolean)
            => Console.Write($"{(boolean ? thresholdChars[0] : thresholdChars[1])}");
    }
}