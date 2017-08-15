using System;

namespace Beach
{
    class Program
    {
        static void Main()
        {
            var strs = Console.ReadLine().Split(' ');
            var sx = double.Parse(strs[0]);
            var sy = double.Parse(strs[1]);
            var v1 = double.Parse(strs[2]);

            strs = Console.ReadLine().Split(' ');
            var ex = double.Parse(strs[0]);
            var ey = double.Parse(strs[1]);
            var v2 = double.Parse(strs[2]);

            var left = Math.Min(sx, ex);
            var right = Math.Max(sx, ex);

            Func<double, double> time = x => GetAllTime(sx, sy, ex, ey, x, v1, v2);

            while (right - left > 1e-4)
            {
                var middle = (left + right) / 2;
                var leftMiddle = (left + middle) / 2;
                var rightMiddle = (middle + right) / 2;

                var middleTime = time(middle);
                var leftMiddleTime = time(leftMiddle);
                var rightMiddleTime = time(rightMiddle);

                if (leftMiddleTime < middleTime)
                {
                    right = middle;
                }
                else if (rightMiddleTime < middleTime)
                {
                    left = middle;
                }
                else
                {
                    left = leftMiddle;
                    right = rightMiddle;
                }
            }

            Console.WriteLine("{0:F2}", time(left));
        }

        static double GetAllTime(double sx, double sy,
            double ex, double ey,
            double beach,
            double v1, double v2)
        {
            return GetTime(sx, sy, beach, v1) + GetTime(ex, ey, beach, v2);
        }

        static double GetTime(double sx, double sy, double beach, double v)
        {
            var dx = sx - beach;
            var dist = Math.Sqrt(dx * dx + sy * sy);
            return dist / v;
        }
    }
}
