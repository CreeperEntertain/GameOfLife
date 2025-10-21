using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace GameOfLife.Exec
{
    internal class ImageManager
    {
        readonly Image loadedImage;
        readonly Image fallbackImage = new(new Image<Rgba32>(new Configuration(), 16, 16));

        public ImageManager(string imageReference)
        {
            loadedImage = File.Exists(imageReference) ? new Image(imageReference) : fallbackImage;
        }


    }
}