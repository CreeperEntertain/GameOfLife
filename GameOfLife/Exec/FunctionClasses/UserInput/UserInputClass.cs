namespace GameOfLife.Exec.FunctionClasses.UserInput
{
    internal class UserInputClass
    {
        public UserInputClass()
        {

        }

        public int[] ProvideScales()
        {
            Console.WriteLine("Type 'cancel' to cancel.");
            Console.Write("WIDTH:");
            string width = Console.ReadLine() ?? "";
            if (width.ToLower() == "cancel")
                return [];
            Console.Clear();
            Console.WriteLine("Type 'cancel' to cancel.");
            Console.Write("HEIGTH:");
            string height = Console.ReadLine() ?? "";
            if (height.ToLower() == "cancel")
                return [];
            Console.Clear();

            bool hasWidth = int.TryParse(width, out int providedWidth);
            bool hasHeight = int.TryParse(height, out int providedHeight);
            if (!hasWidth || !hasHeight)
                return [-1, -1];
            return [providedWidth, providedHeight];
        }
    }
}