using System;

namespace Beach
{
	class Program
	{
		const double Epsillon = 1e-3;

		static void Main()
		{
			var strs = Console.ReadLine().Split(' ');
			var sx = double.Parse(strs[0]);
			var sy = double.Parse(strs[1]);
			var sv = double.Parse(strs[2]);

			strs = Console.ReadLine().Split(' ');
			var ex = double.Parse(strs[0]);
			var ey = double.Parse(strs[1]);
			var ev = double.Parse(strs[2]);

			var dx = sx > ex
				? sx - ex
				: ex - sx;

			var left = (double)0;
			var right = dx;

			// Ternary search
			while(right - left > Epsillon)
			{
				var third = (right - left) / 3;
				var mid1 = left + third;
				var mid2 = right - third;

				var tMid1 = GetTime(sy, ey, sv, ev, mid1, dx - mid1);
				var tMid2 = GetTime(sy, ey, sv, ev, mid2, dx - mid2);

				if(tMid1 > tMid2)
				{
					left = mid1;
				}
				else
				{
					right = mid2;
				}
			}

			var x = (left + right) / 2;
			var t = GetTime(sy, ey, sv, ev, x, dx - x);

			Console.WriteLine("{0:F2}", t);
		}

		static double GetTime(double h1, double h2, double v1, double v2, double x1, double x2)
		{
			return Math.Sqrt(h1 * h1 + x1 * x1) / v1
				 + Math.Sqrt(h2 * h2 + x2 * x2) / v2;
		}
	}
}
