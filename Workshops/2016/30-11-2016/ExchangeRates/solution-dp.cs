using System;
using System.Linq;

class Program
{
	static void Main()
	{
		double max1 = double.Parse(Console.ReadLine());
		double max2 = 0.0;
		int days = int.Parse(Console.ReadLine());

		for(int i = 0; i < days; ++i)
		{
			var exchange = Console.ReadLine()
				.Split(' ')
				.Select(double.Parse)
				.ToArray();

			double curr1 = Math.Max(max1, exchange[1] * max2);
			double curr2 = Math.Max(max2, exchange[0] * max1);

			max1 = curr1;
			max2 = curr2;
		}

		Console.WriteLine("{0:0.00}", max1);
	}
}
