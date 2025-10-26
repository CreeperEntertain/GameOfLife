using GameOfLife.Exec.Structs;
using GameOfLife.Exec.Utilities;
using GameOfLife.Exec.Utilities.GameManagement;

namespace GameOfLife.Exec
{
    internal class RunGame(List<ImageManager> imageManagers)
    {
        public void SimulateSingleGame(Image image, int imageManagerIndex, bool addResultsToImageManager = false)
            => Simulate.SingleGame(image, imageManagers, imageManagerIndex, addResultsToImageManager);
        public void RunSim(Grid grid, int simulationSteps, byte delayBetweenSteps, int? imageManagerIndex = null)
            => Simulate.Run(grid, imageManagers, simulationSteps, delayBetweenSteps, imageManagerIndex);

        public bool RenameImageManager(uint index, string name, bool printResult = false)
            => ImageManagerHandling.RenameImageManager(imageManagers, index, name, printResult);

        public bool PrintFrame(ImageManager imageManager, uint index)
            => PrintImage.FromFrame(imageManager, index);
    }
}