using GameOfLife.Exec.DataProviders;

namespace GameOfLife.Exec.Utilities.IO.Commands
{
    internal static class ClearCommand
    {
        public static void Exec()
        {
            string[] input = CommandDictionary.UserInput.Split(' ');
            if (input.Length > 1)
                TextOut.WriteLine("More than 1 word provided.", ConsoleColor.Red);
            else
                Clear();
        }

        private static void Clear()
            => Console.Clear();
    }
}