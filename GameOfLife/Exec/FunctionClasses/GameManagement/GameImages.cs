namespace GameOfLife.Exec.FunctionClasses.GameManagement
{
    internal class GameImages
    {
        public Image? ImageAdding(ImageManager imageManager, bool cancellable = true)
        {
            Image? image;
            bool imageExists;
            do
            {
                InstructionText(cancellable);
                string providedPath = Console.ReadLine() ?? "";
                if (cancellable && providedPath.ToLower() == "cancel")
                    return null;
                imageExists = imageManager.AddImage(providedPath);
                if (!imageExists)
                {
                    Console.Clear();
                    Console.WriteLine("Image does not exist, please provide one.");
                }
            } while (!imageExists);
            image = imageManager.GetImage(0);

            if (image != null)
                return image;
            throw new Exception("Provided image ended up being null.");
        }

        private static void InstructionText(bool cancellable)
            => Console.Write(InstructionString(cancellable));
        private static string InstructionString(bool cancellable)
            => cancellable
            ? "Drag and drop in an image, then hit enter.\nAlternatively, type 'cancel' to cancel: "
            : "Drag and drop in an image, then hit enter: ";
    }
}