using System.Runtime.InteropServices;

namespace GameOfLife.Exec.Utilities.WindowManagement
{
    internal static class WindowManager
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct COORD
        {
            public short X;
            public short Y;
            public COORD(short x, short y)
            {
                X = x;
                Y = y;
            }
        }

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetStdHandle(int handle);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool SetConsoleDisplayMode(IntPtr ConsoleOutput, uint Flags, out COORD NewScreenBufferDimensions);

        public static int[] Fullscreen()
        {
            IntPtr hConsole = GetStdHandle(-11);
            COORD xy = new COORD(100, 100);
            SetConsoleDisplayMode(hConsole, 1, out xy);
            return [xy.X, xy.Y];
        }
    }
}