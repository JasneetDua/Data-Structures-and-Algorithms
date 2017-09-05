using System;
using System.Collections.Generic;
using Wintellect.PowerCollections;

namespace Blq
{
	struct SweepPoint
	{
		public int X;
		public int Height;
		public bool IsLeft;
	}

	struct Point
	{
		public int X;
		public int Y;
	}

	class Solution
	{
		static void Main()
		{
			var n = int.Parse(Console.ReadLine());

			var points = new SweepPoint[n * 2];

			for (int i = 0; i < n; ++i)
			{
				var strs = Console.ReadLine().Split(' ');
				var l = int.Parse(strs[0]);
				var r = int.Parse(strs[1]);
				var h = int.Parse(strs[2]);

				points[i * 2] = new SweepPoint
				{
					X = l,
					Height = h,
					IsLeft = true
				};
				points[i * 2 + 1] = new SweepPoint
				{
					X = r,
					Height = h,
					IsLeft = false
				};
			}

			Array.Sort(points, (x, y) => x.X - y.X);

			var result = new List<Point>();

			var heights = new OrderedBag<int>();
			heights.Add(0);

			foreach (var p in points)
			{
				if (p.IsLeft)
				{
					heights.Add(p.Height);
				}
				else
				{
					heights.Remove(p.Height);
				}

				var newPoint = new Point { X = p.X, Y = heights.GetLast() };
				result.Add(newPoint);
			}

			var lastHeight = 0;
			for (int i = 0; i < result.Count; ++i)
			{
				var p = result[i];

				if (p.Y == lastHeight)
				{
					continue;
				}

				if (i + 1 < result.Count && p.X == result[i + 1].X)
				{
					continue;
				}

				Console.WriteLine("{0} {1}", p.X, p.Y);
				lastHeight = p.Y;
			}
		}
	}
}
