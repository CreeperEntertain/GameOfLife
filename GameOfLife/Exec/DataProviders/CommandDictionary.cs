using GameOfLife.Exec.Utilities.IO.CommandHandling;
using GameOfLife.Exec.Utilities.IO.Commands;
using System.Reflection;

namespace GameOfLife.Exec.DataProviders
{
    internal static class CommandDictionary
    {
        public static string UserInput { get; set; }
        public static List<string> InputHistory { get; set; }
        public static readonly Dictionary<string, (Func<RunGame, CommandBase>, string)> commands = new(StringComparer.OrdinalIgnoreCase)
        {
            ["help"] = (game => new ActionCommand(_ => Help(UserInput ?? "")), ReadFile("help")),
            ["helpfor"] = (game => new ActionCommand(_ => HelpFor(UserInput ?? "")), ReadFile("helpfor")),
            ["exit"] = (game => new ActionCommand(_ => ExitCommand.Exec()), ReadFile("exit")),
            ["clear"] = (game => new ActionCommand(_ => ClearCommand.Exec()), ReadFile("clear")),
            ["history"] = (game => new ActionCommand(_ => HistoryCommand.Exec(UserInput ?? "", InputHistory ?? [])), ReadFile("history")),
            ["clearhistory"] = (game => new ActionCommand(_ => ClearHistoryCommand.Exec(UserInput ?? "")), ReadFile("clearhistory")),
            ["list"] = (game => new ActionCommand(_ => ListCommand.Exec(game, UserInput ?? "")), ReadFile("list"))
        };
        static CommandDictionary()
        {
            UserInput = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? "WHAT THE FUCK?!";
            InputHistory = [];
        }

        private static void ErrorPrint(string command)
            => CommandHandlerMethods.ErrorPrint(command);
        private static string ReadFile(string fileName)
            => CommandHandlerMethods.ReadFile(fileName);
        private static void Help(string userInput)
            => HelpCommand.Exec(commands, userInput);
        private static void HelpFor(string userInput)
            => HelpForCommand.Exec(commands, userInput);
    }
}