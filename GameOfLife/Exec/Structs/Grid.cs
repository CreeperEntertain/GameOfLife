using GameOfLife.Exec.FunctionClasses.ImageManagement;

namespace GameOfLife.Exec.Structs
{
    internal struct Grid
    {
        public Cell[,] cells { get; set; }

        private ImageCreationClass imageCreation = new();

        public Grid(int[] dimensions)
        {
            if (!imageCreation.CheckDimensions(dimensions))
                throw new ArgumentException("Invalid grid dimensions.");
            cells = new Cell[dimensions[0], dimensions[1]];
        }

        public bool[,] GetStates()
        {
            int xScale = cells.GetLength(0);
            int yScale = cells.GetLength(1);
            bool[,] stateArray = new bool[xScale, yScale];
            for (int x = 0; x < xScale; x++)
                for (int y = 0; y < yScale; y++)
                    stateArray[x, y] = cells[x, y].alive;
            return stateArray;
        }
        public void SetStates(bool[,] states)
        {
            for (int x = 0; x < states.GetLength(0); x++)
                for (int y = 0; y < states.GetLength(1); y++)
                    cells[x, y].alive = states[x, y];
        }

        public void UpdateCells()
        {
            int xScale = cells.GetLength(0);
            int yScale = cells.GetLength(1);
            bool[,] newStates = new bool[xScale, yScale];
            for (int x = 0; x < xScale; x++)
                for (int y = 0; y < yScale; y++)
                    newStates[x, y] = GetUpdatedSingleCell(x, y, xScale, yScale);
            SetStates(newStates);
        }
        private bool GetUpdatedSingleCell(int x, int y, int xBounds, int yBounds)
        {
            // TODO: Neighbor-based state updating
            return false;
        }
    }
}