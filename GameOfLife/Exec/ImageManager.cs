using GameOfLife.Exec.FunctionClasses.ImageManagement;
using GameOfLife.Exec.FunctionClasses.UserInput;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace GameOfLife.Exec
{
    internal class ImageManager
    {
        public List<Image> images = [];
        private readonly Image fallbackImage = new(new Image<Rgba32>(16, 16));

        public ImageManager() { }
        public ImageManager(string imageReference, bool createOnFailure = true, bool printResult = false)
            => AddImage(imageReference, createOnFailure, printResult);
        public ImageManager(string[] imageReference, bool createOnFailure = true, bool printResult = false)
        {
            foreach (string index in imageReference)
                AddImage(index, createOnFailure, printResult);
        }

        UserInputClass userInput = new();
        ImageCreationClass imageCreation = new();
        ImageManagementClass imageManagement = new();
        ImageDataClass imageData = new();

        public Image CreateImage(int width, int height)
            => imageCreation.CreateImage(width, height, ref images);
        public bool CheckDimensions(int[] dimensions)
            => imageCreation.CheckDimensions(dimensions);
        public bool CreateImageFromUserInput()
            => imageCreation.CreateImageFromUserInput(ref images, userInput);
        public Image? CreateImageProcess(bool printResult = true)
            => imageCreation.CreateImageProcess(ref images, printResult);

        public bool AddImage(string imageReference, bool createOnFailure = true, bool printResult = false)
            => imageManagement.AddImage(ref images, fallbackImage, imageReference, createOnFailure, printResult);
        public bool RemoveImage(int index, bool printResult = false)
            => imageManagement.RemoveImage(ref images, index, printResult);
        public Image? GetImage(int index, bool printResult = false)
            => imageManagement.GetImage(ref images, index, printResult);

        public int[] GetImageDimensions(int index, bool printResult = false)
            => imageData.GetImageDimensions(ref images, index, printResult);
    }
}