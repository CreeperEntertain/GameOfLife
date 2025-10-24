using GameOfLife.Exec.Utilities;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace GameOfLife.Exec
{
    internal struct Image
    {
        public Image<Rgba32> image;
        public int[] size;
        public Structs.Color[,] pixel;

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
        public Image(Structs.Color[,] colorArray)
        {
            int xScale = colorArray.GetLength(0);
            int yScale = colorArray.GetLength(1);
            Image<Rgba32> image = new(xScale, yScale);
            for (int x = 0; x < xScale; x++)
                for (int y = 0; y < yScale; y++)
                {

                }
            this.image = image;
            size = [];
            pixel = colorArray;
        }

        public Structs.Color[,] PixelAsRGB(int[] size, Image<Rgba32> image)
            => PixelAsRGBClass.Exec(size, image);
    }
}