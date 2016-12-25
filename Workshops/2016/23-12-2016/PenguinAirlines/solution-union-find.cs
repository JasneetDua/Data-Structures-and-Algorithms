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

            var disjSet = new int[n];
            for (int i = 0; i < n; ++i)
            {
                disjSet[i] = -1;
            }

            for (int a = 0; a < n; ++a)
            {
                foreach(var b in adjList[a])
                {
                    Unite(disjSet, a, b);
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

                if (Find(disjSet, a) == Find(disjSet, b))
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

        static int Find(int[] disjSet, int x)
        {
            if(disjSet[x] < 0)
            {
                return x;
            }

            int root = Find(disjSet, disjSet[x]);
            disjSet[x] = root;
            return root;
        }

        static void Unite(int[] disjSet, int x, int y)
        {
            x = Find(disjSet, x);
            y = Find(disjSet, y);
            if (x != y)
            {
                disjSet[x] = y;
            }
        }
    }
}
