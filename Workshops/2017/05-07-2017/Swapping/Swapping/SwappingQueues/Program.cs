using System;
using System.Linq;
using System.Collections.Generic;

namespace SwappingQueues
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			var n = int.Parse(Console.ReadLine());

			var q = new Queue<int>(
				Enumerable.Range(1, n));

			Console.ReadLine()
				   .Split(' ')
				   .Select(int.Parse)
				   .ToList()
				   .ForEach(num =>
			{
				q.Enqueue(num);
				int x;
				while ((x = q.Dequeue()) != num)
				{
					q.Enqueue(x);
				}
			});

			Console.WriteLine(string.Join(" ", q));
		}
	}
}
