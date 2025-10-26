using GameOfLife.Exec.Structs;
using GameOfLife.Exec.Utilities.Conversion;
using GameOfLife.Exec.Utilities.IO;

namespace GameOfLife.Exec.Utilities.GameManagement
{
    internal static class Simulate
    {
        public static void SingleGame(Image image, List<ImageManager> imageManagers, int imageManagerIndex, bool addResultsToImageManager = true)
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
                Run(grid, imageManagers, 125, 1, imageManagerIndex);
            else
                Run(grid, imageManagers, 125, 1);
        }

        public static void Run(Grid grid, List<ImageManager> imageManagers, int simulationSteps, byte delayBetweenSteps, int? imageManagerIndex = null)
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
                    TextOut.WriteLine("\nSimulation cancelled.", ConsoleColor.Red);
                    return;
                }
                Thread.Sleep(delayBetweenSteps);
            }
            Console.CursorVisible = true;
            TextOut.WriteLine("Simulation done.", ConsoleColor.Green);
        }
    }
}