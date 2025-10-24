using GameOfLife.Exec.Utilities.ImageRelated;
using System.Runtime.CompilerServices;

namespace GameOfLife.Exec.Structs
{
    internal struct Grid
    {
        public Cell[,] cells { get; set; }

        private readonly int[] dx = [-1, 0, 1, -1, 1, -1, 0, 1];
        private readonly int[] dy = [-1, -1, -1, 0, 0, 1, 1, 1];

        public Grid(int[] dimensions)
        {
            if (!ImageCreation.CheckDimensions(dimensions))
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
        public void SimulateSteps(byte steps)
        {
            for (int i = 0; i < steps; i++)
                SetStates(GetUpdatedCells());
        }

        public bool[,] GetUpdatedCells()
        {
            int xScale = cells.GetLength(0);
            int yScale = cells.GetLength(1);
            bool[,] newStates = new bool[xScale, yScale];
            for (int x = 0; x < xScale; x++)
                for (int y = 0; y < yScale; y++)
                    newStates[x, y] = GetUpdatedSingleCell(x, y, xScale, yScale);
            return newStates;
        }
        private bool GetUpdatedSingleCell(int x, int y, int xBounds, int yBounds)
        {
            byte aliveCount = 0;
            for (int i = 0; i < 8; i++)
            {
                int nx = Wrap(x + dx[i], xBounds);
                int ny = Wrap(y + dy[i], yBounds);
                if (cells[nx, ny].alive)
                    aliveCount++;
            }

            bool isThisAlive = cells[x, y].alive;

            if (isThisAlive)
                return (aliveCount == 2 || aliveCount == 3);
            return (aliveCount == 3);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int Wrap(int value, int max)
            => (value % max + max) % max;
    }
}