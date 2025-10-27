using GameOfLife.Exec.Structs;
using GameOfLife.Exec.Utilities;
using GameOfLife.Exec.Utilities.GameManagement;
using GameOfLife.Exec.Utilities.IO;

namespace GameOfLife.Exec
{
    internal class RunGame(List<ImageManager> imageManagers)
    {
        public List<ImageManager> ImageManagers { get; } = imageManagers;

        public void SimulateSingleGame(Image image, int imageManagerIndex, bool addResultsToImageManager = false)
            => Simulate.SingleGame(image, ImageManagers, imageManagerIndex, addResultsToImageManager);
        public void RunSim(Grid grid, int simulationSteps, byte delayBetweenSteps, int? imageManagerIndex = null)
            => Simulate.Run(grid, ImageManagers, simulationSteps, delayBetweenSteps, imageManagerIndex);

        public void CreateFromUserInput(bool cancellable = true)
            => ImageManagerHandling.CreateFromUserInput(ImageManagers, cancellable);
        public bool RenameImageManager(uint index, string name, bool printResult = false)
            => ImageManagerHandling.RenameImageManager(ImageManagers, index, name, printResult);
        public bool RenameImageManagerFromUserInput(uint index, bool printResult = false)
            => ImageManagerHandling.RenameImageManagerFromUserInput(ImageManagers, index, printResult);
        public void ListImageManagers()
            => ImageManagerHandling.List(ImageManagers);

        public bool PrintFrame(ImageManager imageManager, uint index)
            => PrintImage.FromFrame(imageManager, index);

        public void ReadCommandInput()
            => UserInput.ReadCommandInput(this);
    }
}