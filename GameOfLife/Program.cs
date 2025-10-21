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
            Console.Write("WIDTH:");
            Int32.TryParse(Console.ReadLine() ?? "", out int providedWidth);


            ImageManager imageManager = new(Console.ReadLine() ?? "");
            Image? image = imageManager.GetImage(0);

            int width = 0;
            int height = 0;

            if (image != null)
            {
                width = image.size[0];
                height = image.size[1];
            }

            Console.WriteLine($"The new image is {width}x{height} pixels large.");
        }
    }
}