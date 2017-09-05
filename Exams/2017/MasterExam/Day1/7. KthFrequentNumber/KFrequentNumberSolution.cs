using System;
using System.Collections.Generic;
using System.IO;
using Wintellect.PowerCollections;

namespace _KFrequentNumber
{
	class KFrequentNumberSolution
	{
		public class Value : IComparable<Value>
		{
			public int Name { get; set; }
			public int Frequency { get; set; }

			public Value(int number, int frequency)
			{
				this.Name = number;
				this.Frequency = frequency;
			}

			public override string ToString()
			{
				return string.Format("[Value: Name={0}, Frequency={1}]", Name, Frequency);
			}

			public int CompareTo(Value other)
			{
				if (this.Frequency == other.Frequency)
				{
					return -other.Name.CompareTo(this.Name);
				}
				return other.Frequency.CompareTo(this.Frequency);
			}
		}

		private BigList<Value> numbers;
		private Dictionary<int, int> frequencies;

		public KFrequentNumberSolution()
		{
			this.numbers = new BigList<Value>();
			this.frequencies = new Dictionary<int, int>();
		}


		int FindPosition(int from, int to, Value value)
		{
			var l = from;
			var r = to;

			while (l < r)
			{
				var midIndex = (l + r) / 2;
				var mid = this.numbers[midIndex];
				if (mid.CompareTo(value) == 0)
				{
					return midIndex;
				}
				else if (mid.CompareTo(value) > 0)
				{
					r = midIndex;
				}
				else
				{
					l = midIndex + 1;
				}
			}

			return r;
		}

		public void Add(int number)
		{
			if (this.numbers.Count == 0)
			{
				this.numbers.Add(new Value(number, 1));
				this.frequencies[number] = 1;
				return;
			}

			if (frequencies.ContainsKey(number) == false)
			{
				frequencies[number] = 0;
			}

			var frequency = this.frequencies[number];

			var removePosition = this.FindPosition(0, numbers.Count, new Value(number, frequency));
			if (frequency != 0)
			{
				this.numbers.RemoveAt(removePosition);
			}

			++this.frequencies[number];
			var val = new Value(number, frequency + 1);
			var insertPosition = this.FindPosition(0, numbers.Count, val);
			if (insertPosition == 0)
			{
				this.numbers.AddToFront(val);
				return;
			}
			this.numbers.Insert(insertPosition, val);
		}

		public bool Remove(int number)
		{
			if (this.numbers.Count == 0)
			{
				return false;
			}

			if (this.frequencies.ContainsKey(number) == false)
			{
				return false;
			}

			var frequency = this.frequencies[number];

			var removePosition = this.FindPosition(0, numbers.Count, new Value(number, frequency));
			if (frequency != 0)
			{
				this.numbers.RemoveAt(removePosition);
			}

			--this.frequencies[number];
			if (this.frequencies[number] == 0)
			{
				this.frequencies.Remove(number);
				return true;
			}

			var val = new Value(number, frequency - 1);
			var insertPosition = this.FindPosition(0, numbers.Count, val);
			if (insertPosition == 0)
			{
				this.numbers.AddToFront(val);
				return true;
			}
			this.numbers.Insert(insertPosition, val);
			return true;
		}

		public int GetKMostFrequent(int k)
		{
			if (this.numbers.Count < k)
			{
				throw new Exception("Invalid k");
			}

			return this.numbers[k - 1].Name;
		}

		public static void HandleAdd(KFrequentNumberSolution frequentNumbers, int number)
		{
			frequentNumbers.Add(number);
			Console.WriteLine("Ok: {0} added", number);
		}

		public static void HandleRemove(KFrequentNumberSolution frequentNumbers, int number)
		{
			if (frequentNumbers.Remove(number))
			{
				Console.WriteLine("Ok: Number {0} removed", number);
			}
			else
			{
				Console.WriteLine("Error: Number {0} not found", number);
			}
		}

		public static void HandleGet(KFrequentNumberSolution frequentNumbers, int k)
		{
			try
			{
				var number = frequentNumbers.GetKMostFrequent(k);
				Console.WriteLine("Ok: Found {0}", number);
			}
			catch
			{
				Console.WriteLine("Error: {0} is invalid K", k);
			}
		}

		const string COMMAND_END = "END";
		const string COMMAND_ADD = "ADD";
		const string COMMAND_REMOVE = "REMOVE";
		const string COMMAND_GET = "GET";

		public static void Main()
		{
			//FakeInput();

			var frequentNumbers = new KFrequentNumberSolution();

			var commands = new Dictionary<string, Action<KFrequentNumberSolution, int>>()
			{
				{"ADD", HandleAdd },
				{"REMOVE",HandleRemove },
				{"GET", HandleGet }
			};

			var command = Console.ReadLine().Split(' ');

			while (command[0] != COMMAND_END)
			{
				commands[command[0]](frequentNumbers, int.Parse(command[1]));

				command = Console.ReadLine().Split(' ');
			}
		}

		static void FakeInput()
		{
			var input = @"ADD 1
ADD 2
ADD 3
ADD 4
ADD 5
GET 1
GET 2
GET 3
GET 4
GET 5
ADD 2
GET 1
GET 2
GET 3
GET 4
GET 5
REMOVE 2
GET 1
GET 2
GET 3
GET 4
GET 5
REMOVE 2
REMOVE 2
GET 1
GET 2
GET 3
GET 4
GET 5
END";
			Console.SetIn(new StringReader(input));
		}
	}
}
