using GameOfLife.Exec.Enums;
using GameOfLife.Exec.Structs;

namespace GameOfLife.Exec.Utilities
{
    internal static class ConstructColorArray
    {
        private static Color[,] From2DArray<T, TChannel>(T[,] array, TChannel inputChannel, Action<int, int, Color[,], T[,], TChannel> resolver)
        {
            int xScale = array.GetLength(0);
            int yScale = array.GetLength(1);
            Color[,] colorArray = new Color[xScale, yScale];
            for (int x = 0; x < xScale; x++)
                for (int y = 0; y < yScale; y++)
                    resolver(x, y, colorArray, array, inputChannel);
            return colorArray;
        }

        public static Color[,] From2DByteArray(byte[,] byteArray, InputChannelsByte inputChannel) =>
            From2DArray(byteArray, inputChannel, ResolveByteChannelType);
        public static Color[,] From2DIntArray(int[,] intArray, InputChannelsInt inputChannel) =>
            From2DArray(intArray, inputChannel, ResolveIntChannelType);
        public static Color[,] From2DFloatArray(float[,] floatArray, InputChannelsFloat inputChannel) =>
            From2DArray(floatArray, inputChannel, ResolveFloatChannelType);

        private static readonly Dictionary<InputChannelsByte, InputChannelsRGB> ByteToRGBMap = new()
        {
            { InputChannelsByte.R, InputChannelsRGB.R },
            { InputChannelsByte.G, InputChannelsRGB.G },
            { InputChannelsByte.B, InputChannelsRGB.B }
        };
        private static readonly Dictionary<InputChannelsInt, InputChannelsHSV> IntToHSVMap = new()
        {
            { InputChannelsInt.H, InputChannelsHSV.H }
        };
        private static readonly Dictionary<InputChannelsFloat, InputChannelsHSV> FloatToHSVMap = new()
        {
            { InputChannelsFloat.S, InputChannelsHSV.S },
            { InputChannelsFloat.V, InputChannelsHSV.V }
        };
        private static readonly Dictionary<InputChannelsFloat, InputChannelsCMYK> FloatToCMYKMap = new()
        {
            { InputChannelsFloat.C, InputChannelsCMYK.C },
            { InputChannelsFloat.M, InputChannelsCMYK.M },
            { InputChannelsFloat.Y, InputChannelsCMYK.Y },
            { InputChannelsFloat.K, InputChannelsCMYK.K }
        };

        private static void ResolveByteChannelType(int x, int y, Color[,] colorArray, byte[,] byteArray, InputChannelsByte inputChannel)
        {
            if (!ByteToRGBMap.TryGetValue(inputChannel, out var rgbChannel))
                throw new ArgumentOutOfRangeException(nameof(inputChannel));
            colorArray[x, y] = new(new RGB(byteArray[x, y], rgbChannel));
        }
        private static void ResolveIntChannelType(int x, int y, Color[,] colorArray, int[,] intArray, InputChannelsInt inputChannel)
        {
            if (!IntToHSVMap.TryGetValue(inputChannel, out var hsvChannel))
                throw new ArgumentOutOfRangeException(nameof(inputChannel));
            colorArray[x, y] = new(new HSV(intArray[x, y], hsvChannel));
        }
        private static void ResolveFloatChannelType(int x, int y, Color[,] colorArray, float[,] floatArray, InputChannelsFloat inputChannel)
        {
            if (FloatToHSVMap.TryGetValue(inputChannel, out var hsvChannel))
                colorArray[x, y] = new(new HSV(floatArray[x, y], hsvChannel));
            else if (FloatToCMYKMap.TryGetValue(inputChannel, out var cmykChannel))
                colorArray[x, y] = new(new CMYK(floatArray[x, y], cmykChannel));
            else throw new ArgumentOutOfRangeException(nameof(inputChannel));
        }
    }
}