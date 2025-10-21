using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace GameOfLife.Exec
{
    internal class Image
    {
        public Image<Rgba32> image;
        public int[] size = null!;
        public Color[,] pixel = null!;

        public Image(string imageLocation)
        {

            if (!File.Exists(imageLocation))
                throw new ArgumentException("File must exist.");

            image = SixLabors.ImageSharp.Image.Load<Rgba32>(imageLocation);
            AssignImageData();
        }
        public Image(Image<Rgba32> image)
        {
            this.image = image;
            AssignImageData();
        }

        private void AssignImageData()
        {
            size = [image.Width, image.Height];
            pixel = PixelAsRGB(size, image);
        }

        private Color[,] PixelAsRGB(int[] size, Image<Rgba32> image)
        {
            int width = size[0];
            int height = size[1];

            Color[,] rgbArrayOut = new Color[width, height];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    var pixel = image[x, y];

                    rgbArrayOut[x, y] = new Color(pixel.R, pixel.G, pixel.B);
                }
            }

            return rgbArrayOut;
        }
    }
}