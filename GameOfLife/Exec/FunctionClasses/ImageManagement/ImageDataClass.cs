using GameOfLife.Exec.FunctionClasses.ImageManagement.ImageData;
using GameOfLife.Exec.Structs;

namespace GameOfLife.Exec.FunctionClasses.ImageManagement
{
    internal class ImageDataClass
    {
        readonly ImageManagementClass imageManagement = new();
        readonly RGBRetrieve rgbRetrieve = new();
        readonly HSVRetrieve hsvRetrieve = new();
        readonly CMYKRetrieve cmykRetrieve = new();

        public int[] GetImageDimensions(ref List<Image> imageList, int index, bool printResult)
        {
            Image? image = imageManagement.GetImage(ref imageList, index, printResult);
            if (image != null)
                return [image.size[0], image.size[1]];
            return [0, 0];
        }

        public RGB[,] RGB2D(Image image)
            => rgbRetrieve.RGB2D(image);
        public byte[,] Red2D(Image image)
            => rgbRetrieve.Red2D(image);
        public byte[,] Green2D(Image image)
            => rgbRetrieve.Green2D(image);
        public byte[,] Blue2D(Image image)
            => rgbRetrieve.Blue2D(image);

        public HSV[,] HSV2D(Image image)
            => hsvRetrieve.HSV2D(image);
        public int[,] Hue2D(Image image)
            => hsvRetrieve.Hue2D(image);
        public float[,] Saturation2D(Image image)
            => hsvRetrieve.Saturation2D(image);
        public float[,] Volume2D(Image image)
            => hsvRetrieve.Volume2D(image);

        public CMYK[,] CMYK2D(Image image)
            => cmykRetrieve.CMYK2D(image);
        public float[,] Cyan2D(Image image)
            => cmykRetrieve.Cyan2D(image);
        public float[,] Magenta2D(Image image)
            => cmykRetrieve.Magenta2D(image);
        public float[,] Yellow2D(Image image)
            => cmykRetrieve.Yellow2D(image);
        public float[,] Key2D(Image image)
            => cmykRetrieve.Key2D(image);
    }
}