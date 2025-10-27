using GameOfLife.Exec.Utilities.IO;

namespace GameOfLife.Exec.DataProviders
{
    internal static class CommandDictionary
    {
        public static Dictionary<string, (Func<RunGame, CommandBase>, string)> commands = new(StringComparer.OrdinalIgnoreCase)
        {
            ["help"] = (game => new ActionCommand(_ => CommandInput.Help()), CommandInput.ReadFile("help")),
            ["exit"] = (game => new ActionCommand(_ => CommandInput.Exit()), CommandInput.ReadFile("exit")),
            ["list"] = (game => new ActionCommand(_ => game.ListImageManagers()), CommandInput.ReadFile("listmgr")),
            ["example"] = (game => new ActionCommand
            (
                args => (
                    args.Length >= 2
                    && args[0] is string name
                    && args[1] is int count
                        ? (Action)(() => CommandInput.Example(name, count))
                        : (Action)(() => TextOut.WriteLine("Missing or invalid parameters for 'example'", ConsoleColor.Red))
                )()
            ), CommandInput.ReadFile("example"))
        };
    }
}