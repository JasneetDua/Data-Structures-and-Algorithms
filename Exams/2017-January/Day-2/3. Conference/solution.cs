using System;
using System.Collections.Generic;
using System.Linq;

namespace Conference
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstLine = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int count = firstLine[0];
            int pairs = firstLine[1];

            bool[] visited = new bool[count];
            Dictionary<int, HashSet<int>> graph = new Dictionary<int, HashSet<int>>();

            for (int i = 0; i < pairs; i++)
            {
                int[] pair = Console.ReadLine().Split().Select(int.Parse).ToArray();
                if (!graph.ContainsKey(pair[0]))
                {
                    graph[pair[0]] = new HashSet<int>();
                }

                if (!graph.ContainsKey(pair[1]))
                {
                    graph[pair[1]] = new HashSet<int>();
                }

                graph[pair[0]].Add(pair[1]);
                graph[pair[1]].Add(pair[0]);
            }

            List<long> componentsNodesCount = new List<long>();
            foreach (int node in graph.Keys)
            {
                int componentCount = DFS(node, graph, visited);
                if (componentCount != 0)
                {
                    componentsNodesCount.Add(componentCount);
                }
            }

            long singletonsCount = count - graph.Keys.Count;

            long pairsCombinations = 0;
            for (int i = 0; i < componentsNodesCount.Count - 1; i++)
            {
                pairsCombinations += componentsNodesCount[i] * singletonsCount;
                for (int j = i + 1; j < componentsNodesCount.Count; j++)
                {
                    pairsCombinations += componentsNodesCount[i] * componentsNodesCount[j];
                }
            }

            if (singletonsCount > 0)
            {
                if (componentsNodesCount.Count > 0)
                {
                    pairsCombinations += componentsNodesCount[componentsNodesCount.Count - 1] * singletonsCount;
                }

                pairsCombinations += (singletonsCount * (singletonsCount - 1)) / 2;
            }

            Console.WriteLine(pairsCombinations);
        }

        private static int DFS(int node, IDictionary<int, HashSet<int>> graph, bool[] visited)
        {
            int result = 0;
            if (!visited[node])
            {
                visited[node] = true;
                result++;
                if (graph.ContainsKey(node))
                {
                    foreach (int child in graph[node])
                    {
                        if (!visited[child])
                        {
                            result += DFS(child, graph, visited);
                        }
                    }
                }
            }

            return result;
        }
    }
}