using System;

namespace Bridges
{
	class UnionFind
	{
		private int[] array;

		public UnionFind(int n)
		{
			this.array = new int[n + 1];
		}

		private int Find(int x)
		{
			if(this.array[x] == 0)
			{
				return x;
			}
			this.array[x] = this.Find(this.array[x]);
			return this.array[x];
		}

		public bool Union(int x, int y)
		{
			x = this.Find(x);
			y = this.Find(y);
			if(x == y)
			{
				return false;
			}
			this.array[x] = y;
			return true;
		}
	}

	class Program
	{
		static void Main()
		{
			var strs = Console.ReadLine().Split(' ');
			var n = int.Parse(strs[0]);
			var m = int.Parse(strs[1]);

			var edgeLines = new string[m];
			for(var i = 0; i < m; ++i)
			{
				edgeLines[i] = Console.ReadLine();
			}

			var weight = int.Parse(Console.ReadLine());

			var connected = new UnionFind(n);
			var toUpgrade = n - 1;

			foreach(var line in edgeLines)
			{
				strs = line.Split(' ');
				var from = int.Parse(strs[0]);
				var to = int.Parse(strs[1]);
				var maxWeight = int.Parse(strs[2]);

				if(weight <= maxWeight && connected.Union(from, to))
				{
					--toUpgrade;
				}
			}

			Console.WriteLine(toUpgrade);
		}
	}
}
