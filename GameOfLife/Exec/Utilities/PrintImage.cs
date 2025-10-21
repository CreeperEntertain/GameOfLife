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
            for (int y = 0; y < thresholdArray.GetLength(1); y++)
            {
                for (int x = 0; x < thresholdArray.GetLength(0); x++)
                    PrintThresholdChar(thresholdArray[x, y]);
                Console.WriteLine();
            }
        }

        private static void PrintThresholdChar(bool boolean)
            => Console.Write($"{(boolean ? thresholdChars[0] : thresholdChars[1])}");
    }
}