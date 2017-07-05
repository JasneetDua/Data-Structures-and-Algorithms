using System;
using System.Linq;

namespace Pipes
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			var pipeCount = uint.Parse(Console.ReadLine());
			var peopleCount = uint.Parse(Console.ReadLine());

			var pipes = new uint[pipeCount];
			for (uint i = 0; i < pipeCount; i++)
			{
				pipes[i] = uint.Parse(Console.ReadLine());
			}

			Func<uint, bool> checkFunc = size => CheckSize(pipes, peopleCount, size);

			var prevRight = 1U;
			var right = 8U;
			while (checkFunc(right))
			{
				prevRight = right;
				right *= 2;
			}

			var result = BinarySearch(checkFunc, prevRight, right);

			Console.WriteLine(result);
		}

		public static bool CheckSize(uint[] pipes, uint peopleCount, uint size)
		{
			ulong pipeCounter = 0;
			foreach (var pipe in pipes)
			{
				pipeCounter += pipe / size;
			}
			return pipeCounter >= peopleCount;
		}

		public static uint BinarySearch(Func<uint, bool> f,
									  uint left, uint right)
		{
			while (left < right)
			{
				uint middle = (left + right) / 2;

				if (f(middle))
				{
					left = middle + 1;
				}
				else
				{
					right = middle;
				}
			}

			return left - 1;
		}
	}
}
