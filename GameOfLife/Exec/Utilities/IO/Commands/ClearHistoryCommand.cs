using GameOfLife.Exec.DataProviders;

namespace GameOfLife.Exec.Utilities.IO.Commands
{
    internal static class ClearHistoryCommand
    {
        public static void Exec()
        {
            ClearHistory();
        }

        private static void ClearHistory()
            => CommandDictionary.InputHistory = [];
    }
}
