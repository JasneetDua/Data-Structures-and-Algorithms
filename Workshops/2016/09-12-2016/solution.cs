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

            int maxIndex = 0;

            var visited = new bool[n];
            var path = new int[n];
            path[0] = 0;
            Dfs(0, neighbours, visited, path);

            for (int i = 0; i < n; i++)
            {
                if (path[maxIndex] < path[i])
                {
                    maxIndex = i;
                }
            }

            visited = new bool[n];
            path = new int[n];
            path[maxIndex] = 0;
            Dfs(maxIndex, neighbours, visited, path);

            Console.WriteLine(path.Max());
        }

        static void Dfs(int x, List<Tuple<int, int>>[] neighbours, bool[] visited, int[] path)
        {
            visited[x] = true;
            foreach (var edge in neighbours[x])
            {
                if (visited[edge.Item1])
                {
                    continue;
                }

                path[edge.Item1] = path[x] + edge.Item2;
                Dfs(edge.Item1, neighbours, visited, path);
            }
        }
    }
}
