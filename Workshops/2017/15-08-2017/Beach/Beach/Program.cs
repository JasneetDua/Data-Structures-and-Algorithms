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

            var bestTime = GetTime(sx, sy, sx, v1) + GetTime(ex, ey, sx, v2);
            var currTime = GetTime(sx, sy, ex, v1) + GetTime(ex, ey, ex, v2);

            if (bestTime > currTime)
            {
                bestTime = currTime;
            }

            currTime = GetTime(sx, sy, (sx + sy) / 2, v1) + GetTime(ex, ey, (sx + sy) / 2, v2);

            if (bestTime > currTime)
            {
                bestTime = currTime;
            }

            {
                var dx = sx - ex;
                var r = sy / (-ey);
                double v = dx / (1 + r);
                double beach = ex + v;
                currTime = GetTime(sx, sy, beach, v1) + GetTime(ex, ey, beach, v2);
                if (bestTime > currTime)
                {
                    bestTime = currTime;
                }
            }

            Console.WriteLine("{0:F2}", bestTime);
        }

        static double GetTime(double sx, double sy, double beach, double v)
        {
            var dx = sx - beach;
            var dist = Math.Sqrt(dx * dx + sy * sy);
            return dist / v;
        }
    }
}
