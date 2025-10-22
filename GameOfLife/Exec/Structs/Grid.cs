using GameOfLife.Exec.FunctionClasses.ImageManagement;

namespace GameOfLife.Exec.Structs
{
    internal struct Grid
    {
        public Cell[,] cellArray { get; set; }

        private ImageCreationClass imageCreation = new();

        public Grid(int[] dimensions)
        {
            if (!imageCreation.CheckDimensions(dimensions))
                throw new ArgumentException("Invalid grid dimensions.");
            cellArray = new Cell[dimensions[0], dimensions[1]];
        }

        public bool[,] GetStates()
        {
            int xScale = cellArray.GetLength(0);
            int yScale = cellArray.GetLength(1);
            bool[,] stateArray = new bool[xScale, yScale];
            for (int x = 0; x < xScale; x++)
                for (int y = 0; y < yScale; y++)
                    stateArray[x, y] = cellArray[x, y].alive;
            return stateArray;
        }
        public void SetStates(bool[,] states)
        {
            for (int x = 0; x < states.GetLength(0); x++)
                for (int y = 0; y < states.GetLength(1); y++)
                    cellArray[x, y].alive = states[x, y];
        }
    }
}