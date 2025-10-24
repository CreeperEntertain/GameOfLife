using GameOfLife.Exec.FunctionClasses.GameManagement;

namespace GameOfLife.Exec
{
    internal class GameManager
    {
        public List<ImageManager> imageManagers = [];
        private readonly RunGame game;
        private readonly GameImages gameImages = new();

        public GameManager()
        {
            imageManagers.Add(new());
            game = new(imageManagers);
        }

        public void Init()
        {
            Image? image = gameImages.ImageAdding(imageManagers[0], false);
            if (image != null)
                game.SimulateSingleGame(image.Value, 0, true);
        }
    }
}