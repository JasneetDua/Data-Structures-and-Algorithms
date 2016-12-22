using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diameter
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var neighbours = new List<Tuple<int, int>>[n];

            for (int i = 1; i < n; ++i)
            {
                var strs = Console.ReadLine().Split(' ');
                int a = int.Parse(strs[0]);
                int b = int.Parse(strs[1]);
                int len = int.Parse(strs[2]);

                if (neighbours[a] == null)
                {
                    neighbours[a] = new List<Tuple<int, int>>();
                }
                neighbours[a].Add(new Tuple<int, int>(b, len));

                if (neighbours[b] == null)
                {
                    neighbours[b] = new List<Tuple<int, int>>();
                }
                neighbours[b].Add(new Tuple<int, int>(a, len));
            }

            var maxPath = new int[n];
            Dfs(0, -1, neighbours, maxPath);
            Console.WriteLine(maxPath.Max());
        }

        static int Dfs(int x, int y, List<Tuple<int, int>>[] neighbours, int[] maxPath)
        {
            int maxDepth = 0;
            int maxDepth2 = 0;

            foreach (var edge in neighbours[x])
            {
                if (edge.Item1 == y)
                {
                    continue;
                }

                int depth = Dfs(edge.Item1, x, neighbours, maxPath) + edge.Item2;
                if (maxDepth < depth)
                {
                    maxDepth2 = maxDepth;
                    maxDepth = depth;
                }
                else if(maxDepth2 < depth)
                {
                    maxDepth2 = depth;
                }
            }

            maxPath[x] = maxDepth + maxDepth2;

            return maxDepth;
        }
    }
}
