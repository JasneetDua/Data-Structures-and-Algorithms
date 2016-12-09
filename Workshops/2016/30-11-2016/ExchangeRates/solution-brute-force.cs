using System;
using System.Linq;

class Program
{
	static double Rec(double currency, int type, int day, double[][] exchange)
	{
		if(day == exchange.Length)
		{
			return type == 0 ? currency : 0;
		}

		return Math.Max(Rec(currency, type, day + 1, exchange), Rec(currency * exchange[day][type], 1 - type, day + 1, exchange));
	}

	static void Main()
	{
		double currency = double.Parse(Console.ReadLine());
		int days = int.Parse(Console.ReadLine());
		var exchange = new double[days][];

		for(int i = 0; i < days; ++i)
		{
			exchange[i] = Console.ReadLine()
				.Split(' ')
				.Select(double.Parse)
				.ToArray();
		}

		Console.WriteLine("{0:0.00}", Rec(currency, 0, 0, exchange));
	}
}
