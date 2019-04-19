using System.Collections.Generic;

namespace Euler.Regions
{
    public class XTouchDevice : ITouchDevice
    {
        public List<List<int>> GetScreenState()
        {
            return new List<List<int>>{
                new List<int>{0, 1, 1, 0, 0},
                new List<int>{0, 1, 0, 1, 1},
                new List<int>{1, 0, 0, 1, 1},
                new List<int>{1, 1, 0, 0, 0},
                new List<int>{1, 0, 0, 0, 0},
            };
        }
    }
}
