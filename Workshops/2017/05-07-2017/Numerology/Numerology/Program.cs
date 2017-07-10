using System;
using System.Collections.Generic;
using System.Linq;

namespace Numerology
{
	class MainClass
	{
		public static int[] DigitCount = new int[10];
		public static int Counter = 0;

		public static void Main(string[] args)
		{
			var digits = Console.ReadLine()
				   .Select(x => x - '0')
				   .ToList();

			//DigitCount = new int[10];
			Divine(digits);
			Console.WriteLine(string.Join(" ", DigitCount));
			Console.WriteLine(Counter);
		}

		public static void Divine(List<int> digits)
		{
			if (digits.Count == 1)
			{
				++DigitCount[digits[0]];
				return;
			}

			for (int i = 1; i < digits.Count; i++)
			{
				++Counter;
				var a = digits[i - 1];
				var b = digits[i];

				digits.RemoveAt(i);
				digits[i - 1] = Magic(a, b);

				Divine(digits);

				digits[i - 1] = a;
				digits.Insert(i, b);
			}
		}

		public static int Magic(int a, int b)
		{
			return (a + b) * (a ^ b) % 10;
		}
	}
}
