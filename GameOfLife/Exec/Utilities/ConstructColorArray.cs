using GameOfLife.Exec.Enums;
using GameOfLife.Exec.Structs;

namespace GameOfLife.Exec.Utilities
{
    internal static class ConstructColorArray
    {
        public static Color[,] From2DByteArray(byte[,] byteArray, InputChannelsByte inputChannel)
        {
            int xScale = byteArray.GetLength(0);
            int yScale = byteArray.GetLength(1);
            Color[,] colorArray = new Color[xScale, yScale];
            for (int x = 0; x < xScale; x++)
                for (int y = 0; y < yScale; y++)
                    ResolveByteChannelType(x, y, ref colorArray, byteArray, inputChannel);
            return colorArray;
        }
        public static Color[,] From2DIntArray(int[,] intArray, InputChannelsInt inputChannel)
        {
            int xScale = intArray.GetLength(0);
            int yScale = intArray.GetLength(1);
            Color[,] colorArray = new Color[xScale, yScale];
            for (int x = 0; x < xScale; x++)
                for (int y = 0; y < yScale; y++)
                    ResolveIntChannelType(x, y, ref colorArray, intArray, inputChannel);
            return colorArray;
        }
        public static Color[,] From2DFloatArray(float[,] floatArray, InputChannelsFloat inputChannel)
        {
            int xScale = floatArray.GetLength(0);
            int yScale = floatArray.GetLength(1);
            Color[,] colorArray = new Color[xScale, yScale];
            for (int x = 0; x < xScale; x++)
                for (int y = 0; y < yScale; y++)
                    ResolveFloatChannelType(x, y, ref colorArray, floatArray, inputChannel);
            return colorArray;
        }

        private static void ResolveByteChannelType(int x, int y, ref Color[,] colorArray, byte[,] byteArray, InputChannelsByte inputChannel)
        {
            if (Enum.IsDefined(typeof(InputChannelsRGB), inputChannel))
                colorArray[x, y] = new(new RGB(byteArray[x, y], (InputChannelsRGB)inputChannel));
        }
        private static void ResolveIntChannelType(int x, int y, ref Color[,] colorArray, int[,] intArray, InputChannelsInt inputChannel)
        {
            if (Enum.IsDefined(typeof(InputChannelsHSV), inputChannel))
                colorArray[x, y] = new(new HSV(intArray[x, y], (InputChannelsHSV)inputChannel));
        }
        private static void ResolveFloatChannelType(int x, int y, ref Color[,] colorArray, float[,] floatArray, InputChannelsFloat inputChannel)
        {
            if (Enum.IsDefined(typeof(InputChannelsHSV), inputChannel))
                colorArray[x, y] = new(new HSV(floatArray[x, y], (InputChannelsHSV)inputChannel));
            if (Enum.IsDefined(typeof(InputChannelsCMYK), inputChannel))
                colorArray[x, y] = new(new CMYK(floatArray[x, y], (InputChannelsCMYK)inputChannel));
        }
    }
}