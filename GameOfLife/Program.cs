using GameOfLife.Exec;
using GameOfLife.Exec.Utilities;

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
            GameManager game = new();
            game.Init();
        }
    }
}