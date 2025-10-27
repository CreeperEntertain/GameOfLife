using GameOfLife.Exec.DataProviders;

namespace GameOfLife.Exec.Utilities.IO.Commands
{
    internal static class HistoryCommand
    {
        private static readonly int indexPadding = 6;

        public static void Exec()
        {
            string[] input = CommandDictionary.UserInput.Split(' ');
            if (input.Length > 1)
                TextOut.WriteLine("More than 1 word provided.", ConsoleColor.Red);
            else
                PrintHistory(CommandDictionary.InputHistory);
        }

        private static void PrintHistory(List<string> inputHistory)
        {
            TextOut.WriteLine("Your command history:", ConsoleColor.Blue);
            int index = 1;
            foreach (string input in inputHistory)
            {
                string paddedIndex = $"{index}.".PadRight(indexPadding);
                TextOut.Write(paddedIndex, ConsoleColor.Blue);
                TextOut.WriteLine(input, ConsoleColor.Yellow);
            }
        }
    }
}
