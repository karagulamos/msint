namespace Euler.Regions
{
    public class SparseTouchDevice : ITouchDevice
    {
        public int[][] GetScreenState()
        {
            return new int[][]{
                new []{1, 0, 1, 0, 1},
                new []{0, 0, 0, 0, 0},
                new []{0, 1, 0, 1, 0},
                new []{1, 0, 0, 0, 0},
                new []{0, 0, 1, 0, 1},
            };
        }
    }
}