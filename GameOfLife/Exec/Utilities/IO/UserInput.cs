using System.Collections.Concurrent;

namespace GameOfLife.Exec.Utilities.IO
{
    internal static class UserInput
    {
        private static readonly ConcurrentQueue<ConsoleKey> keyQueue = new();
        static UserInput()
            => new Thread(() =>
            { while (true) KeyEnqueuing(); })
            { IsBackground = true }.Start();
        private static void KeyEnqueuing()
        {
            while (Console.KeyAvailable)
                keyQueue.Enqueue(Console.ReadKey(intercept: true).Key);
            Thread.Sleep(5);
        }

        public static bool IsKeyDown(ConsoleKey key)
        {
            bool found = false;
            while (keyQueue.TryDequeue(out var pressed))
                found |= pressed == key;
            return found;
        }

        public static void ReadCommand(RunGame game)
            => CommandInput.ReadCommand(game);

        public static int[] ProvideScales()
        {
            TextOut.WriteLine("Type 'cancel' to cancel.", ConsoleColor.Blue);
            TextOut.Write("WIDTH:", ConsoleColor.Blue);
            string width = Console.ReadLine() ?? "";
            if (width.ToLower() == "cancel")
                return [];
            TextOut.WriteLine("Type 'cancel' to cancel.", ConsoleColor.Blue);
            TextOut.Write("HEIGTH:", ConsoleColor.Blue);
            string height = Console.ReadLine() ?? "";
            if (height.ToLower() == "cancel")
                return [];

            bool hasWidth = int.TryParse(width, out int providedWidth);
            bool hasHeight = int.TryParse(height, out int providedHeight);
            if (!hasWidth || !hasHeight)
                return [-1, -1];
            return [providedWidth, providedHeight];
        }
    }
}