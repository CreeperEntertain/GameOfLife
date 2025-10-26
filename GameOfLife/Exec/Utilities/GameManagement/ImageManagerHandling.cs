namespace GameOfLife.Exec.Utilities.GameManagement
{
    internal static class ImageManagerHandling
    {
        public static bool RenameImageManager(List<ImageManager> imageManagers, uint index, string name, bool printResult = false)
        {
            bool success = imageManagers.All(m => m.name != name);
            if (success)
                if (index > imageManagers.Count)
                {
                    if (printResult)
                        Console.WriteLine("Image manager does not exist.");
                    return false;
                }
                else
                {
                    imageManagers[(int)index].name = name;
                    if (printResult)
                        Console.WriteLine($"Image manager renamed to [{name}].");
                    return true;
                }
            else if (printResult)
                Console.WriteLine("Image manager with that name already exists.");
            return success;
        }
    }
}