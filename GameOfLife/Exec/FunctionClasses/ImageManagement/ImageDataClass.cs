namespace GameOfLife.Exec.FunctionClasses.ImageManagement
{
    internal class ImageDataClass
    {
        public ImageDataClass()
        {

        }

        ImageManagementClass imageManagement = new();

        public int[] GetImageDimensions(ref List<Image> imageList, int index, bool printResult)
        {
            Image? image = imageManagement.GetImage(ref imageList, index, printResult);
            if (image != null)
                return [image.size[0], image.size[1]];
            return [0, 0];
        }
    }
}