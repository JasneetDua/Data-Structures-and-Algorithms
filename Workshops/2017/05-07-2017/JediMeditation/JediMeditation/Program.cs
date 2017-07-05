using System;
using System.Collections.Generic;
using System.Linq;

namespace JediMeditation
{
	class MainClass
	{
		public static int CompareJedi(string x, string y)
		{
			if (x[0] == 'M')
			{
				return -1;
			}
			if (y[0] == 'M')
			{
				return 1;
			}
			if (x[0] == 'K')
			{
				return -1;
			}
			if (y[0] == 'K')
			{
				return 1;
			}
			return -1;
		}

		public static void Main(string[] args)
		{
			var n = int.Parse(Console.ReadLine());
			var jedis = Console.ReadLine()
							   .Split(' ')
							   //.GroupBy(x => x[0])
			                   .OrderBy(x => x[0] == 'M' ? 0 : (x[0] == 'K' ? 1 : 2))
							   //.SelectMany(x => x)
							   .ToList();


			Console.WriteLine(string.Join(" ", jedis));
			return;

			//jedis.Sort(CompareJedi);
			//Console.WriteLine(string.Join(" ", jedis));

			var mList = new List<string>();
			var kList = new List<string>();
			var pList = new List<string>();

			foreach (var jedi in jedis)
			{
				if (jedi[0] == 'M')
				{
					mList.Add(jedi);
				}
				else if (jedi[0] == 'K')
				{
					kList.Add(jedi);
				}
				else
				{
					pList.Add(jedi);
				}
			}

			mList.AddRange(kList);
			mList.AddRange(pList);

			Console.WriteLine(string.Join(" ", mList));
		}
	}
}
