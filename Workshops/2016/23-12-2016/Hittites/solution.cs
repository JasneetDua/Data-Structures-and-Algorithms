using System;
using System.Collections.Generic;

namespace Hittites
{
    class Node
    {
        private Node[] letter;
        private Node faillink;
        private bool isName;
        //private long stringCount;

        public Node()
        {
            //stringCount = 0;
            isName = false;
            faillink = null;
            letter = new Node[26];
        }

        public void Push(string name)
        {
            Node node = this;
            foreach (char c in name)
            {
                int index = c - 'a';
                if (node.letter[index] == null)
                {
                    node.letter[index] = new Node();
                }

                node = node.letter[index];
            }

            node.isName = true;
        }

        public void PreCompute()
        {
            var queue = new Queue<Node>();
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                Node node = queue.Dequeue();

                for (int i = 0; i < 26; ++i)
                {
                    Node x = node.faillink;
                    while (x != null && x.letter[i] == null)
                    {
                        x = x.faillink;
                    }

                    var faillink = (x == null) ? this : x.letter[i];
                    if (node.letter[i] == null)
                    {
                        node.letter[i] = faillink;
                    }
                    else
                    {
                        node.letter[i].faillink = faillink;
                        queue.Enqueue(node.letter[i]);
                    }
                }
            }
        }

        //public void AddStrings(long count)
        //{
        //    stringCount += count;
        //}

        public long CountMatches(int k)
        {
            var queue = new Dictionary<Node, long>();
            queue.Add(this, Program.Pow(26, k));

            long total = 0;

            for (int i = 0; i < k; ++i)
            {
                var newQueue = new Dictionary<Node, long>();

                foreach (var tuple in queue)
                {
                    var node = tuple.Key;
                    long count = tuple.Value;
                    if (node.isName)
                    {
                        total = (total + count) % Program.MOD;
                        continue;
                    }
                    if (count == 0)
                    {
                        continue;
                    }
                    count = count * Program.DIV26 % Program.MOD;

                    for (int j = 0; j < 26; ++j)
                    {
                        if (newQueue.ContainsKey(node.letter[j]))
                        {
                            newQueue[node.letter[j]] += count;
                        }
                        else
                        {
                            newQueue.Add(node.letter[j], count);
                        }
                    }
                }

                queue = newQueue;
            }

            foreach (var tuple in queue)
            {
                var node = tuple.Key;
                long count = tuple.Value;
                if (node.isName)
                {
                    total = (total + count) % Program.MOD;
                }
            }

            return total;
        }
    }

    class Program
    {
        public const long MOD = (long)1e9 + 7;
        public static readonly long DIV26 = Pow(26, MOD - 2); // 576923081

        static void Main()
        {
            var strs = Console.ReadLine().Split(' ');
            int k = int.Parse(strs[0]);
            int n = int.Parse(strs[1]);

            var root = new Node();
            for (int i = 0; i < n; i++)
            {
                var name = Console.ReadLine();
                root.Push(name);
            }

            root.PreCompute();
            long matches = root.CountMatches(k);
            Console.WriteLine(matches);
        }

        public static long Pow(long a, long p)
        {
            if (p == 0)
            {
                return 1;
            }

            if (p % 2 == 1)
            {
                return Pow(a, p - 1) * a % MOD;
            }

            long b = Pow(a, p / 2);
            return b * b % MOD;
        }
    }
}
