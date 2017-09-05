using System;
using System.Numerics;

namespace Grapes
{
	class Program
	{
		static void Main()
		{
			var n = int.Parse(Console.ReadLine());
			if(n == 0)
			{
				Console.WriteLine(1);
				return;
			}

			var dp = new BigInteger[n + 1];
			dp[0] = 1;
			dp[1] = 1;
			for(int i = 2; i <= n; ++i)
			{
				dp[i] = 0;
				for(int j = 0; j < i; ++j)
				{
					dp[i] += dp[j] * dp[i - 1 - j];
				}
			}

			Console.WriteLine(dp[n]);
		}
	}
}
