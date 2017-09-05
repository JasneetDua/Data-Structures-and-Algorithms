using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _Beers
{
    class Node
    {
        public Node(string name, int distance)
        {
            this.Name = name;
            this.Distance = distance;
        }

        public int Distance { get; set; }

        public string Name { get; set; }
    }

    class MainClass
    {
        private static int n = 0;
        private static int m = 0;

        static Dictionary<string, List<Node>> ReadGraph()
        {
            var nmb = Console.ReadLine()
                             .Split(' ')
                             .Select(int.Parse)
                             .ToArray();
            n = nmb[0];
            m = nmb[1];
            var b = nmb[2];

            var graph = new Dictionary<string, List<Node>>();

            var vertices = new List<string>(
                Enumerable.Range(1, b)
                                  .Select(_ => Console.ReadLine())
                                  .ToArray()
                                  );

            vertices.Add("0 0");
            vertices.Add((n - 1) + " " + (m - 1));

            for (int i = 0; i < vertices.Count; i++)
            {
                for (var j = i + 1; j < vertices.Count; j++)
                {
                    var from = vertices[i];
                    var to = vertices[j];
                    var beerBonus = j == vertices.Count - 1
                        ? 0
                        : -5;
                    var fromParams = from.Split(' ')
                        .Select(int.Parse)
                        .ToArray();
                    var toParams = to.Split(' ')
                        .Select(int.Parse)
                        .ToArray();
                    var distance = Math.Abs(fromParams[0] - toParams[0]) +
                                   Math.Abs(fromParams[1] - toParams[1]) +
                                   beerBonus;

                    AddEdge(graph, from, to, distance);
                    AddEdge(graph, to, from, distance);
                }
            }

            return graph;

        }

        private static void AddEdge(Dictionary<string, List<Node>> graph, string from, string to, int distance)
        {
            if (graph.ContainsKey(from) == false)
            {
                graph[from] = new List<Node>();
            }
            graph[from].Add(new Node(to, distance));
        }
        private static int Dijkstra(Dictionary<string, List<Node>> graph)
        {
            var INFINITY = 1 << 25;

            var d = new Dictionary<string, int>();
            foreach (var vertex in graph.Keys)
            {
                d[vertex] = INFINITY;
            }
            d["0 0"] = 0;

            var used = new HashSet<string>();

            while (used.Count < graph.Count)
            {
                var best = "";
                var bestVal = INFINITY;
                var isSelected = false;
                foreach (var vertex in graph.Keys)
                {
                    if (used.Contains(vertex))
                    {
                        continue;
                    }

                    if (bestVal <= d[vertex])
                    {
                        continue;
                    }

                    bestVal = d[vertex];
                    best = vertex;
                    isSelected = true;
                }

                used.Add(best);

                if (isSelected == false)
                {
                    break;
                }

                foreach (var next in graph[best])
                {
                    if (d[next.Name] < d[best] + next.Distance)
                    {
                        continue;
                    }
                    d[next.Name] = d[best] + next.Distance;
                }
            }

            return d[(n - 1) + " " + (m - 1)];
        }

        public static void Main(string[] args)
        {
            //FakeInput();
            var graph = ReadGraph();
            var result = Dijkstra(graph);
            Console.WriteLine(result);
        }

        private static void FakeInput()
        {
            var input = @"7 8 3
4 1
7 3
1 6";

            Console.SetIn(new StringReader(input));
        }
    }
}
