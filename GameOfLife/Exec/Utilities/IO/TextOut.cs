namespace GameOfLife.Exec.Utilities.IO
{
    internal static class TextOut
    {
        public static void WriteLine(object input, ConsoleColor textColor = ConsoleColor.White, ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            var originalForeground = Console.ForegroundColor;
            var originalBackground = Console.BackgroundColor;

            Console.ForegroundColor = textColor;
            Console.BackgroundColor = backgroundColor;

            Console.WriteLine(input);

            Console.ForegroundColor = originalForeground;
            Console.BackgroundColor = originalBackground;
        }
    }
}
