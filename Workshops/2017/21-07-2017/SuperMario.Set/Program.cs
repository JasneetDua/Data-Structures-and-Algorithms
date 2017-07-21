using System;
using Wintellect.PowerCollections;

namespace SuperMario.Dijkstra
{
    class Program
    {
        static void Main()
        {
            var strs = Console.ReadLine().Split(' ');
            var n = int.Parse(strs[0]);
            var k = int.Parse(strs[1]);

            if (n < k)
            {
                Console.WriteLine(0);
                return;
            }

            strs = Console.ReadLine().Split(' ');
            var f = long.Parse(strs[0]);
            var a = int.Parse(strs[1]);
            var b = int.Parse(strs[2]);
            var m = int.Parse(strs[3]);

            var set = new OrderedBag<long>();
            var result = new long[k];
            result[0] = (int)f;

            set.Add(f);
            for (int i = 1; i < k; ++i)
            {
                f = (f * a + b) % m;
                result[i] = f;
                set.Add(f);
            }

            for (int i = k; i < n; ++i)
            {
                f = (f * a + b) % m;

                var cell = set.GetFirst() + f;
                set.Add(cell);
                set.Remove(result[i % k]);
                result[i % k] = cell;
            }

            Console.WriteLine(set.GetFirst());
        }
    }
}
