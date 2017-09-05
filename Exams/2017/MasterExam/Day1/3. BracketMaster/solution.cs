using System;
using System.Numerics;

namespace BracketMaster
{
	class Program
	{
		const int BracketTypes = 4;

		static void Main()
		{
			var n = int.Parse(Console.ReadLine());
			if(n % 2 == 1)
			{
				Console.WriteLine(0);
				return;
			}

			n /= 2;

			var segment = new BigInteger[n + 1];
			var expression = new BigInteger[n + 1];
			segment[0] = 0;
			expression[0] = 1;

			for(int i = 1; i <= n; ++i)
			{
				segment[i] = expression[i - 1] * BracketTypes;
				expression[i] = segment[i];
				for(int j = 1; j < i; ++j)
				{
					expression[i] += expression[j] * segment[i - j];
				}
			}

			Console.WriteLine(expression[n]);
		}
	}
}
