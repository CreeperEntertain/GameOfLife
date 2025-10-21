using GameOfLife.Exec;

namespace GameOfLife
{
    internal class Program
    {
        static void Main(string[] args) => new Game().Run();
    }

    internal class Game
    {
        public void Run()
        {
            ImageManager imageManager = new();
            Image image = imageManager.CreateImageProcess(false) ?? imageManager.CreateImage(1, 1);
            Console.WriteLine($"Pixel [0, 0] -- {image.pixel[0, 0].RGB}");
        }
    }
}