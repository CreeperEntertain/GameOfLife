using GameOfLife.Exec.Structs;

namespace GameOfLife.Exec.Utilities.ImageManagement.ImageData
{
    internal static class RGBRetrieve
    {
        public static RGB[,] RGB2D(Image image)
        {
            Color[,] colorArray = image.pixel;
            RGB[,] rgbArray = new RGB[image.size[0], image.size[1]];
            for (int x = 0; x < colorArray.GetLength(0); x++)
                for (int y = 0; y < colorArray.GetLength(1); y++)
                    rgbArray[x, y] = colorArray[x, y].RGB;
            return rgbArray;
        }

        public static byte[,] Red2D(Image image)
        {
            Color[,] colorArray = image.pixel;
            byte[,] byteArray = new byte[image.size[0], image.size[1]];
            for (int x = 0; x < colorArray.GetLength(0); x++)
                for (int y = 0; y < colorArray.GetLength(1); y++)
                    byteArray[x, y] = colorArray[x, y].RGB.R;
            return byteArray;
        }
        public static byte[,] Green2D(Image image)
        {
            Color[,] colorArray = image.pixel;
            byte[,] byteArray = new byte[image.size[0], image.size[1]];
            for (int x = 0; x < colorArray.GetLength(0); x++)
                for (int y = 0; y < colorArray.GetLength(1); y++)
                    byteArray[x, y] = colorArray[x, y].RGB.G;
            return byteArray;
        }
        public static byte[,] Blue2D(Image image)
        {
            Color[,] colorArray = image.pixel;
            byte[,] byteArray = new byte[image.size[0], image.size[1]];
            for (int x = 0; x < colorArray.GetLength(0); x++)
                for (int y = 0; y < colorArray.GetLength(1); y++)
                    byteArray[x, y] = colorArray[x, y].RGB.B;
            return byteArray;
        }
    }
}