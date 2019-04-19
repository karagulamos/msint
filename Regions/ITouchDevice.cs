using System.Collections.Generic;

namespace Euler.Regions
{
    public interface ITouchDevice
    {
        List<List<int>> GetScreenState();
    }
}
