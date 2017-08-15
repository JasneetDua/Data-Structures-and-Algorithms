using System;
using System.Collections.Generic;
using System.Linq;

namespace Reconstruction
{
    struct Edge
    {
        public int From;
        public int To;
        public int Price;
    }

    class Program
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var prices = new bool[n, n];

            var edges = new List<Edge>();

            for (int i = 0; i < n; ++i)
            {
                var line = Console.ReadLine();
                for (int j = i + 1; j < n; ++j)
                {
                    prices[i, j] = line[j] == '1';
                }
            }

            for (int i = 0; i < n; ++i)
            {
                var line = Console.ReadLine();
                for (int j = i + 1; j < n; ++j)
                {
                    if (prices[i, j])
                    {
                        continue;
                    }

                    edges.Add(new Edge { From = i, To = j, Price = GetValue(line[j]) });
                }
            }

            var total = 0;

            for (int i = 0; i < n; ++i)
            {
                var line = Console.ReadLine();
                for (int j = i + 1; j < n; ++j)
                {
                    if (prices[i, j])
                    {
                        var value = GetValue(line[j]);
                        total += value;
                        edges.Add(new Edge { From = i, To = j, Price = -value });
                    }
                }
            }

            edges.Sort((x, y) => x.Price - y.Price);

            var unionFindArray = Enumerable.Range(0, n)
                .Select(_ => -1)
                .ToArray();

            foreach (var edge in edges)
            {
                if (Union(unionFindArray, edge.From, edge.To))
                {
                    total += edge.Price;
                }
            }

            Console.WriteLine(total);
        }

        static int Find(int[] array, int x)
        {
            if (array[x] == -1)
            {
                return x;
            }
            array[x] = Find(array, array[x]);
            return array[x];
        }

        static bool Union(int[] array, int x, int y)
        {
            x = Find(array, x);
            y = Find(array, y);

            if (x == y)
            {
                return false;
            }

            array[x] = y;
            return true;
        }

        //static int[,] ReadMatrix(int n)
        //{
        //    var matrix = new int[n, n];
        //    for (int i = 0; i < n; ++i)
        //    {
        //        var line = Console.ReadLine();
        //        for (int j = 0; j < n; ++j)
        //        {
        //            matrix[i, j] = GetValue(line[j]);
        //        }
        //    }

        //    return matrix;
        //}

        static int GetValue(char c)
        {
            if (char.IsUpper(c))
            {
                return c - 'A';
            }

            return c - 'a' + 26;
        }
    }
}
