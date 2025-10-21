using GameOfLife.Exec.Utilities;

namespace GameOfLife.Exec
{
    internal class GameManager
    {
        public readonly ImageManager imageManager = new();
        public GameManager() => Init();

        private void Init()
        {
            ForcefulImageAddingBecauseFuckThePlayer(imageManager);
        }

        private void ForcefulImageAddingBecauseFuckThePlayer(ImageManager imageManager)
        {
            Image? image;
            bool imageExists;
            do
            {
                Console.Write("Drag and drop in an image, then hit enter: ");
                string providedPath = Console.ReadLine() ?? "";
                imageExists = imageManager.AddImage(providedPath, false);
                if (!imageExists)
                {
                    Console.Clear();
                    Console.WriteLine("Image does not exist, please provide one.");
                }
            } while (!imageExists);
            image = imageManager.GetImage(0);

            if (image != null)
                PrintImage.VolumeAbove(imageManager, image);
        }
    }
}