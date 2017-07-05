using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Swapping
{
	class MainClass
	{
		public static void Main()
		{
			var n = int.Parse(Console.ReadLine());
			var numbers = Enumerable.Range(1, n)
					  .ToList();

			var swapNumbers = Console.ReadLine()
			     .Split(' ')
				 .Select(int.Parse)
				 .ToArray();
			
			foreach (var num in swapNumbers)
			{
				int index = numbers.IndexOf(num);
				numbers.Insert(0, num);
				numbers.InsertRange(0,
						numbers.GetRange(index + 2,
				                         numbers.Count - index - 2));
				numbers.RemoveRange(n, numbers.Count - n);
			}

			Console.WriteLine(string.Join(" ", numbers));
		}
	}
}
