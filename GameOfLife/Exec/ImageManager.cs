using GameOfLife.Exec.Utilities.ImageRelated;
using GameOfLife.Exec.Structs;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace GameOfLife.Exec
{
    internal class ImageManager
    {
        public List<Image> images = [];
        public readonly int ID = new Random().Next();
        public string name;
        private readonly Image fallbackImage = new(new Image<Rgba32>(16, 16));

        public ImageManager(string name)
            => this.name = name;
        public ImageManager(string name, string imageReference, bool createOnFailure = true, bool printResult = false)
        {
            this.name = name;
            AddImage(imageReference, createOnFailure, printResult);
        }
        public ImageManager(string name, string[] imageReference, bool createOnFailure = true, bool printResult = false)
        {
            this.name = name;
            foreach (string index in imageReference)
                AddImage(index, createOnFailure, printResult);
        }

        public Image CreateImage(int width, int height)
            => ImageCreation.CreateImage(width, height, ref images);
        public bool CheckDimensions(int[] dimensions)
            => ImageCreation.CheckDimensions(dimensions);
        public bool CreateImageFromUserInput()
            => ImageCreation.CreateImageFromUserInput(ref images);
        public Image? CreateImageProcess(bool printResult = true)
            => ImageCreation.CreateImageProcess(ref images, printResult);

        public bool AddImage(string imageReference, bool createOnFailure = true, bool printResult = false)
            => ImageManagement.AddImage(ref images, fallbackImage, imageReference, createOnFailure, printResult);
        public bool AddImageDirectly(Image imageToAdd, bool printResult = false)
            => ImageManagement.AddImageDirectly(ref images, imageToAdd, printResult);
        public bool RemoveImage(int index, bool printResult = false)
            => ImageManagement.RemoveImage(ref images, index, printResult);
        public Image? GetImage(int index, bool printResult = false)
            => ImageManagement.GetImage(ref images, index, printResult);

        public int[] GetImageDimensions(int index, bool printResult = false)
            => ImageData.GetImageDimensions(ref images, index, printResult);
        public RGB[,] RGB2D(Image image)
            => ImageData.RGB2D(image);
        public byte[,] Red2D(Image image)
            => ImageData.Red2D(image);
        public byte[,] Green2D(Image image)
            => ImageData.Green2D(image);
        public byte[,] Blue2D(Image image)
            => ImageData.Blue2D(image);
        public HSV[,] HSV2D(Image image)
            => ImageData.HSV2D(image);
        public int[,] Hue2D(Image image)
            => ImageData.Hue2D(image);
        public float[,] Saturation2D(Image image)
            => ImageData.Saturation2D(image);
        public float[,] Volume2D(Image image)
            => ImageData.Volume2D(image);
        public CMYK[,] CMYK2D(Image image)
            => ImageData.CMYK2D(image);
        public float[,] Cyan2D(Image image)
            => ImageData.Cyan2D(image);
        public float[,] Magenta2D(Image image)
            => ImageData.Magenta2D(image);
        public float[,] Yellow2D(Image image)
            => ImageData.Yellow2D(image);
        public float[,] Key2D(Image image)
            => ImageData.Key2D(image);

        public override string ToString()
            => images.Count() == 1 ? $"There is 1 image in list [{ID}]." : $"There are {images.Count()} images in list [{ID}].";
    }
}