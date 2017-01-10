using System;
using System.Numerics;
using System.Linq;

namespace Rings
{
	class Program
	{
		static void Main()
		{
			int n = int.Parse(Console.ReadLine());

			var children = new int[n + 1];
			for(int i = 0; i < n; i++)
			{
				int parent = int.Parse(Console.ReadLine());
				children[parent]++;
			}

			var facts = new BigInteger[children.Max() + 1];
			facts[0] = 1;
			for(int i = 1; i < facts.Length; i++)
			{
				facts[i] = facts[i - 1] * i;
			}

			BigInteger total = 1;
			for(int i = 1; i < children.Length; i++)
			{
				total *= facts[children[i]];
			}

			Console.WriteLine(total);
		}
	}
}
