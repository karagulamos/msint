using System;
using System.Diagnostics.Contracts;
using Euler.Cache;
using Euler.Regions;

namespace Euler
{
    class Program
    {
        static void Main(string[] args)
        {
            RunTouchDetectionTest(1);
            RunLruCacheTest(2);           
        }

        public static void RunTouchDetectionTest(int testNumber)
        {
            var passText = $"Test {testNumber} Passed.";
            var failText = $"Test {testNumber} Failed.";

            var sensor = new TouchSensor(new XTouchDevice());
            Contract.Assert(sensor.GetTouchCount() == 4, failText);

            sensor = new TouchSensor(new YTouchDevice());
            Contract.Assert(sensor.GetTouchCount() == 3, failText);

            sensor = new TouchSensor(new ZTouchDevice());
            Contract.Assert(sensor.GetTouchCount() == 0, failText);

            Console.WriteLine(passText);
        }

        public static void RunLruCacheTest(int testNumber)
        {
            var passText = $"Test {testNumber} Passed.";
            var failText = $"Test {testNumber} Failed.";

            var models = Model.GetSamples();
            var cache = new FastBoundedCache<string, int>(5);

            foreach(var model in models)
            {
                cache.Insert(model.Name, model.Content);
            } 
            
            Contract.Assert(cache.ToString() == "[1, 2, 3, 4, 5]", failText);
              
            cache.Retrieve("five");
            cache.Retrieve("two");
            Contract.Assert(cache.ToString() == "[2, 5, 1, 3, 4]", failText);

            cache.Insert("three", 3);
            Contract.Assert(cache.ToString() == "[2, 5, 1, 4, 3]", failText);

            cache.Retrieve("four");
            Contract.Assert(cache.ToString() == "[4, 2, 5, 1, 3]", failText);

            var emptyCache = new FastBoundedCache<string, int>(0);
            Contract.Assert(emptyCache.ToString() == "[]", failText);

            Console.WriteLine(passText);
        }
    }
}
