namespace GameOfLife.Exec.Utilities.IO.Commands
{
    internal static class ExitCommand
    {
        public static void Exec()
            => Environment.Exit(0);
    }
}
