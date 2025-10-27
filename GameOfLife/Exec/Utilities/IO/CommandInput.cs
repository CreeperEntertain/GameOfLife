using GameOfLife.Exec.DataProviders;
using System.Reflection;

namespace GameOfLife.Exec.Utilities.IO
{
    internal static class CommandInput
    {
        private static readonly Dictionary<string, (Func<RunGame, CommandBase>, string)> commands = CommandDictionary.commands;

        public static string ReadFile(string fileName)
        {
            string resourceName = $"GameOfLife.Exec.CommandHelp.{fileName}.txt";
            var assembly = Assembly.GetExecutingAssembly();
            using Stream? stream = assembly.GetManifestResourceStream(resourceName);
            if (stream == null)
            {
                TextOut.Write($"Command description for [", ConsoleColor.Red);
                TextOut.Write(fileName, ConsoleColor.Yellow);
                TextOut.WriteLine($"] not implemented. Consider doing so, dumbass!", ConsoleColor.Red);
                return "";
            }
            using StreamReader reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }

        public static void Help()
        {
            TextOut.WriteLine("Here is a list of commands:", ConsoleColor.Blue);
            foreach (var entry in commands)
                TextOut.WriteLine(entry.Key, ConsoleColor.Yellow);
        }
        private static void HelpByCommand(string command)
        {
            TextOut.Write($"Help for [", ConsoleColor.Blue);
            TextOut.Write(command, ConsoleColor.Yellow);
            TextOut.WriteLine("]:", ConsoleColor.Blue);
            TextOut.WriteLine(commands[command].Item2, ConsoleColor.Yellow);
        }
        public static void Exit()
            => Environment.Exit(0);

        public static void Example(string yo, int count)
        {

        }

        public static void ReadCommand(RunGame game)
        {
            bool loop = true;
            while (loop)
                loop = CommandParser(game);
        }
        private static bool CommandParser(RunGame game)
        {
            TextOut.Write("Input > ", ConsoleColor.Cyan);
            string input = Console.ReadLine() ?? "";
            if (commands.TryGetValue(input, out var command))
            {
                command.Item1(game).Invoke();
                return true;
            }
            TextOut.WriteLine("Invalid command.", ConsoleColor.Red);
            return false;
        }
    }
}