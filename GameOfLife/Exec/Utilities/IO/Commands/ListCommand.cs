using GameOfLife.Exec.DataProviders;
using System.Text.RegularExpressions;

namespace GameOfLife.Exec.Utilities.IO.Commands
{
    internal static class ListCommand
    {
        public static void Exec(RunGame game)
        {
            string[] input = CommandDictionary.UserInput.Split(' ');
            if (input.Length > 2)
                TextOut.WriteLine("More than 2 words provided.", ConsoleColor.Red);
            else if (input.Length < 2)
                TextOut.WriteLine("Less than 2 words provided.", ConsoleColor.Blue);
            else
                DifferentiateSecondKeyword(input[1], game);
        }

        private static void DifferentiateSecondKeyword(string keyword, RunGame game)
        {
            switch (keyword)
            {
                case "managers":
                    ListGameManagers(game);
                    break;
                case "images":
                    ListImages(game);
                    break;
                default:
                    TextOut.Write("Parameter [", ConsoleColor.Red);
                    TextOut.Write(keyword, ConsoleColor.Yellow);
                    TextOut.WriteLine("] not recognized.", ConsoleColor.Red);
                    break;
            }
        }

        private static void ListGameManagers(RunGame game)
            => game.ListImageManagers();

        private static void ListImages(RunGame game)
        {
            TextOut.WriteLine("Available image managers:", ConsoleColor.Blue);
            int index = 1;
            foreach (ImageManager currentManager in game.ImageManagers)
            {
                TextOut.Write($"{index}.".PadRight(DefaultValues.ListIndexPadding), ConsoleColor.Blue);
                TextOut.WriteLine(currentManager.name, ConsoleColor.Yellow);
                index++;
            }
            TextOut.Write("Enter the number of the image manager: ");
            _ = uint.TryParse(Console.ReadLine() ?? "", out uint selection);
            if (!OutOfRangeCheck(selection, game))
                return;
            ImageManager manager = game.ImageManagers[(int)selection];
            int imageCount = manager.images.Count;
            string managerName = manager.name;
            ImageSpanPrompt(imageCount, managerName);
            string input = (Console.ReadLine() ?? "").Replace(" ", "");
            if (!RegexCheck(input))
                return;
            string[] splitByComma = input.Split(',');
            if (!IntTupleList(splitByComma, out (int, int)[] intTupleList))
                return;
            CheckForPixelThreshold(manager, intTupleList);
            PrintImages(intTupleList, manager);
        }

        private static bool OutOfRangeCheck(uint selection, RunGame game)
        {
            if (selection - 1 > game.ImageManagers.Count)
            {
                TextOut.WriteLine("Provided number too large.\nPlease select an existing image manager.", ConsoleColor.Red);
                return false;
            }
            return true;
        }

        private static void ImageSpanPrompt(int imageCount, string managerName)
        {
            TextOut.Write("There are [", ConsoleColor.Blue);
            TextOut.Write(imageCount, ConsoleColor.Yellow);
            TextOut.WriteLine($"] images in image manager [{managerName}].");
            TextOut.WriteLine("Enter the range of images to print.", ConsoleColor.Blue);
            TextOut.Write("For instance 4-18 or 1-4,7-8: ");
        }

        private static bool RegexCheck(string input)
        {
            if (!Regex.IsMatch(input, @"^[0-9\-,]+$"))
            {
                TextOut.WriteLine("Input contains invalid characters or is empty.", ConsoleColor.Red);
                return false;
            }
            return true;
        }

        private static bool IntTupleList(string[] splitByComma, out (int, int)[] intTupleList)
        {
            intTupleList = new (int, int)[splitByComma.Length];
            for (int i = 0; i < splitByComma.Length; i++)
            {
                string[] splitNumbers = splitByComma[i].Split('-');
                if (splitNumbers.Length != 2)
                {
                    TextOut.WriteLine("At least one span of images was formatted incorrectly.", ConsoleColor.Red);
                    TextOut.Write("Incorrectly formatted: ");
                    TextOut.WriteLine(splitByComma[i], ConsoleColor.Yellow);
                    return false;
                }
                _ = int.TryParse(splitNumbers[0], out int first);
                _ = int.TryParse(splitNumbers[1], out int second);
                if (first > second)
                {
                    TextOut.Write("The second number was larger on the following span: ", ConsoleColor.Red);
                    TextOut.WriteLine(splitByComma[i], ConsoleColor.Yellow);
                }
                intTupleList[i] = (first, second);
            }
            return true;
        }

        private static void CheckForPixelThreshold(ImageManager manager, (int, int)[] intTupleList)
        {
            if (GetTotalPixelAmount(manager, intTupleList) > DefaultValues.PixelWarningThreshold)
            {
                TextOut.WriteLine("Woah there! you're currently trying to print out a lot of pixels.", ConsoleColor.Yellow);
                TextOut.Write("Type in 'yes' to confirm. Otheriwse, the process is cancelled: ");
                if (!(Console.ReadLine() ?? "").Equals("yes", StringComparison.OrdinalIgnoreCase))
                {
                    TextOut.Write("Tast cancelled.", ConsoleColor.Blue);
                    return;
                }
            }
        }
        private static int GetTotalPixelAmount(ImageManager manager, (int, int)[] intTupleList)
        {
            int pixelCount = 0;
            foreach ((int, int) tuple in intTupleList)
            {
                int startCount = tuple.Item1 - 1;
                int endCount = tuple.Item2 - 1;
                for (int i = startCount; i < endCount; i++)
                {
                    int[] dimensions = manager.images[i].size;
                    pixelCount += (dimensions[0] * dimensions[1]);
                }
                if (pixelCount >= DefaultValues.PixelWarningThreshold)
                    return pixelCount;
            }
            return pixelCount;
        }

        private static void PrintImages((int, int)[] intTupleList, ImageManager manager)
        {
            foreach ((int, int) tuple in intTupleList)
            {
                int startCount = tuple.Item1 - 1;
                int endCount = tuple.Item2 - 1;
                for (int i = startCount; i < endCount; i++)
                {
                    TextOut.WriteLine($"Image {i}:", ConsoleColor.Blue);
                    PrintImage.FromImage(manager.images[i]);
                }
            }
            TextOut.WriteLine("Printing done!", ConsoleColor.Green);
        }
    }
}