using System;
using System.Linq;

namespace Repeat
{
	class Program
	{
		static void Main()
		{
			var numbers = Console.ReadLine()
				.Split(' ')
				.Select(int.Parse)
				.ToList();

			var n = numbers.Count;
			numbers.AddRange(numbers);

			var fl = new int[n + 1];
			fl[0] = -1;
			fl[1] = 0;
			for(int i = 1; i < n; ++i)
			{
				int j = fl[i];
				while(j >= 0 && numbers[i] != numbers[j])
				{
					j = fl[j];
				}
				fl[i + 1] = j + 1;
			}

			var result = 0;
			for(int i = 1, j = 0; i < numbers.Count; ++i)
			{
				while(j >= 0 && numbers[i] != numbers[j])
				{
					j = fl[j];
				}
				++j;
				if(j == n)
				{
					result = i - j + 1;
					break;
				}
			}

			Console.WriteLine(string.Join(" ", numbers.Take(result)));
		}
	}
}
