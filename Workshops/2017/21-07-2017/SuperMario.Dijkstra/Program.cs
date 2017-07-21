using System;
using System.Collections.Generic;

namespace SuperMario.Dijkstra
{
    public class BinaryHeap<T>
    {
        private List<T> heap;
        private Func<T, T, bool> compareFunc;

        public BinaryHeap(Func<T, T, bool> cmpFunc)
        {
            heap = new List<T>();
            heap.Add(default(T));
            compareFunc = cmpFunc;
        }

        public T Top
        {
            get
            {
                return heap[1];
            }
        }
        public int Count
        {
            get
            {
                return this.heap.Count - 1;
            }
        }

        public bool Empty
        {
            get
            {
                return this.Count == 0;
            }
        }

        public void Insert(T value)
        {
            int index = heap.Count; // index where inserted
            heap.Add(value);

            while (index > 1 && compareFunc(value, heap[index / 2]))
            {
                heap[index] = heap[index / 2];
                //var temp = heap[index / 2];
                //heap[index / 2] = heap[index];
                //heap[index] = temp;
                index /= 2;
            }

            heap[index] = value;
        }

        public void RemoveTop()
        {
            var value = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);

            if (!Empty)
            {
                HeapifyDown(1, value);
            }
        }

        private void HeapifyDown(int index, T value)
        {
            while (index * 2 + 1 < heap.Count)
            {
                int smallerKidIndex = compareFunc(heap[index * 2], heap[index * 2 + 1])
                    ? index * 2
                    : index * 2 + 1;
                if (compareFunc(heap[smallerKidIndex], value))
                {
                    heap[index] = heap[smallerKidIndex];
                    index = smallerKidIndex;
                }
                else
                {
                    break;
                }
            }

            if (index * 2 < heap.Count)
            {
                int smallerKidIndex = index * 2;
                if (compareFunc(heap[smallerKidIndex], value))
                {
                    heap[index] = heap[smallerKidIndex];
                    index = smallerKidIndex;
                }
            }

            heap[index] = value;
        }
    }

    class Program
    {
        static void Main(string[] args)
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

            var heap = new BinaryHeap<Tuple<long, int>>(
                (x, y) => x.Item1 < y.Item1);

            heap.Insert(new Tuple<long, int>(f, 0));
            for (int i = 1; i < k; ++i)
            {
                f = (f * a + b) % m;
                heap.Insert(new Tuple<long, int>(f, i));
            }

            for (int i = k; i < n; ++i)
            {
                f = (f * a + b) % m;

                while (heap.Top.Item2 < i - k)
                {
                    heap.RemoveTop();
                }
                var cell = heap.Top.Item1 + f;
                heap.Insert(new Tuple<long, int>(cell, i));
            }

            while (heap.Top.Item2 < n - k)
            {
                heap.RemoveTop();
            }

            Console.WriteLine(heap.Top.Item1);
        }
    }
}
