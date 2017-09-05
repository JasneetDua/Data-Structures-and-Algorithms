using System;
using System.IO;
using Wintellect.PowerCollections;

namespace _Median
{
	class MedianSolution
	{
		class PriorityQueue
		{
			readonly OrderedBag<float> bag;

			public int Count => this.bag.Count;

			public PriorityQueue()
			{
				this.bag = new OrderedBag<float>();
			}

			public void Enqueue(float value)
			{
				this.bag.Add(value);
			}

			public float Dequeue()
			{
				var val = this.bag.GetFirst();
				this.bag.RemoveFirst();
				return val;
			}

			public float Peek()
			{
				return this.bag.GetFirst();
			}
		}

		PriorityQueue small;

		PriorityQueue large;


		public MedianSolution()
		{
			this.small = new PriorityQueue();
			this.large = new PriorityQueue();
		}

		public void AddNumber(int number)
		{
			if (this.large.Count > 0)
			{
				this.small.Enqueue(-this.large.Dequeue());
			}

			this.large.Enqueue(number);
			if (this.large.Count < this.small.Count)
			{
				this.large.Enqueue(-this.small.Dequeue());
			}
		}

		public float FindMedian()
		{
			if (this.large.Count > this.small.Count)
			{
				return this.large.Peek();
			}
			return (this.large.Peek() - this.small.Peek()) / 2;
		}

		public static void Main(string[] args)
		{
			//FakeInput();
			var median = new MedianSolution();

			var command = Console.ReadLine().Split(' ');

			while (command[0] != "EXIT")
			{
				if (command[0] == "ADD")
				{
					median.AddNumber(int.Parse(command[1]));
				}
				else
				{
					Console.WriteLine(median.FindMedian());
				}
				command = Console.ReadLine().Split(' ');
			}
		}
		static void FakeInput()
		{
			var input = @"ADD -14483
ADD 8637
GET
EXIT";
			Console.SetIn(new StringReader(input));
		}
	}
}
