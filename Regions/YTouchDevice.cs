namespace Euler.Regions
{
    public class YTouchDevice : ITouchDevice
    {
        public int[][] GetScreenState()
        {
            return new int[][]{
                new []{0, 1, 0, 0, 0},
                new []{1, 1, 1, 0, 0},
                new []{0, 1, 0, 1, 0},
                new []{1, 0, 1, 1, 1},
                new []{1, 1, 0, 1, 0},
            };
        }
    }
}