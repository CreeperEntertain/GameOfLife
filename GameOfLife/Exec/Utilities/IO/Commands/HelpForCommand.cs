using GameOfLife.Exec.DataProviders;

namespace GameOfLife.Exec.Utilities.IO.Commands
{
    internal static class HelpForCommand
    {
        public static void Exec()
        {
            string command = CommandDictionary.UserInput;
            TextOut.Write($"Help for [", ConsoleColor.Blue);
            TextOut.Write(command, ConsoleColor.Yellow);
            TextOut.WriteLine("]:", ConsoleColor.Blue);
            TextOut.WriteLine(CommandDictionary.commands[command].Item2, ConsoleColor.Yellow);
        }
    }
}
