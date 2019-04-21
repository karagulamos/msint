namespace Euler.Regions
{
    public class ZTouchDevice : ITouchDevice
    {
        public int[][] GetScreenState()
        {
            return new int[][]{
                new []{0, 0, 0, 0, 0},
                new []{0, 0, 0, 0, 0},
                new []{0, 0, 0, 0, 0},
                new []{0, 0, 0, 0, 0},
                new []{0, 0, 0, 0, 0},
            };
        }
    }
}