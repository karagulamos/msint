namespace Euler.Regions
{
    public class OneTouchDevice : ITouchDevice
    {
        public int[][] GetScreenState()
        {
            return new int[][]{
                new []{1, 1, 1, 1, 1},
                new []{1, 1, 1, 1, 1},
                new []{1, 1, 1, 1, 1},
                new []{1, 1, 1, 1, 1},
                new []{1, 1, 1, 1, 1}
            };
        }
    }
}