using System;

namespace Sticks
{
	class Point
	{
		public double X { get; private set; }
		public double Y { get; private set; }

		public Point(double x, double y)
		{
			this.X = x;
			this.Y = y;
		}

		public static double Area(Point a, Point b, Point c)
		{
			return a.X * (b.Y - c.Y) + b.X * (c.Y - a.Y) + c.X * (a.Y - b.Y);
		}

		public static Point operator+(Point a, Point b)
		{
			return new Point(a.X + b.X, a.Y + b.Y);
		}

		public static Point operator-(Point a, Point b)
		{
			return new Point(a.X - b.X, a.Y - b.Y);
		}

		public static Point operator*(Point a, double k)
		{
			return new Point(a.X * k, a.Y * k);
		}

		public static Point operator*(double k, Point a)
		{
			return new Point(a.X * k, a.Y * k);
		}

		public static double operator*(Point a, Point b)
		{
			return a.X * b.X + a.Y * b.Y;
		}
	}

	class Line
	{
		public Point Begin { get; private set; }
		public Point End { get; private set; }

		public Line(double x1, double y1, double x2, double y2)
		{
			this.Begin = new Point(x1, y1);
			this.End = new Point(x2, y2);
		}

		public static Line FromString(string line)
		{
			var strs = line.Split(' ');
			return new Line(
					double.Parse(strs[0]),
					double.Parse(strs[1]),
					double.Parse(strs[2]),
					double.Parse(strs[3]));
		}

		public Point IntersectWith(Line other)
		{
			var p1 = this.End - this.Begin;
			var p2 = other.End - other.Begin;
			var p3 = other.Begin - this.Begin;

			var denominator = p2.X * p1.Y - p1.X * p2.Y;
			if(-1e-4 < denominator && denominator < 1e-4)
			{
				return null;
			}
			var k2 = (p1.X * p3.Y - p3.X * p1.Y) / denominator;

			if(k2 < 0 || k2 > 1)
			{
				return null;
			}

			return other.Begin + k2 * p2;
		}
	}

	class Program
	{
		static void Main()
		{
			var stick1 = Line.FromString(Console.ReadLine());
			var stick2 = Line.FromString(Console.ReadLine());
			var stick3 = Line.FromString(Console.ReadLine());

			var point1 = stick1.IntersectWith(stick2);
			var point2 = stick2.IntersectWith(stick3);
			var point3 = stick3.IntersectWith(stick1);

			if(point1 == null || point2 == null || point3 == null)
			{
				Console.WriteLine("No triangle.");
				return;
			}

			// Stupid fix for intersection
			point1 = stick2.IntersectWith(stick1);
			point2 = stick3.IntersectWith(stick2);
			point3 = stick1.IntersectWith(stick3);

			if(point1 == null || point2 == null || point3 == null)
			{
				Console.WriteLine("No triangle.");
				return;
			}

			double area = Point.Area(point1, point2, point3);
			area = Math.Abs(area) / 2;

			if(area < 1e-4)
			{
				Console.WriteLine("No triangle.");
				return;
			}

			Console.WriteLine("{0:F3}", area);
		}
	}
}
