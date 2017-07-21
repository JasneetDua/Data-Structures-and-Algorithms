using System;

namespace SuperMario.Dijkstra
{
    class MinIndexedCyclicTree
    {
        private long[] tree;
        private int firstLeaf;
        private int index;
        private int arraySize;

        public MinIndexedCyclicTree(int k)
        {
            this.firstLeaf = 1;
            while (this.firstLeaf < k)
            {
                this.firstLeaf *= 2;
            }

            this.tree = new long[this.firstLeaf * 2];
            for(int i = 0; i < this.tree.Length; ++i)
            {
                this.tree[i] = long.MaxValue;
            }

            this.index = 0;
            this.arraySize = k;
        }

        public long Min
        {
            get
            {
                return tree[1];
            }
        }

        public void Push(long value)
        {
            var index = this.index + this.firstLeaf;
            ++this.index;
            if (this.index == this.arraySize)
            {
                this.index = 0;
            }

            this.tree[index] = value;
            while (index > 1)
            {
                tree[index / 2] = Math.Min(tree[index], tree[index ^ 1]);
                index /= 2;
            }
        }
    }

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
            var f = long.Parse(strs[0]);
            var a = int.Parse(strs[1]);
            var b = int.Parse(strs[2]);
            var m = int.Parse(strs[3]);

            var tree = new MinIndexedCyclicTree(k);
            tree.Push(f);
            for (int i = 1; i < k; ++i)
            {
                f = (f * a + b) % m;
                tree.Push(f);
            }

            for (int i = k; i < n; ++i)
            {
                f = (f * a + b) % m;
                var result = f + tree.Min;
                tree.Push(result);
            }

            Console.WriteLine(tree.Min);
        }
    }
}