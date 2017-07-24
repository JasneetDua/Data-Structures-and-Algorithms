using System;

namespace Kbase
{
	class Program
	{
		static void Main()
		{
			var n = int.Parse(Console.ReadLine());
			var k = int.Parse(Console.ReadLine());

			var dp = new long[n];
			dp[0] = k - 1;
			dp[1] = (k - 1) * (k - 1);
			for(int i = 2; i < n; ++i)
			{
				dp[i] = (k - 1) * (dp[i - 2] + dp[i - 1]);
			}

			Console.WriteLine(dp[n - 2] + dp[n - 1]);
		}
	}
}
