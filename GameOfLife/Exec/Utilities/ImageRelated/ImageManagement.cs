using GameOfLife.Exec.Utilities.IO;

namespace GameOfLife.Exec.Utilities.ImageRelated
{
    internal static class ImageManagement
    {
        public static bool AddImage(ref List<Image> image, Image fallbackImage, string imageReference, bool createOnFailure = true, bool printResult = false)
        {
            imageReference = imageReference.Replace("\"", "");
            bool isSuccessful = File.Exists(imageReference);
            string print = "";
            if (printResult)
                print += isSuccessful ? $"Image added." : "Image not found.";
            if (isSuccessful)
                image.Add(new Image(imageReference));
            if (createOnFailure)
            {
                image.Add(isSuccessful ? new Image(imageReference) : fallbackImage);
                if (printResult)
                    print += " Creating empty 16x16 image instead.";
            }
            TextOut.Write(printResult ? print + "\n" : print, ConsoleColor.Yellow);
            return isSuccessful;
        }
        public static bool AddImageDirectly(ref List<Image> image, Image imageToAdd, bool printResult = false)
        {
            int imageListLength = image.Count;
            image.Add(imageToAdd);
            bool succeeded = imageListLength != image.Count;
            if (printResult)
                if (succeeded)
                    TextOut.WriteLine("Successfully added image.", ConsoleColor.Green);
                else
                    TextOut.WriteLine("Failed to add image.", ConsoleColor.Red);
            return succeeded;
        }

        public static bool RemoveImage(ref List<Image> image, int index, bool printResult = false)
        {
            bool isSuccessful = image.Remove(image[index]);
            if (printResult)
                if (isSuccessful)
                {
                    TextOut.Write("Successfully removed image [", ConsoleColor.Green);
                    TextOut.Write(index, ConsoleColor.Yellow);
                    TextOut.WriteLine("].", ConsoleColor.Green);
                }
                else
                {
                    TextOut.Write("Failed to remove image [", ConsoleColor.Red);
                    TextOut.Write(index, ConsoleColor.Yellow);
                    TextOut.WriteLine("].", ConsoleColor.Red);
                }
            return isSuccessful;
        }
        public static Image? GetImage(ref List<Image> image, int index, bool printResult = false)
        {
            bool isSuccessful = image.Count > index;
            if (isSuccessful)
                return image[index];
            if (printResult)
                TextOut.WriteLine("Image does not exist.", ConsoleColor.Red);
            return null;
        }
    }
}