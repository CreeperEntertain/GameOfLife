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
            game.ReadCommandInput();
        }
    }
}