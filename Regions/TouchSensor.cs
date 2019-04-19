using System.Collections.Generic;

namespace Euler.Regions
{
    public class TouchSensor
    {
        private const int Processed = -1;
        private const int Touched = 1;

        private readonly List<List<int>> _grid;
        private readonly List<Orientation> _orientations;

        public TouchSensor(ITouchDevice device)
        {
            _grid = device.GetScreenState();

            _orientations = new List<Orientation>{
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

        private int CountTouchedRegions(List<List<int>> grid)
        {
            if(grid.Count == 0)
                return 0;

            int count = 0;

            for (var row = 0; row < grid.Count; row++)
            {
                for (var col = 0; col < grid[0].Count; col++)
                {
                    if (grid[row][col] == 1)
                    {
                        ProcessTouchedRegion(grid, row, col);
                        ++count;
                    }
                }
            }

            RestoreTouchState(grid);

            return count;
        }

        private void RestoreTouchState(List<List<int>> grid)
        {
            for (var row = 0; row < grid.Count; row++)
            {
                for (var col = 0; col < grid[0].Count; col++)
                {
                    if (grid[row][col] == Processed)
                    {
                        grid[row][col] = Touched;
                    }
                }
            }
        }

        private void ProcessTouchedRegion(List<List<int>> grid, int r, int c)
        {
            if (r < 0 || r >= grid.Count || c < 0 || c >= grid[0].Count || grid[r][c] != Touched)
                return;

            grid[r][c] = Processed;

            for(var idx = 0; idx < _orientations.Count; idx++)
            {
                var orientation = _orientations[idx];
                ProcessTouchedRegion(grid, r + orientation.Row, c + orientation.Column);
            }
        }

        private class Orientation
        {
            public Orientation(int row, int column)
            {
                this.Row = row;
                this.Column = column;
            }
            
            public int Row { get; set; }
            public int Column { get; set; }
        }
    }
}
