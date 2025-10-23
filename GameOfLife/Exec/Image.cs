using GameOfLife.Exec.Utilities;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace GameOfLife.Exec
{
    internal class Image
    {
        public Image<Rgba32> image;
        public int[] size = null!;
        public Structs.Color[,] pixel { get; set; }

        public Image(string imageLocation)
        {

            if (!File.Exists(imageLocation))
                throw new ArgumentException("File must exist.");

            image = SixLabors.ImageSharp.Image.Load<Rgba32>(imageLocation);
            size = [image.Width, image.Height];
            pixel = PixelAsRGB(size, image);
        }
        public Image(Image<Rgba32> image)
        {
            this.image = image;
            size = [this.image.Width, this.image.Height];
            pixel = PixelAsRGB(size, this.image);
        }

        public Structs.Color[,] PixelAsRGB(int[] size, Image<Rgba32> image)
            => PixelAsRGBClass.Exec(size, image);
    }
}