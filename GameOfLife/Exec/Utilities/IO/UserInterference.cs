using System.Runtime.InteropServices;

namespace GameOfLife.Exec.Utilities.IO
{
    internal static class UserInterference
    {
        private const int STD_INPUT_HANDLE = -10;

        private const int ENABLE_QUICK_EDIT_MODE = 0x0040;
        private const int ENABLE_INSERT_MODE = 0x0020;
        private const int ENABLE_MOUSE_INPUT = 0x0010;
        private const int ENABLE_EXTENDED_FLAGS = 0x0080;

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetStdHandle(int nStdHandle);
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool GetConsoleMode(IntPtr hConsoleHandle, out int lpMode);
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool SetConsoleMode(IntPtr hConsoleHandle, int dwMode);

        public static void Disable()
        {
            IntPtr consolehandle = GetStdHandle(STD_INPUT_HANDLE);
            if (!GetConsoleMode(consolehandle, out int mode))
                return;
            mode &= ~ENABLE_QUICK_EDIT_MODE;
            mode &= ~ENABLE_INSERT_MODE;
            mode &= ~ENABLE_MOUSE_INPUT;
            mode |= ENABLE_EXTENDED_FLAGS;
            SetConsoleMode(consolehandle, mode);
        }
    }
}