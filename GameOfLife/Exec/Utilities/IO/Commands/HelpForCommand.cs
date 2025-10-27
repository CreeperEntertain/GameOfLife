using GameOfLife.Exec.Utilities.IO.CommandHandling;

namespace GameOfLife.Exec.Utilities.IO.Commands
{
    internal static class HelpForCommand
    {
        public static void Exec(Dictionary<string, (Func<RunGame, CommandBase>, string)> commands, string userInput)
        {
            string command = userInput;
            TextOut.Write($"Help for [", ConsoleColor.Blue);
            TextOut.Write(command, ConsoleColor.Yellow);
            TextOut.WriteLine("]:", ConsoleColor.Blue);
            TextOut.WriteLine(commands[command].Item2, ConsoleColor.Yellow);
        }
    }
}
