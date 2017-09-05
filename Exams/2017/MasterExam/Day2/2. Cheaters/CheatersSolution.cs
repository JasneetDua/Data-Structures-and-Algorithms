using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _Cheaters
{
    class CheatersSolution
    {
        class Node : IComparable<Node>
        {
            public string Name { get; set; }
            public bool IsParent { get; set; }

            public int CompareTo(Node other)
            {
                return this.Name.CompareTo(other.Name);
            }
        }

        class TopoNode
        {
            public string Name { get; set; }
            public ISet<string> Children { get; set; }
            public int ParentsCount { get; set; }

            public TopoNode(string name)
            {
                this.Name = name;
                this.ParentsCount = 0;
                this.Children = new SortedSet<string>();
            }

            public void Add(string childName)
            {
                this.Children.Add(childName);
            }
        }

        private static void AddEdge(Dictionary<string, List<Node>> subjectGraph, string x, string y, bool isParent)
        {
            if (subjectGraph.ContainsKey(x) == false)
            {
                subjectGraph[x] = new List<Node>();
            }

            subjectGraph[x].Add(new Node()
            {
                Name = y,
                IsParent = isParent
            });
        }

        private static Dictionary<string, Dictionary<string, List<Node>>> ReadGraph()
        {
            var graph = new Dictionary<string, Dictionary<string, List<Node>>>();
            var edges = int.Parse(Console.ReadLine());
            for (int i = 0; i < edges; i++)
            {
                var dep = Console.ReadLine().Split(' ');
                var x = dep[0];
                var y = dep[1];
                var subject = dep[2];
                if (dep.Length > 3)
                {
                    var builder = new StringBuilder();
                    for (var j = 2; j < dep.Length; j++)
                    {
                        builder.Append(dep[j]);
                        builder.Append(" ");
                    }

                    subject = builder.ToString().Trim();
                }

                if (graph.ContainsKey(subject) == false)
                {
                    graph[subject] = new Dictionary<string, List<Node>>();
                }

                AddEdge(graph[subject], x, y, true);
                AddEdge(graph[subject], y, x, false);
            }

            return graph;
        }


        private static Dictionary<string, List<string>> BuildSubjectGraphForName(Dictionary<string, Dictionary<string, List<Node>>> graph, string subject, string name)
        {
            var subjectGraph = graph[subject];

            var nameSubjectGraph = new Dictionary<string, List<string>>();
            var stack = new Stack<string>();
            stack.Push(name);

            while (stack.Count > 0)
            {
                var current = stack.Pop();
                foreach (var next in subjectGraph[current])
                {
                    if (next.IsParent == false)
                    {
                        continue;
                    }

                    if (nameSubjectGraph.ContainsKey(next.Name) == false)
                    {
                        nameSubjectGraph[next.Name] = new List<string>();
                    }
                    nameSubjectGraph[next.Name].Add(current);
                    stack.Push(next.Name);
                }
            }

            return nameSubjectGraph;
        }

        private static List<string> TopologicalSort(Dictionary<string, TopoNode> graph)
        {
            var sources = new SortedSet<string>();
            graph.Where(pair => pair.Value.ParentsCount == 0)
                 .Select(pair => pair.Key)
                 .ToList()
                 .ForEach(source => sources.Add(source));

            var result = new List<string>();
            var used = new HashSet<string>();
            while (sources.Count > 0)
            {
                var source = sources.Min;
                used.Add(source);
                sources.Remove(source);

                result.Add(source);

                if(graph.ContainsKey(source) == false)
                {
                    continue;
                }

                foreach(var next in graph[source].Children)
                {
                    if (graph.ContainsKey(next) == false)
                    {
                        continue;
                    }

                    if(used.Contains(next)) 
                    {
                        continue;
                    }

                    --graph[next].ParentsCount;

                    if(graph[next].ParentsCount == 0)
                    {
                        sources.Add(next);
                    }
                }
            }

            return result;
        }

        private static List<string> FindCheatersList(Dictionary<string, Dictionary<string, List<Node>>> allgraph, string name, string subject)
        {
            var subjectGraph = BuildSubjectGraphForName(allgraph, subject, name);

            var graph = new Dictionary<string, TopoNode>();
            foreach (var pair in subjectGraph)
            {
                if (graph.ContainsKey(pair.Key) == false)
                {
                    graph[pair.Key] = new TopoNode(pair.Key);
                }

                foreach (var child in pair.Value)
                {
                    if (graph.ContainsKey(child) == false)
                    {
                        graph[child] = new TopoNode(child);
                    }

                    ++graph[child].ParentsCount;

                    graph[pair.Key].Add(child);
                }
            }

            var result = TopologicalSort(graph);

            return result;
        }

        public static void Main(string[] args)
        {
            //FakeInput();

            var graph = ReadGraph();
            var commandsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < commandsCount; i++)
            {
                var command = Console.ReadLine();
                var index = command.IndexOf(' ');
                var name = command.Substring(0, index);
                var subject = command.Substring(index + 1);
                var result = FindCheatersList(graph, name, subject);
                if(result.Count == 0) 
                {
                    Console.WriteLine(name);
                }
                else 
                {
                    Console.WriteLine(string.Join(", ", result));
                }
                
            }
        }

        public static void FakeInput()
        {
            string input = @"7
Coki Doncho Math
Doncho Stamat Math
Doncho Yana Math
Stamat Yana Math
Doncho Coki Graphs
Stamat Coki Graphs
Doncho Coki dynamic programming
6
Coki Math
Doncho Math
Stamat Math
Stamat Graphs
Doncho dynamic programming
Coki dynamic programming";
            Console.SetIn(new StringReader(input));
        }
    }
}
