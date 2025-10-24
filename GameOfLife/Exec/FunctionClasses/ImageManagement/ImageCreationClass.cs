using GameOfLife.Exec.Utilities;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace GameOfLife.Exec.FunctionClasses.ImageManagement
{
    internal class ImageCreationClass
    {
        readonly ImageManagementClass imageManagement = new();
        readonly ImageDataClass imageData = new();

        public bool CheckDimensions(int[] providedScales)
        {
            int upperLimit = 127;
            foreach (int index in providedScales)
                if (index < 1 || index > upperLimit)
                {
                    Console.WriteLine("Image too large, too small, or no dimensions provided.");
                    return false;
                }
            return true;
        }
        public Image CreateImage(int width, int height, ref List<Image> image)
        {
            if (!CheckDimensions([width, height]))
                throw new ArgumentException($"Illegal image dimensions. ({width}x{height})");
            Image addedImage = new(new Image<Rgba32>(width, height));
            image.Add(addedImage);
            return addedImage;
        }
        public bool CreateImageFromUserInput(ref List<Image> image)
        {
            int[] providedScales;
            do
            {
                providedScales = UserInput.ProvideScales();
                if (providedScales.Length == 0)
                    return false;
            }
            while (!CheckDimensions(providedScales));
            CreateImage(providedScales[0], providedScales[1], ref image);

            return true;
        }
        public Image? CreateImageProcess(ref List<Image> imageList, bool printResult)
        {
            bool didCreateImage = CreateImageFromUserInput(ref imageList);
            if (didCreateImage)
            {
                Image? image = imageManagement.GetImage(ref imageList, 0, false);

                int[] imageDimensions = imageData.GetImageDimensions(ref imageList, 0, printResult);
                int width = imageDimensions[0];
                int height = imageDimensions[1];

                if (printResult)
                    Console.WriteLine($"The new image is {width}x{height} pixels large.");
                return image;
            }
            else if (printResult)
                Console.WriteLine("No image was created.");
            return null;
        }
    }
}