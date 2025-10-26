using GameOfLife.Exec;
using GameOfLife.Exec.Utilities.IO;
using GameOfLife.Exec.Utilities.WindowManagement;

namespace GameOfLife
{
    internal class Program
    {
        static void Main(string[] args)
            =>  new Game().Run();
    }

    internal class Game
    {
        public void Run()
        {
            WindowManager.Fullscreen();
            UserInterference.Disable();
            EventBlocker.BlockEvent(EventBlocker.CtrlEvent.CTRL_C);

            GameManager.Init();
        }
    }
}