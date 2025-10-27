using GameOfLife.Exec.DataProviders;
using System.Reflection;

namespace GameOfLife.Exec.Utilities.IO.CommandHandling
{
    internal static class CommandHandlerMethods
    {
        public static void ErrorPrint(string command)
            => TextOut.WriteLine($"Missing or invalid parameters for '{command}'", ConsoleColor.Red);

        public static void UpdateUserPath(string newPath)
            => CommandDictionary.UserInput = newPath;

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
            using StreamReader reader = new(stream);
            return reader.ReadToEnd();
        }
    }
}