using GameOfLife.Exec.DataProviders;
using System.Reflection;

namespace GameOfLife.Exec.Utilities.IO.CommandHandling
{
    internal static class CommandInput
    {
        private static readonly Dictionary<string, (Func<RunGame, CommandBase>, string)> commands = CommandDictionary.commands;
        private static string UserPath { get; set; }
        static CommandInput()
            => UserPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? "WHAT THE FUCK?!";

        public static void ReadCommand(RunGame game)
        {
            bool loop = true;
            while (loop)
                loop = CommandParser(game);
        }
        private static bool CommandParser(RunGame game)
        {
            TextOut.Write($"{UserPath} > ", ConsoleColor.Cyan);
            string input = Console.ReadLine() ?? "";
            CommandDictionary.UserInput = input;
            CommandDictionary.InputHistory.Add(input);
            string firstWord = input.Split(' ').FirstOrDefault() ?? "";
            if (commands.TryGetValue(firstWord, out var command))
                command.Item1(game).Invoke();
            else
                TextOut.WriteLine("Invalid command.", ConsoleColor.Red);
            return true;
        }
    }
}