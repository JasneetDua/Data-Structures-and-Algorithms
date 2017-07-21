using System;

namespace SuperMario
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
            var f = int.Parse(strs[0]);
            var a = int.Parse(strs[1]);
            var b = int.Parse(strs[2]);
            var m = int.Parse(strs[3]);

            var field = new long[n + 1];
            field[0] = f;
            field[n] = 0;
            for (int i = 1; i < n; ++i)
            {
                field[i] = (field[i - 1] * a + b) % m;
            }

            for (int i = k; i <= n; ++i)
            {
                var best = long.MaxValue;
                for (int j = i - k; j < i; ++j)
                {
                    var current = field[j];
                    if (best > current)
                    {
                        best = current;
                    }
                }

                field[i] += best;
            }

            Console.WriteLine(field[n]);
        }
    }
}
