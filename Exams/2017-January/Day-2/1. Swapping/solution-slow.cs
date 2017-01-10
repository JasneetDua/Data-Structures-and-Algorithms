using System;
using System.Linq;

class Program
{
	static void Main()
	{
		int n = int.Parse(Console.ReadLine());
		var swaps = Console.ReadLine()
			.Split(' ')
			.Select(int.Parse)
			.ToArray();

		var numbers = Enumerable.Range(1, n).ToArray();
		var numbers2 = new int[n];

		foreach(int x in swaps)
		{
			int index = Array.IndexOf(numbers, x);
			int i = 0, j = index + 1;
			while(j < n)
			{
				numbers2[i] = numbers[j];
				++i; ++j;
			}

			numbers2[i] = x;
			++i; j = 0;

			while(i < n)
			{
				numbers2[i] = numbers[j];
				++i; ++j;
			}

			var tmp = numbers2;
			numbers2 = numbers;
			numbers = tmp;
		}

		Console.WriteLine(string.Join(" ", numbers));
	}
}
