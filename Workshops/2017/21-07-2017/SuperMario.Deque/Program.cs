using System;
using Wintellect.PowerCollections;

namespace SuperMario.Deque
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

            var deque = new Deque<Tuple<long, int>>();

            deque.AddToBack(new Tuple<long, int>(f, 0));
            for (int i = 1; i < k; ++i)
            {
                f = (f * a + b) % m;
                while (deque.Count > 0 && deque[deque.Count - 1].Item1 >= f)
                {
                    deque.RemoveFromBack();
                }
                deque.AddToBack(new Tuple<long, int>(f, i));
            }

            for (int i = k; i < n; ++i)
            {
                f = (f * a + b) % m;
                while (deque[0].Item2 < i - k)
                {
                    deque.RemoveFromFront();
                }
                var cell = f + deque[0].Item1;
                while (deque.Count > 0 && deque[deque.Count - 1].Item1 >= cell)
                {
                    deque.RemoveFromBack();
                }
                deque.AddToBack(new Tuple<long, int>(cell, i));
            }

            while (deque[0].Item2 < n - k)
            {
                deque.RemoveFromFront();
            }
            Console.WriteLine(deque[0].Item1);
        }
    }
}
