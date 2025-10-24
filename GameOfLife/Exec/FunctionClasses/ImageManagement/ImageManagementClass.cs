namespace GameOfLife.Exec.FunctionClasses.ImageManagement
{
    internal class ImageManagementClass
    {
        public bool AddImage(ref List<Image> image, Image fallbackImage, string imageReference, bool createOnFailure = true, bool printResult = false)
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
            Console.Write(printResult ? print + "\n" : print);
            return isSuccessful;
        }
        public bool AddImageDirectly(ref List<Image> image, Image imageToAdd, bool printResult = false)
        {
            int imageListLength = image.Count;
            image.Add(imageToAdd);
            bool succeeded = imageListLength == image.Count;
            Console.Write
            (
                printResult
                ? succeeded
                    ? "Failed to add image.\n"
                    : "Successfully added image.\n"
                : ""
            );
            return succeeded ? true : false;
        }

        public bool RemoveImage(ref List<Image> image, int index, bool printResult = false)
        {
            bool isSuccessful = image.Remove(image[index]);
            if (printResult)
                Console.WriteLine(isSuccessful ? $"Successfully removed image {index}." : $"Failed to remove image {index}.");
            return isSuccessful;
        }
        public Image? GetImage(ref List<Image> image, int index, bool printResult = false)
        {
            bool isSuccessful = image.Count > index;
            if (isSuccessful)
                return image[index];
            if (printResult)
                Console.WriteLine("Image does not exist.");
            return null;
        }
    }
}