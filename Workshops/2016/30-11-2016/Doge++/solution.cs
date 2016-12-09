using System;
using System.Numerics;

class Program
{
	static void Main()
	{
		string[] str = Console.ReadLine().Split(' ');

		int n = int.Parse(str[0]);
		int m = int.Parse(str[1]);
		int k = int.Parse(str[2]);

		bool[,] wall = new bool[n + 1, m + 1];

		str = Console.ReadLine().Split(';');
		foreach(var x in str)
		{
			var s = x.Split(' ');
			wall[int.Parse(s[0]), int.Parse(s[1])] = true;
		}

		var table = new BigInteger[k + 1, n, m];
		table[0, 0, 0] = 1;

		for(int t = 0; t <= k; ++t)
		{
			for(int i = 0; i < n; ++i)
			{
				for(int j = 0; j < m; ++j)
				{
					if(wall[i, j])
					{
						continue;
					}

					if(i > 0)
					{
						table[t, i, j] += table[t, i - 1, j];
					}
					if(j > 0)
					{
						table[t, i, j] += table[t, i, j - 1];
					}
					if(t > 0)
					{
						if(i < n - 1)
						{
							table[t, i, j] += table[t - 1, i + 1, j];
						}
						if(j < m - 1)
						{
							table[t, i, j] += table[t - 1, i, j + 1];
						}
					}
				}
			}
		}

		BigInteger total = 0;
		for(int i = 0; i <= k; ++i)
		{
			total += table[i, n - 1, m - 1];
		}

		Console.WriteLine(total);
	}
}
