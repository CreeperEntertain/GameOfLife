using GameOfLife.Exec.Utilities.IO;

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
                TextOut.Write
                (
                    cancellable
                    ? "Provide a name and hit enter.\nAlternatively, type 'cancel' to cancel: "
                    : "Provide a name and hit enter: ",
                    ConsoleColor.Blue
                );
                providedName = Console.ReadLine() ?? "";
                if (cancellable && providedName.ToLower() == "cancel")
                {
                    TextOut.WriteLine("Image manager creation cancelled.", ConsoleColor.Yellow);
                    return false;
                }
                if (providedName.Length > maxNameLength)
                {
                    TextOut.WriteLine("Provided name is too long.", ConsoleColor.Red);
                    continue;
                }
                if (providedName.Length == 0)
                {
                    TextOut.WriteLine("Provided name cannot be empty.", ConsoleColor.Red);
                    continue;
                }
                loop = false;
            }
            imageManagers.Add(new(providedName));
            TextOut.Write("Added image manager [", ConsoleColor.Green);
            TextOut.Write(providedName, ConsoleColor.Yellow);
            TextOut.WriteLine("].", ConsoleColor.Green);
            return true;
        }

        public static bool RenameImageManager(List<ImageManager> imageManagers, uint index, string name, bool printResult = false)
        {
            if (index > imageManagers.Count)
            {
                if (printResult)
                    TextOut.WriteLine("Image manager does not exist.", ConsoleColor.Red);
                return false;
            }
            imageManagers[(int)index].name = name;
            if (printResult)
            {
                TextOut.Write("Image manager renamed to [", ConsoleColor.Green);
                TextOut.Write(name, ConsoleColor.Yellow);
                TextOut.WriteLine("].", ConsoleColor.Green);
            }
            return true;
        }

        public static bool RenameImageManagerFromUserInput(List<ImageManager> imageManagers, uint index, bool printResult = false)
        {
            string name = Console.ReadLine() ?? "";
            if (name.Length > maxNameLength)
            {
                if (printResult)
                    TextOut.WriteLine("Provided name is too long.", ConsoleColor.Red);
                return false;
            }
            return RenameImageManager(imageManagers, index, name, printResult);
        }

        public static void List(List<ImageManager> imageManagers)
        {
            int ID = 1;
            foreach (ImageManager manager in imageManagers)
            {
                TextOut.Write($"{$"{ID}.".PadRight(listPadding)}", ConsoleColor.Blue);
                TextOut.WriteLine(manager.name, ConsoleColor.Yellow);
                ID++;
            }
        }
    }
}