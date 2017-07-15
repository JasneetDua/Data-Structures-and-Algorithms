using System;
using Wintellect.PowerCollections;

namespace Train
{
	class Program
	{
		static void Main()
		{
			var strs = Console.ReadLine().Split(' ');
			var n = int.Parse(strs[0]);
			var m = int.Parse(strs[1]);
			var l = int.Parse(strs[2]);

			var intervals = new Tuple<int, int>[n];
			for (int i = 0; i < n; ++i)
			{
				strs = Console.ReadLine().Split(' ');
				intervals[i] = new Tuple<int, int>(
						int.Parse(strs[0]),
						int.Parse(strs[1]));
			}
			Array.Sort(intervals);

			var result = 0;
			var boarded = new OrderedBag<int>();
			foreach (var x in intervals)
			{
				while (boarded.Count > 0)
				{
					var firstItem = boarded.GetFirst();
					if (firstItem > x.Item1)
					{
						break;
					}
					boarded.RemoveFirst();
					++result;
				}
				boarded.Add(x.Item2);
				if (boarded.Count > m)
				{
					boarded.RemoveLast();
				}
			}

			result += boarded.Count;
			Console.WriteLine(result);
		}
	}
}
