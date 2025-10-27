using System.Reflection;

namespace GameOfLife.Exec.Utilities.IO
{
    internal static class CommandInput
    {
        private static readonly Dictionary<string, (Func<RunGame, CommandBase>, string)> commands = new(StringComparer.OrdinalIgnoreCase)
        {
            ["help"] = (game => new ActionCommand(Help), ReadFile("help")),
            ["list mgr"] = (game => new ActionCommand(game.ListImageManagers), ReadFile("listmgr"))
        };

        private static string ReadFile(string fileName)
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

        private static void Help()
        {
            TextOut.WriteLine("Here is a list of commands:", ConsoleColor.Blue);
            foreach (var entry in commands)
                TextOut.WriteLine(entry.Key, ConsoleColor.Yellow);
        }

        public static void ReadCommand(RunGame game)
        {
            while (true)
            {
                string input = Console.ReadLine() ?? "";
                if (commands.TryGetValue(input, out var command))
                {
                    command.Item1(game).Invoke();
                    return;
                }
                TextOut.WriteLine("Invalid command.", ConsoleColor.Red);
            }
        }
    }
}