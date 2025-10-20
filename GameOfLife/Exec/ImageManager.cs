using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace GameOfLife.Exec
{
    internal class ImageManager
    {
        Image loadedImage;
        Image fallbackImage = new Image(new Image<Rgba32>(new Configuration(), 16, 16));

        public ImageManager(string imageReference)
        {
            loadedImage = File.Exists(imageReference) ? new Image(imageReference) : fallbackImage;
        }
    }
}