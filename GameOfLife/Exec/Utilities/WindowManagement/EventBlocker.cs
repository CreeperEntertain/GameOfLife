using System.Runtime.InteropServices;

namespace GameOfLife.Exec.Utilities.IO
{
    internal static class EventBlocker
    {
        private delegate bool ConsoleEventDelegate(CtrlEvent ctrlType);

        [DllImport("Kernel32")]
        private static extern bool SetConsoleCtrlHandler(ConsoleEventDelegate handler, bool add);

        private static readonly ConsoleEventDelegate _handler = Handler;

        public enum CtrlEvent
        {
            CTRL_C = 0,
            CTRL_BREAK = 1,
            CTRL_CLOSE = 2,
            CTRL_LOGOFF = 5,
            CTRL_SHUTDOWN = 6
        }

        private static readonly HashSet<CtrlEvent> BlockedEvents = [];

        static EventBlocker()
            => SetConsoleCtrlHandler(_handler, true);

        public static void BlockEvent(CtrlEvent ctrlEvent)
            => BlockedEvents.Add(ctrlEvent);
        public static void UnblockEvent(CtrlEvent ctrlEvent)
            => BlockedEvents.Remove(ctrlEvent);

        private static bool Handler(CtrlEvent ctrlType)
            => BlockedEvents.Contains(ctrlType);
    }
}
