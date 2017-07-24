using System;

namespace Kbase
{
	class Program
	{
		static void Main()
		{
			var n = int.Parse(Console.ReadLine());
			var k = int.Parse(Console.ReadLine());

			var lastZero = new long[n];
			var lastNonZero = new long[n];
			lastZero[0] = 0;
			lastNonZero[0] = k - 1;
			for(int i = 1; i < n; ++i)
			{
				lastZero[i] = lastNonZero[i - 1];
				lastNonZero[i] = (k - 1) * (lastZero[i - 1] + lastNonZero[i - 1]);
			}

			Console.WriteLine(lastZero[n - 1] + lastNonZero[n - 1]);
		}
	}
}
