using System;
using System.Linq;
using System.Collections.Generic;

namespace Blq
{
	class Program
	{
		static void Main()
		{
			var digits = Console.ReadLine()
				.Select(x => (int)(x - '0'))
				.ToArray();
			var expectedResult = int.Parse(Console.ReadLine());

			var output = string.Join(" ", digits)
				.ToCharArray();

			var all = new List<string>();
			Recursion(digits, expectedResult, output, all, 1, digits[0], 1, 0, false);

			Console.WriteLine(all.Count);
			foreach(var x in all)
			{
				Console.WriteLine(x);
			}
		}

		static void Recursion(
				int[] digits,
				int expectedResult,
				char[] output,
				List<string> all,
				int index,
				int currentNumber,
				int currentProduct,
				int currentSum,
				bool negative)
		{
			if(index == digits.Length)
			{
				currentProduct *= currentNumber;
				currentSum += negative ? -currentProduct : currentProduct;

				if(currentSum == expectedResult)
				{
					all.Add(string.Join("", output.Where(x => x != ' ')));
				}
				return;
			}

			// + sign
			output[index * 2 - 1] = '+';
			var nextSum = currentSum + currentProduct * currentNumber * (negative ? -1 : 1);
			Recursion(digits, expectedResult, output, all, index + 1, digits[index], 1, nextSum, false);

			// - sign
			output[index * 2 - 1] = '-';
			Recursion(digits, expectedResult, output, all, index + 1, digits[index], 1, nextSum, true);

			// * sign
			output[index * 2 - 1] = '*';
			var nextProduct = currentProduct * currentNumber;
			Recursion(digits, expectedResult, output, all, index + 1, digits[index], nextProduct, currentSum, negative);

			// No sign
			if(currentNumber != 0)
			{
				output[index * 2 - 1] = ' ';
				var nextNumber = currentNumber * 10 + digits[index];
				Recursion(digits, expectedResult, output, all, index + 1, nextNumber, currentProduct, currentSum, negative);
			}
		}
	}
}
