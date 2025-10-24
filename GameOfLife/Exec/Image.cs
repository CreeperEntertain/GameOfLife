using GameOfLife.Exec.Utilities.BuildArray;
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
            image = ConstructImageRgba32(colorArray);
            size = [this.image.Width, this.image.Height];
            pixel = colorArray;
        }

        private Image<Rgba32> ConstructImageRgba32(Structs.Color[,] colorArray)
        {
            int width = colorArray.GetLength(0);
            int height = colorArray.GetLength(1);
            var image = new Image<Rgba32>(width, height);
            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                {
                    Structs.Color color = colorArray[x, y];
                    image[x, y] = new Rgba32(color.RGB.R, color.RGB.G, color.RGB.B);
                }
            return image;
        }

        public Structs.Color[,] PixelAsRGB(int[] size, Image<Rgba32> image)
            => PixelAsRGBClass.Exec(size, image);
    }
}