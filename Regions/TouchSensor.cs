using System.Collections.Generic;

namespace Euler.Regions
{
    public class TouchSensor
    {
        private const int Processed = -1;
        private const int Touched = 1;

        private readonly int[][] _grid;
        private readonly Orientation[] _orientations;

        public TouchSensor(ITouchDevice device)
        {
            _grid = device.GetScreenState();

            _orientations = new[] {
                new Orientation(0, 1),
                new Orientation(0, -1),
                new Orientation(1, 0),
                new Orientation(-1, 0),
            };
        }
        public int GetTouchCount()
        {
            return CountTouchedRegions(_grid);
        }

        private int CountTouchedRegions(int[][] grid)
        {
            if(grid.Length == 0)
                return 0;

            int count = 0;

            for (var row = 0; row < grid.Length; row++)
            {
                for (var col = 0; col < grid[0].Length; col++)
                {
                    if (grid[row][col] != Touched)
                        continue;
                    
                    ProcessTouchRegion(grid, row, col);
                    ++count;
                }
            }

            RestoreTouchState(grid);

            return count;
        }

        private void RestoreTouchState(int[][] grid)
        {
            for (var row = 0; row < grid.Length; row++)
            {
                for (var col = 0; col < grid[0].Length; col++)
                {
                    if (grid[row][col] == Processed)
                    {
                        grid[row][col] = Touched;
                    }
                }
            }
        }

        private void ProcessTouchRegion(int[][] grid, int r, int c)
        {
            if (r < 0 || r >= grid.Length || c < 0 || c >= grid[0].Length || grid[r][c] != Touched)
                return;

            grid[r][c] = Processed;

            for(var idx = 0; idx < _orientations.Length; idx++)
            {
                var orientation = _orientations[idx];
                ProcessTouchRegion(grid, r + orientation.Row, c + orientation.Column);
            }
        }

        private class Orientation
        {
            public Orientation(int row, int column)
            {
                this.Row = row;
                this.Column = column;
            }
            
            public int Row { get; }
            public int Column { get; }
        }
    }
}
