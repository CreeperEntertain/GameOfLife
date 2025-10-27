using GameOfLife.Exec.DataProviders;

namespace GameOfLife.Exec.Utilities.IO.Commands
{
    internal static class ClearHistoryCommand
    {
        public static void Exec()
        {
            string[] input = CommandDictionary.UserInput.Split(' ');
            if (input.Length > 1)
                TextOut.WriteLine("More than 1 word provided.", ConsoleColor.Red);
            else
                ClearHistory();
        }

        private static void ClearHistory()
        {
            CommandDictionary.InputHistory = [];
            TextOut.Write("Input history cleared.", ConsoleColor.Blue);
        }
    }
}
