using System;
using System.Linq;

namespace BinaryTree
{
	class Program
	{
		static void Main()
		{
			var p = long.Parse(Console.ReadLine());

			var result = Console.ReadLine()
				.Split(' ')
				.Select(long.Parse)
				.Select(n => Check(p, n));

			Console.WriteLine(string.Join(" ", result));
		}

		static int Check(long p, long n)
		{
			int ones = 0;
			int nonZeros = 0;

			while(n > 0)
			{
				var digit = n % p;
				n /= p;

				if(digit > 2)
				{
					return 0;
				}

				if(digit > 0)
				{
					++nonZeros;
					if(digit == 1)
					{
						++ones;
					}
				}
			}

			return ((nonZeros > 1 && ones == 1) || (nonZeros == 2 && ones == 2)) ? 1 : 0;
		}
	}
}
