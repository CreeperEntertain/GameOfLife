using GameOfLife.Exec.DataProviders;

namespace GameOfLife.Exec.Utilities.IO.Commands
{
    internal static class RenameCommand
    {
        public static void Exec(RunGame game)
        {
            string[] input = CommandDictionary.UserInput.Split(' ');
            if (input.Length > 2)
                TextOut.WriteLine("More than 2 words provided.", ConsoleColor.Red);
            if (input.Length < 2)
                TextOut.WriteLine("Less than 2 words provided.", ConsoleColor.Red);
            else
                DifferentiateSecondKeyword(input[1], game);
        }

        private static void DifferentiateSecondKeyword(string keyword, RunGame game)
        {
            switch (keyword)
            {
                case "manager":
                    RenameImageManager(game);
                    break;
                default:
                    TextOut.Write("Parameter [", ConsoleColor.Red);
                    TextOut.Write(keyword, ConsoleColor.Yellow);
                    TextOut.WriteLine("] not recognized.", ConsoleColor.Red);
                    break;
            }
        }

        private static void RenameImageManager(RunGame game)
        {
            game.ListImageManagers();
            TextOut.Write("Provide the number of the manager you want to rename: ");
            _ = uint.TryParse(Console.ReadLine() ?? "", out uint selectedManager);
            if (selectedManager < 1 || selectedManager > game.ImageManagers.Count)
            {
                TextOut.WriteLine("Image manager does not exist.", ConsoleColor.Red);
                return;
            }

            game.RenameImageManagerFromUserInput(selectedManager - 1, true);
        }
    }
}