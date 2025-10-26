namespace GameOfLife.Exec.Utilities.GameManagement
{
    internal static class ImageManagerHandling
    {
        private readonly static int listPadding = 6;
        private readonly static int maxNameLength = 127;

        public static bool CreateFromUserInput(List<ImageManager> imageManagers, bool cancellable = true)
        {
            string providedName = "";
            bool loop = true;
            while (loop)
            {
                Console.Write
                (
                    cancellable
                    ? "Provide a name and hit enter.\nAlternatively, type 'cancel' to cancel: "
                    : "Provide a name and hit enter: "
                );
                providedName = Console.ReadLine() ?? "";
                if (cancellable && providedName.ToLower() == "cancel")
                {
                    Console.WriteLine("Image manager creation cancelled.");
                    return false;
                }
                if (providedName.Length > maxNameLength)
                {
                    Console.WriteLine("Provided name is too long.");
                    continue;
                }
                if (providedName.Length == 0)
                {
                    Console.WriteLine("Provided name cannot be empty.");
                    continue;
                }
                loop = false;
            }
            imageManagers.Add(new(providedName));
            Console.WriteLine($"Added image manager [{providedName}].");
            return true;
        }

        public static bool RenameImageManager(List<ImageManager> imageManagers, uint index, string name, bool printResult = false)
        {
            if (index > imageManagers.Count)
            {
                if (printResult)
                    Console.WriteLine("Image manager does not exist.");
                return false;
            }
            imageManagers[(int)index].name = name;
            if (printResult)
                Console.WriteLine($"Image manager renamed to [{name}].");
            return true;
        }

        public static bool RenameImageManagerFromUserInput(List<ImageManager> imageManagers, uint index, bool printResult = false)
        {
            string name = Console.ReadLine() ?? "";
            if (name.Length > maxNameLength)
            {
                if (printResult)
                    Console.WriteLine("Provided name is too long.");
                return false;
            }
            return RenameImageManager(imageManagers, index, name, printResult);
        }

        public static void List(List<ImageManager> imageManagers)
        {
            int ID = 1;
            foreach (ImageManager manager in imageManagers)
            {
                Console.WriteLine($"{$"{ID}.".PadRight(listPadding)}{manager.name}");
                ID++;
            }
        }
    }
}