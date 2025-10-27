using GameOfLife.Exec.Utilities.IO.CommandHandling;

namespace GameOfLife.Exec.Utilities.IO.Commands
{
    internal static class HelpCommand
    {
        public static void Exec(Dictionary<string, (Func<RunGame, CommandBase>, string)> commands, string userInput)
        {
            TextOut.WriteLine("Here is a list of commands:", ConsoleColor.Blue);
            foreach (var entry in commands)
                TextOut.WriteLine(entry.Key, ConsoleColor.Yellow);
        }
    }
}
