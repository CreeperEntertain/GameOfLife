namespace GameOfLife.Exec
{
    internal class ImageManager
    {
        Image loadedImage;
        public ImageManager(string imageReference)
        {
            // TODO: Do a does-image-exist check!!!
            loadedImage = new Image(imageReference);
        }
    }
}