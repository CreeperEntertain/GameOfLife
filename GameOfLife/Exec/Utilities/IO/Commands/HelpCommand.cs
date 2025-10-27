using GameOfLife.Exec.DataProviders;
using GameOfLife.Exec.Utilities.IO.CommandHandling;

namespace GameOfLife.Exec.Utilities.IO.Commands
{
    internal static class HelpCommand
    {
        public static void Exec()
        {
            Help(CommandDictionary.commands);
        }

        private static void Help(Dictionary<string, (Func<RunGame, CommandBase>, string)> commands)
        {
            TextOut.WriteLine("Here is a list of commands:", ConsoleColor.Blue);
            foreach (var entry in commands)
                TextOut.WriteLine(entry.Key, ConsoleColor.Yellow);
        }
    }
}