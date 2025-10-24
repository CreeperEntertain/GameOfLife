using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace GameOfLife.Exec.Utilities.BuildArray
{
    internal static class PixelAsRGBClass
    {
        public static Structs.Color[,] Exec(int[] size, Image<Rgba32> image)
        {
            int width = size[0];
            int height = size[1];
            Structs.Color[,] rgbArrayOut = new Structs.Color[width, height];
            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                {
                    var pixel = image[x, y];
                    rgbArrayOut[x, y] = new Structs.Color(pixel.R, pixel.G, pixel.B);
                }
            return rgbArrayOut;
        }
    }
}