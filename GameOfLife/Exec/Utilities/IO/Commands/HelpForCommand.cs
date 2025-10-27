using GameOfLife.Exec.DataProviders;

namespace GameOfLife.Exec.Utilities.IO.Commands
{
    internal static class HelpForCommand
    {
        public static void Exec()
        {
            string[] input = CommandDictionary.UserInput.Split(' ');
            if (input.Length > 2)
                TextOut.WriteLine("More than 2 words provided.", ConsoleColor.Red);
            if (CommandDictionary.commands.ContainsKey(input[1]))
                HelpFor(input[1].ToLower());
            else
            {
                TextOut.Write("Command [", ConsoleColor.Red);
                TextOut.Write(input[1].ToLower(), ConsoleColor.Yellow);
                TextOut.WriteLine("] does not exist.", ConsoleColor.Red);
            }
        }

        private static void HelpFor(string command)
        {
            TextOut.Write($"Help for [", ConsoleColor.Blue);
            TextOut.Write(command, ConsoleColor.Yellow);
            TextOut.WriteLine("]:", ConsoleColor.Blue);
            TextOut.WriteLine(CommandDictionary.commands[command].Item2, ConsoleColor.Yellow);
        }
    }
}