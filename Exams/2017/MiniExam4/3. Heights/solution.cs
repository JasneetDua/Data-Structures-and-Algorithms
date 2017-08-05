using System;

namespace Heights
{
	class Program
	{
		static void Main()
		{
			var strs = Console.ReadLine().Split(' ');
			var a = new Vector(int.Parse(strs[0]), int.Parse(strs[1]));
			strs = Console.ReadLine().Split(' ');
			var b = new Vector(int.Parse(strs[0]), int.Parse(strs[1]));
			strs = Console.ReadLine().Split(' ');
			var c = new Vector(int.Parse(strs[0]), int.Parse(strs[1]));

			Console.WriteLine("{0:F2}", Vector.FindHeight(c, a, b));
			Console.WriteLine("{0:F2}", Vector.FindHeight(a, b, c));
			Console.WriteLine("{0:F2}", Vector.FindHeight(b, c, a));
		}
	}

	class Vector
	{
		private int x;
		private int y;

		public Vector(int x, int y)
		{
			this.x = x;
			this.y = y;
		}

		public int CrossProduct(Vector other)
		{
			return this.x * other.y - this.y * other.x;
		}

		public double Length()
		{
			return Math.Sqrt(this.x * this.x + this.y * this.y);
		}

		public static Vector operator-(Vector a, Vector b)
		{
			return new Vector(a.x - b.x, a.y - b.y);
		}

		public static double FindHeight(Vector a, Vector b, Vector c)
		{
			var ab = b - a;
			var ac = c - a;

			return Math.Abs(ab.CrossProduct(ac) / ac.Length());
		}
	}
}
