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

            var field = new int[n + 1];
            var memo = new long[n + 1];
            memo[0] = -1;
            memo[1] = -1;
            field[0] = 0;
            field[1] = f;
            for (int i = 2; i <= n; ++i)
            {
                field[i] = (int)(((long)field[i - 1] * a + b) % m);
                memo[i] = -1;
            }

            var result = MinJump(field, memo, k, 0, 0);
            Console.WriteLine(result);
        }

        static long MinJump(int[] field, long[] memo, int k, int index, long sum)
        {
            if (index >= field.Length)
            {
                return sum;
            }

            if (memo[index] > -1)
            {
                return memo[index];
            }

            var best = long.MaxValue;
            for (int j = 1; j <= k; ++j)
            {
                var current = MinJump(field, memo, k, index + j, sum + field[index]);
                if (best > current)
                {
                    best = current;
                }
            }

            memo[index] = best;
            return best;
        }
    }
}
