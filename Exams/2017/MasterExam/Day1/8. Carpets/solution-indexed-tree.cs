using System;
using System.Collections.Generic;

namespace Carpets
{
	class Tree
	{
		private int maxValue;
		private int count;
		private readonly int height;

		private Tree left;
		private Tree right;

		private Tree(int height)
		{
			this.maxValue = int.MinValue;
			this.count = 0;
			this.height = height;
		}

		public Tree()
			: this(31)
		{
		}

		public int Max => this.maxValue;

		public void Add(int value)
		{
			this.ApplyDelta(value, 1);
		}

		public void Remove(int value)
		{
			this.ApplyDelta(value, -1);
		}

		private void ApplyDelta(int value, int delta)
		{
			if(this.height < 0)
			{ // This is a leaf
				this.count += delta;
				this.maxValue = this.count > 0 ? value : int.MinValue;
				return;
			}

			int direction = (value >> this.height) & 1;
			if(direction == 0)
			{
				if(this.left == null)
				{
					this.left = new Tree(this.height - 1);
				}

				this.left.ApplyDelta(value, delta);
			}
			else
			{
				if(this.right == null)
				{
					this.right = new Tree(this.height - 1);
				}

				this.right.ApplyDelta(value, delta);
			}

			// Not used
			// this.count += delta;

			var leftMax = this.left == null ? int.MinValue : this.left.maxValue;
			var rightMax = this.right == null ? int.MinValue : this.right.maxValue;
			this.maxValue = Math.Max(leftMax, rightMax);
		}
	}

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

			for(int i = 0; i < n; ++i)
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

			var heights = new Tree(); // Use as sorted multi set
			heights.Add(0);

			foreach(var p in points)
			{
				if(p.IsLeft)
				{
					heights.Add(p.Height);
				}
				else
				{
					heights.Remove(p.Height);
				}

				var newPoint = new Point { X = p.X, Y = heights.Max };
				result.Add(newPoint);
			}

			var lastHeight = 0;
			for(int i = 0; i < result.Count; ++i)
			{
				var p = result[i];

				if(p.Y == lastHeight)
				{
					continue;
				}

				if(i + 1 < result.Count && p.X == result[i + 1].X)
				{
					continue;
				}

				Console.WriteLine("{0} {1}", p.X, p.Y);
				lastHeight = p.Y;
			}
		}
	}
}
