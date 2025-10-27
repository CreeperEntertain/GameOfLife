using GameOfLife.Exec.Structs;
using GameOfLife.Exec.Utilities;
using GameOfLife.Exec.Utilities.GameManagement;
using GameOfLife.Exec.Utilities.IO;

namespace GameOfLife.Exec
{
    internal class RunGame(List<ImageManager> imageManagers)
    {
        public void SimulateSingleGame(Image image, int imageManagerIndex, bool addResultsToImageManager = false)
            => Simulate.SingleGame(image, imageManagers, imageManagerIndex, addResultsToImageManager);
        public void RunSim(Grid grid, int simulationSteps, byte delayBetweenSteps, int? imageManagerIndex = null)
            => Simulate.Run(grid, imageManagers, simulationSteps, delayBetweenSteps, imageManagerIndex);

        public void CreateFromUserInput(bool cancellable = true)
            => ImageManagerHandling.CreateFromUserInput(imageManagers, cancellable);
        public bool RenameImageManager(uint index, string name, bool printResult = false)
            => ImageManagerHandling.RenameImageManager(imageManagers, index, name, printResult);
        public bool RenameImageManagerFromUserInput(uint index, bool printResult = false)
            => ImageManagerHandling.RenameImageManagerFromUserInput(imageManagers, index, printResult);
        public void ListImageManagers()
            => ImageManagerHandling.List(imageManagers);

        public bool PrintFrame(ImageManager imageManager, uint index)
            => PrintImage.FromFrame(imageManager, index);

        public void ReadCommandInput()
            => UserInput.ReadCommandInput(this);
    }
}