using System;
using System.Diagnostics;

namespace BucketList.Demo
{
    class Program
    {
        public static void Main(string[] args)
        {
            var x = new BucketList<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 1, 2, 3 };

            Console.WriteLine(string.Join(" ", x));
            x.Insert(0, 42);
            Console.WriteLine(string.Join(" ", x));
            x.Insert(0, 42);
            Console.WriteLine(string.Join(" ", x));
            x.Insert(0, 42);
            Console.WriteLine(string.Join(" ", x));

            return;

            //var listTime = Average<NotBucketList<int>>();
            //Console.WriteLine(listTime);

            var bucketListTime = Average<BucketList<int>>();
            Console.WriteLine(bucketListTime);
        }

        public static long Average<B>()
            where B : IBucketList<int>, new()
        {
            var sw = new Stopwatch();
            sw.Start();

            for (int i = 0; i < 3; ++i)
            {
                var list = new B();
                for(int j = 0; j < 100000; ++j)
                {
                    list.Insert(0, j);
                }

                while(list.Size > 3)
                {
                    list.Remove(list.Size - 3);
                }
                list.Remove(0);
                list.Remove(0);
                list.Remove(0);
            }

            sw.Stop();
            return sw.ElapsedMilliseconds;
        }

        // not perfect, but it's something
        public static long TestBucketList(
            IBucketList<int> list,
            int addOperations,
            int insertOperations,
            int modifyIndexOperations,
            int removeOperations)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            var rnd = new Random();
            while (addOperations > 0 || insertOperations > 0)
            {
                var op = rnd.Next() % 4;
                if ((op == 0 || (addOperations <= 0 && insertOperations <= 0))
                    && removeOperations > 0 && list.Size > 0)
                {
                    var index = rnd.Next() % list.Size;
                    list.Remove(index);
                    --removeOperations;
                }
                else if (op == 1 && modifyIndexOperations > 0 && list.Size > 0)
                {
                    var index = rnd.Next() % list.Size;
                    var value = rnd.Next();
                    list[index] = list[index] + value;
                    --modifyIndexOperations;
                }
                else if (op == 2 && insertOperations > 0)
                {
                    var index = rnd.Next() % (list.Size + 1);
                    var value = rnd.Next();
                    list.Insert(index, value);
                    --insertOperations;
                }
                else
                {
                    var value = rnd.Next();
                    list.Add(value);
                    --addOperations;
                }
            }

            stopWatch.Stop();
            return stopWatch.ElapsedMilliseconds;
        }
    }
}
