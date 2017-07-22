using System;
using System.Numerics;
using System.Collections.Generic;

namespace Square
{
	class Program
	{
		static void Main()
		{
			var n = int.Parse(Console.ReadLine());
			var m = int.Parse(Console.ReadLine());

			if(n < m)
			{
				var k = n;
				n = m;
				m = k;
			}

			var masks = new List<int>();
			for(int i = 0; i < (1 << m); ++i)
			{
				if((i & (i >> 1)) > 0)
				{
					continue;
				}

				masks.Add(i);
			}

			var dp = new BigInteger[2, masks.Count];
			dp[0, 0] = 1;

			for(int row = 1; row <= n; ++row)
			{
				for(int i = 0; i < masks.Count; ++i)
				{
					var from = dp[(row - 1) % 2, i];
					dp[(row - 1) % 2, i] = 0;

					for(int j = 0; j < masks.Count; ++j)
					{
						if((masks[i] & masks[j]) > 0)
						{
							continue;
						}

						dp[row % 2, j] += from;
					}
				}
			}

			BigInteger result = 0;
			for(int i = 0; i < masks.Count; ++i)
			{
				result += dp[n % 2, i];
			}
			Console.WriteLine(result);
		}
	}
}
