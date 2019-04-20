using System;

namespace Euler.Cache
{
    public class Model
    {
        public Model(string name, int content)
        {
            this.Name = name;
            this.Content = content;
        }
        public string Name { get; }
        public int Content { get; }

        public static Model[] GetSamples()
        {
            return new Model[]
            {
                new Model("one", 1),
                new Model("one", 1),
                new Model("two", 2),
                new Model("three", 3),
                new Model("four", 4),
                new Model("five", 5),
            };
        }
    }
}