using GameOfLife.Exec.Utilities.IO;
using GameOfLife.Exec.Utilities.IO.CommandHandling;
using GameOfLife.Exec.Utilities.IO.Commands;
using System.Reflection;

namespace GameOfLife.Exec.DataProviders
{
    internal static class CommandDictionary
    {
        public static string UserInput { get; set; }
        static CommandDictionary()
            => UserInput = "";

        public static readonly Dictionary<string, (Func<RunGame, CommandBase>, string)> commands = new(StringComparer.OrdinalIgnoreCase)
        {
            ["help"] = (game => new ActionCommand(_ => Help(UserInput ?? "")), ReadFile("help")),
            ["?"] = (game => new ActionCommand(_ => Help(UserInput ?? "")), ReadFile("help")),
            ["exit"] = (game => new ActionCommand(_ => ExitCommand.Exec()), ReadFile("exit")),
            ["clear"] = (game => new ActionCommand(_ => ClearCommand.Exec()), ReadFile("clear")),
            ["list"] = (game => new ActionCommand(_ => ListCommand.Exec(game, UserInput ?? "")), ReadFile("list")),
            ["example"] = (game => new ActionCommand
            (
                args => (
                    args.Length >= 2
                    && args[0] is string name
                    && args[1] is int count
                        ? (Action)(() => CommandInput.Example(name, count))
                        : (() => ErrorPrint("example"))
                )()
            ), ReadFile("example"))
        };

        private static void ErrorPrint(string command)
        {
            TextOut.WriteLine($"Missing or invalid parameters for '{command}'", ConsoleColor.Red);
        }
        private static void Help(string userInput)
            => HelpCommand.Exec(commands, userInput);

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
    }
}