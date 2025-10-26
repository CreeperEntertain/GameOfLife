using GameOfLife.Exec.Utilities.Conversion;

namespace GameOfLife.Exec.Utilities
{
    internal static class PrintImage
    {
        private static char[] joinedThresholdChars = { '█', '▄', '▀', ' ' };
        private static string[] thresholdChars = { "██", "  " };

        private static ImageManager imageManager = new("");

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
        public static void FromColorArray(Structs.Color[,] colorArray, float volumeThreshold = .5f)
            => FromBoolArray(ThresholdChecks.Float2DGreater(imageManager.Volume2D(new Image(colorArray)), volumeThreshold));
        public static void FromImage(Image imageToPrint, float volumeThreshold = .5f)
            => FromBoolArray(ThresholdChecks.Float2DGreater(imageManager.Volume2D(imageToPrint), volumeThreshold));
        public static bool FromFrame(ImageManager imageManager, uint index)
        {
            Image? printedImage = imageManager.GetImage((int)index);
            if (printedImage != null)
                PrintImage.FromImage(printedImage.Value);
            else
                return false;
            return true;
        }

        private static void PrintBoolArray(bool[,] boolArray)
        {
            int xScale = boolArray.GetLength(0);
            int yScale = boolArray.GetLength(1);
            int halvedYScale = (int)Math.Ceiling(yScale / 2f);
            (bool, bool)[,] verticalBools = new (bool, bool)[xScale, halvedYScale];
            JoinVerticalBools(xScale, yScale, ref verticalBools, boolArray);
            for (int y = 0; y < halvedYScale; y++)
            {
                for (int x = 0; x < xScale; x++)
                    PrintJoinedThresholdChar(verticalBools[x, y]);
                Console.WriteLine();
            }
        }

        private static void JoinVerticalBools(int xScale, int yScale, ref (bool, bool)[,] verticalBools, bool[,] boolArray)
        {
            for (int x = 0; x < xScale; x++)
                for (int y = 0; y < yScale; y++)
                    if (y % 2 == 0)
                        verticalBools[x, y / 2].Item1 = boolArray[x, y];
                    else
                        verticalBools[x, y / 2].Item2 = boolArray[x, y];
        }

        private static void PrintThresholdChar(bool threshold)
            => Console.Write(threshold ? thresholdChars[0] : thresholdChars[1]);
        private static void PrintJoinedThresholdChar((bool, bool) verticalBoolean)
        {
            var (top, bottom) = verticalBoolean;
            if (top && bottom) Console.Write(joinedThresholdChars[0]);
            else if (!top && bottom) Console.Write(joinedThresholdChars[1]);
            else if (top && !bottom) Console.Write(joinedThresholdChars[2]);
            else Console.Write(joinedThresholdChars[3]);
        }
    }
}