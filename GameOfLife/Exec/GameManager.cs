using GameOfLife.Exec.Utilities;
using GameOfLife.Exec.Utilities.GameManagement;
using GameOfLife.Exec.Utilities.IO;

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
            TextOut.WriteLine("Greetings, user!\n", ConsoleColor.Green);
            game.CreateFromUserInput(false);
            game.ReadCommand();

            /*
            game.ListImageManagers();

            Image? image = GameImages.ImageAdding(imageManagers[0]);
            if (image != null)
                game.SimulateSingleGame(image.Value, 0, true);

            TextOut.Write("Press any key to render frame 16", ConsoleColor.Blue);
            Console.ReadKey();
            PrintImage.FromFrame(imageManagers[0], 16);
            */
        }
    }
}