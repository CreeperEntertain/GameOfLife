using GameOfLife.Exec;
using GameOfLife.Exec.Structs;

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
            int[] providedScales;
            do
            {
                providedScales = ProvidedScales();
            } while (!CheckDimensions(providedScales));

            ImageManager imageManager = new();
            imageManager.CreateImage(providedScales[0], providedScales[1]);
            Image? image = imageManager.GetImage(0);

            int width = 0;
            int height = 0;

            if (image != null)
            {
                width = image.size[0];
                height = image.size[1];
            }
            
            Console.WriteLine($"The new image is {width}x{height} pixels large.");
            Console.Write(image != null ? $"Pixel [3, 4] -- {image.pixel[3, 4].RGB}\n" : "");
        }

        private bool CheckDimensions(int[] providedScales)
        {
            int upperLimit = 127;
            foreach (int index in providedScales)
                if (index < 1 || index > upperLimit)
                {
                    Console.WriteLine("Image too large or small.");
                    return false;
                }
            return true;
        }

        private int[] ProvidedScales()
        {
            Console.Write("WIDTH:");
            Int32.TryParse(Console.ReadLine() ?? "", out int providedWidth);
            Console.Clear();
            Console.Write("HEIGTH:");
            Int32.TryParse(Console.ReadLine() ?? "", out int providedHeight);
            Console.Clear();

            return [providedWidth, providedHeight];
        }
    }
}