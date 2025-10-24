using GameOfLife.Exec.Structs;
using GameOfLife.Exec.Utilities;

namespace GameOfLife.Exec.FunctionClasses.GameManagement
{
    internal class RunGame(List<ImageManager> imageManagers)
    {
        public void SimulateSingleGame(Image image, int imageManagerIndex)
        {
            bool[,] thresholdArray = ThresholdChecks.Float2DGreater(imageManagers[imageManagerIndex].Volume2D(image), .5f);

            Grid grid = new(image.size);
            grid.SetStates(thresholdArray);
            PrintImage.FromBoolArray(grid.GetStates());
            Console.ReadKey();
            Console.Clear();
            Console.CursorVisible = false;

            RunSim(grid, 125, 1);
        }

        public void RunSim(Grid grid, int simulationSteps, byte delayBetweenSteps)
        {
            for (int i = 0; i < simulationSteps; i++)
            {
                Console.SetCursorPosition(0, 0);
                grid.SimulateSteps(1);
                bool[,] gridState = grid.GetStates();
                PrintImage.FromBoolArray(gridState);
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