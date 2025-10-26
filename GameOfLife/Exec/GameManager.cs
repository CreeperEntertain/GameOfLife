using GameOfLife.Exec.Utilities.GameManagement;
using GameOfLife.Exec.Utilities.IO;

namespace GameOfLife.Exec
{
    internal static class GameManager
    {
        public static List<ImageManager> imageManagers = [];
        private static readonly RunGame game;

        static GameManager()
        {
            imageManagers.Add(new(""));
            game = new(imageManagers);
        }

        public static void Init()
        {
            TextOut.WriteLine("Welcome!", ConsoleColor.Cyan);

            Image? image = GameImages.ImageAdding(imageManagers[0]);
            if (image != null)
                game.SimulateSingleGame(image.Value, 0, true);
        }
    }
}