using System;
using Euler.Regions;

namespace Euler
{
    class Program
    {
        static void Main(string[] args)
        {
            var device = new XTouchDevice();
            var sensor = new TouchSensor(device);

            Console.WriteLine("Number of fingers detected: {0}", sensor.GetTouchCount());
        }
    }
}
