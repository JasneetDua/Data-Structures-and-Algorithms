using System;

namespace Flies
{
	struct Vector
	{
		public double X { get; private set; }
		public double Y { get; private set; }

		public Vector(double x, double y)
		{
			this.X = x;
			this.Y = y;
		}

		public static Vector operator +(Vector a, Vector b)
		{
			return new Vector(a.X + b.X, a.Y + b.Y);
		}

		public static Vector operator -(Vector a, Vector b)
		{
			return new Vector(a.X - b.X, a.Y - b.Y);
		}

		public static double operator *(Vector a, Vector b)
		{
			return a.X * b.X + a.Y * b.Y;
		}

		public static Vector operator /(Vector self, double d)
		{
			return new Vector(self.X / d, self.Y / d);
		}

		public static Vector Parse(string line)
		{
			var strs = line.Split(' ');
			return new Vector(double.Parse(strs[0]), double.Parse(strs[1]));
		}
	}

	class Program
	{
		static void Main()
		{
			var pointA = Vector.Parse(Console.ReadLine());
			var pointB = Vector.Parse(Console.ReadLine());
			var pointC = Vector.Parse(Console.ReadLine());

			var ab = pointB - pointA;
			var ab2 = ab * ab / 2;
			var ac = pointC - pointA;
			var ac2 = ac * ac / 2;

			var at = new Vector(
				(ac2 * ab.Y - ab2 * ac.Y),
				(ab2 * ac.X - ac2 * ab.X));

			at /= ab.Y * ac.X - ab.X * ac.Y;

			var pointT = pointA + at;

			Console.WriteLine("{0:F4} {1:F4}", pointT.X, pointT.Y);
		}
	}
}
