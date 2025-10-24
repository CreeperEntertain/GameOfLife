using GameOfLife.Exec.Structs;

namespace GameOfLife.Exec.Utilities.ImageRelated.ColorData
{
    internal static class CMYKRetrieve
    {
        public static CMYK[,] CMYK2D(Image image)
        {
            Color[,] colorArray = image.pixel;
            CMYK[,] cmykArray = new CMYK[image.size[0], image.size[1]];
            for (int x = 0; x < colorArray.GetLength(0); x++)
                for (int y = 0; y < colorArray.GetLength(1); y++)
                    cmykArray[x, y] = colorArray[x, y].CMYK;
            return cmykArray;
        }

        public static float[,] Cyan2D(Image image)
        {
            Color[,] colorArray = image.pixel;
            float[,] floatArray = new float[image.size[0], image.size[1]];
            for (int x = 0; x < colorArray.GetLength(0); x++)
                for (int y = 0; y < colorArray.GetLength(1); y++)
                    floatArray[x, y] = colorArray[x, y].CMYK.C;
            return floatArray;
        }
        public static float[,] Magenta2D(Image image)
        {
            Color[,] colorArray = image.pixel;
        float[,] floatArray = new float[image.size[0], image.size[1]];
            for (int x = 0; x<colorArray.GetLength(0); x++)
                for (int y = 0; y<colorArray.GetLength(1); y++)
                    floatArray[x, y] = colorArray[x, y].CMYK.M;
            return floatArray;
        }
        public static float[,] Yellow2D(Image image)
        {
            Color[,] colorArray = image.pixel;
            float[,] floatArray = new float[image.size[0], image.size[1]];
            for (int x = 0; x < colorArray.GetLength(0); x++)
                for (int y = 0; y < colorArray.GetLength(1); y++)
                    floatArray[x, y] = colorArray[x, y].CMYK.Y;
            return floatArray;
        }
        public static float[,] Key2D(Image image)
        {
            Color[,] colorArray = image.pixel;
            float[,] floatArray = new float[image.size[0], image.size[1]];
            for (int x = 0; x < colorArray.GetLength(0); x++)
                for (int y = 0; y < colorArray.GetLength(1); y++)
                    floatArray[x, y] = colorArray[x, y].CMYK.K;
            return floatArray;
        }
    }
}
