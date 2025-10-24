using GameOfLife.Exec.Structs;
using GameOfLife.Exec.Utilities;
using GameOfLife.Exec.Utilities.Conversion;
using GameOfLife.Exec.Utilities.IO;

namespace GameOfLife.Exec.Utilities.GameManagement
{
    internal class RunGame(List<ImageManager> imageManagers)
    {
        public void SimulateSingleGame(Image image, int imageManagerIndex, bool addResultsToImageManager = false)
        {
            ImageManager imageManager = imageManagers[imageManagerIndex];
            bool[,] thresholdArray = ThresholdChecks.Float2DGreater(imageManager.Volume2D(image), .5f);

            Grid grid = new(image.size);
            grid.SetStates(thresholdArray);
            PrintImage.FromBoolArray(grid.GetStates());
            Console.ReadKey();
            Console.Clear();
            Console.CursorVisible = false;

            if (addResultsToImageManager)
                RunSim(grid, 125, 1, imageManagerIndex);
            else
                RunSim(grid, 125, 1);

            Console.Write("Press any key to render frame 16");
            Console.ReadKey();
            PrintFrame(imageManager, 16);
        }

        public bool PrintFrame(ImageManager imageManager, uint index)
        {
            Image? printedImage = imageManager.GetImage((int)index);
            if (printedImage != null)
                PrintImage.FromImage(printedImage.Value);
            else
                return false;
            return true;
        }

        public void RunSim(Grid grid, int simulationSteps, byte delayBetweenSteps, int? imageManagerIndex = null)
        {
            for (int i = 0; i < simulationSteps; i++)
            {
                Console.SetCursorPosition(0, 0);
                grid.SimulateSteps(1);
                bool[,] gridState = grid.GetStates();
                PrintImage.FromBoolArray(gridState);
                if (imageManagerIndex != null)
                    imageManagers[imageManagerIndex.Value].AddImageDirectly(new Image(ConstructColorArray.From2DFloatArray(BoolTo.Float2D(gridState), Enums.InputChannelsFloat.V)));
                if (UserInput.IsKeyDown(ConsoleKey.Escape))
                {
                    Console.WriteLine("\nSimulation cancelled.");
                    return;
                }
                Thread.Sleep(delayBetweenSteps);
            }
            Console.CursorVisible = true;
            Console.WriteLine("Simulation done.");
        }
    }
}