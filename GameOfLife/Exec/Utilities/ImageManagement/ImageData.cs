using GameOfLife.Exec.Structs;

namespace GameOfLife.Exec.Utilities.ImageManagement.ImageData
{
    internal static class ImageData
    {
        public static int[] GetImageDimensions(ref List<Image> imageList, int index, bool printResult)
        {
            Image? image = Utilities.ImageManagement.ImageManagement.GetImage(ref imageList, index, printResult);
            if (image != null)
                return [image.Value.size[0], image.Value.size[1]];
            return [0, 0];
        }

        public static RGB[,] RGB2D(Image image)
            => RGBRetrieve.RGB2D(image);
        public static byte[,] Red2D(Image image)
            => RGBRetrieve.Red2D(image);
        public static byte[,] Green2D(Image image)
            => RGBRetrieve.Green2D(image);
        public static byte[,] Blue2D(Image image)
            => RGBRetrieve.Blue2D(image);

        public static HSV[,] HSV2D(Image image)
            => HSVRetrieve.HSV2D(image);
        public static int[,] Hue2D(Image image)
            => HSVRetrieve.Hue2D(image);
        public static float[,] Saturation2D(Image image)
            => HSVRetrieve.Saturation2D(image);
        public static float[,] Volume2D(Image image)
            => HSVRetrieve.Volume2D(image);

        public static CMYK[,] CMYK2D(Image image)
            => CMYKRetrieve.CMYK2D(image);
        public static float[,] Cyan2D(Image image)
            => CMYKRetrieve.Cyan2D(image);
        public static float[,] Magenta2D(Image image)
            => CMYKRetrieve.Magenta2D(image);
        public static float[,] Yellow2D(Image image)
            => CMYKRetrieve.Yellow2D(image);
        public static float[,] Key2D(Image image)
            => CMYKRetrieve.Key2D(image);
    }
}