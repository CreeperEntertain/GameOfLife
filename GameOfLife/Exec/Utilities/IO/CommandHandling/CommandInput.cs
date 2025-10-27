using GameOfLife.Exec.DataProviders;
using System.Reflection;

namespace GameOfLife.Exec.Utilities.IO.CommandHandling
{
    internal static class CommandInput
    {
        private static readonly Dictionary<string, (Func<RunGame, CommandBase>, string)> commands = CommandDictionary.commands;
        private static string userPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? "WHAT THE FUCK?!";

        public static void Example(string yo, int count) { }
        private static void HelpByCommand(string command)
        {
            TextOut.Write($"Help for [", ConsoleColor.Blue);
            TextOut.Write(command, ConsoleColor.Yellow);
            TextOut.WriteLine("]:", ConsoleColor.Blue);
            TextOut.WriteLine(commands[command].Item2, ConsoleColor.Yellow);
        }

        public static void UpdateUserPath(string newPath)
            => userPath = newPath;

        public static void ReadCommand(RunGame game)
        {
            bool loop = true;
            while (loop)
                loop = CommandParser(game);
        }
        private static bool CommandParser(RunGame game)
        {
            TextOut.Write($"{userPath} > ", ConsoleColor.Cyan);
            string input = Console.ReadLine() ?? "";
            CommandDictionary.UserInput = input;
            if (commands.TryGetValue(input, out var command))
                command.Item1(game).Invoke();
            else
                TextOut.WriteLine("Invalid command.", ConsoleColor.Red);
            return true;
        }
    }
}