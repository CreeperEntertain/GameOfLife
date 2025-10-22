using GameOfLife.Exec.Structs;
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
                Simulate(image);
        }

        private void Simulate(Image image)
        {
            bool[,] thresholdArray = ThresholdChecks.Float2DGreater(imageManager.Volume2D(image), .5f);

            Grid grid = new(image.size);
            grid.SetStates(thresholdArray);
            PrintImage.FromBoolArray(grid.GetStates());
        }
    }
}