using System;
using System.Linq;

namespace Generator
{
	class Program
	{
		static void Main()
		{
			var numbers = Console.ReadLine()
				.Split(' ')
				.Select(int.Parse)
				.ToArray();

			var sumPositive = 0;
			var positiveOdd = 100000;
			var negativeOdd = -100000;

			for(int i = 0; i < numbers.Length; ++i)
			{
				if(numbers[i] > 0)
				{
					sumPositive += numbers[i];
					if(numbers[i] % 2 != 0 && positiveOdd > numbers[i])
					{
						positiveOdd = numbers[i];
					}
				}
				else if(numbers[i] % 2 != 0 && negativeOdd < numbers[i])
				{
					negativeOdd = numbers[i];
				}
			}

			if(sumPositive % 2 != 0)
			{
				Console.WriteLine(sumPositive);
			}
			else
			{
				Console.WriteLine(Math.Max(
							sumPositive - positiveOdd,
							sumPositive + negativeOdd));
			}
		}
	}
}
