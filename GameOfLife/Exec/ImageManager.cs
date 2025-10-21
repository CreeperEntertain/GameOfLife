using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace GameOfLife.Exec
{
    internal class ImageManager
    {
        public List<Image> image = [];
        private readonly Image fallbackImage = new(new Image<Rgba32>(16, 16));

        public ImageManager() { }
        public ImageManager(string imageReference, bool createOnFailure = true, bool printResult = false)
            => AddImage(imageReference, createOnFailure, printResult);
        public ImageManager(string[] imageReference, bool createOnFailure = true, bool printResult = false)
        {
            foreach (string index in imageReference)
                AddImage(index, createOnFailure, printResult);
        }

        public bool AddImage(string imageReference, bool createOnFailure = true, bool printResult = false)
        {
            bool isSuccessful = File.Exists(imageReference);
            string print = "";
            if (printResult)
                print += isSuccessful ? $"Image added." : "Image not found.";
            if (createOnFailure)
            {
                image.Add(isSuccessful ? new Image(imageReference) : fallbackImage);
                if (printResult)
                    print += " Creating empty 16x16 image instead.";
            }
            Console.Write(printResult ? print + "\n" : print);
            return isSuccessful;
        }

        public bool RemoveImage(int index, bool printResult = false)
        {
            bool isSuccessful = image.Remove(image[index]);
            if (printResult)
                Console.WriteLine(isSuccessful ? $"Successfully removed image {index}." : $"Failed to remove image {index}.");
            return isSuccessful;
        }

        public Image? GetImage(int index, bool printResult = false)
        {
            bool isSuccessful = image.Count > index;
            if (isSuccessful)
                return image[index];
            if (printResult)
                Console.WriteLine("Image does not exist.");
            return null;
        }

        public Image CreateImage(int width, int height)
        {
            Image addedImage = new(new Image<Rgba32>(width, height));
            image.Add(addedImage);
            return addedImage;
        }
    }
}