using GameOfLife.Exec.Utilities.GameManagement;

namespace GameOfLife.Exec
{
    internal class GameManager
    {
        public List<ImageManager> imageManagers = [];
        private readonly RunGame game;

        public GameManager()
        {
            imageManagers.Add(new());
            game = new(imageManagers);
        }

        public void Init()
        {
            Image? image = GameImages.ImageAdding(imageManagers[0], false);
            if (image != null)
                game.SimulateSingleGame(image.Value, 0, true);
        }
    }
}