using GameOfLife.Exec.Utilities.GameManagement;

namespace GameOfLife.Exec
{
    internal static class GameManager
    {
        public static List<ImageManager> imageManagers = [];
        private static readonly RunGame game;

        static GameManager()
            => game = new(imageManagers);

        public static void Init()
        {
            game.CreateFromUserInput(false);
            game.ListImageManagers();

            Image? image = GameImages.ImageAdding(imageManagers[0]);
            if (image != null)
                game.SimulateSingleGame(image.Value, 0, true);
        }
    }
}