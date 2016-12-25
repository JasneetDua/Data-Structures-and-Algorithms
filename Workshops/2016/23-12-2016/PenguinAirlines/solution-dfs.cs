using System;
using System.Collections.Generic;
using System.Linq;

namespace PenguinAirlines
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var adjList = new List<int>[n];
            for (int i = 0; i < n; ++i)
            {
                var line = Console.ReadLine();
                if (line == "None")
                {
                    adjList[i] = new List<int>();
                }
                else
                {
                    adjList[i] = line.Split(' ')
                        .Select(int.Parse)
                        .ToList();
                }
            }

            var componentId = new int[n];
            var visited = new bool[n];

            for (int i = 0; i < n; ++i)
            {
                if (!visited[i])
                {
                    Dfs(i, adjList, visited, i, componentId);
                }
            }


            while (true)
            {
                var line = Console.ReadLine();
                if (line[0] == 'H')
                {
                    break;
                }

                var strs = line.Split(' ');
                int a = int.Parse(strs[0]);
                int b = int.Parse(strs[1]);

                if (componentId[a] == componentId[b])
                {
                    if (adjList[a].Contains(b))
                    {
                        Console.WriteLine("There is a direct flight.");
                    }
                    else
                    {
                        Console.WriteLine("There are flights, unfortunately they are not direct, grandma :(");
                    }
                }
                else
                {
                    Console.WriteLine("No flights available.");
                }
            }
        }

        static void Dfs(int x, List<int>[] adjList, bool[] visited, int id, int[] componentId)
        {
            visited[x] = true;
            componentId[x] = id;

            foreach (var y in adjList[x])
            {
                if (!visited[y])
                {
                    Dfs(y, adjList, visited, id, componentId);
                }
            }
        }
    }
}
