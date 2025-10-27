namespace GameOfLife.Exec.Utilities.IO
{
    internal static class TextOut
    {
        public static void Write(object input, ConsoleColor textColor = ConsoleColor.White, ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            var originalForeground = Console.ForegroundColor;
            var originalBackground = Console.BackgroundColor;

            Console.ForegroundColor = textColor;
            Console.BackgroundColor = backgroundColor;

            Console.Write(input);

            Console.ForegroundColor = originalForeground;
            Console.BackgroundColor = originalBackground;
        }
        public static void Write()
            => Console.Write("");

        public static void WriteLine(object input, ConsoleColor textColor = ConsoleColor.White, ConsoleColor backgroundColor = ConsoleColor.Black)
            => Write($"{input}\n", textColor, backgroundColor);
        public static void WriteLine()
            => Console.WriteLine();
    }
}