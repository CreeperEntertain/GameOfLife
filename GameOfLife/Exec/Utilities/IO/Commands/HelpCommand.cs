using GameOfLife.Exec.DataProviders;

namespace GameOfLife.Exec.Utilities.IO.Commands
{
    internal static class HelpCommand
    {
        public static void Exec()
        {
            string[] input = CommandDictionary.UserInput.Split(' ');
            if (input.Length > 1)
                TextOut.WriteLine("More than 1 word provided.", ConsoleColor.Red);
            else
                Help();
        }

        private static void Help()
        {
            TextOut.WriteLine("Here is a list of commands:", ConsoleColor.Blue);
            foreach (var entry in CommandDictionary.commands)
                TextOut.WriteLine(entry.Key, ConsoleColor.Yellow);
            TextOut.Write("Type '", ConsoleColor.Blue);
            TextOut.Write("helpfor [command]", ConsoleColor.Yellow);
            TextOut.WriteLine("' for help with a specific command.", ConsoleColor.Blue);
        }
    }
}