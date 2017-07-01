using System;
using System.Linq;
using System.Collections.Generic;

namespace Jedis
{
	class Program
	{
		static void Main()
		{
			var n = int.Parse(Console.ReadLine());

			var mList = new List<string>();
			var kList = new List<string>();
			var pList = new List<string>();

			Console.ReadLine()
				.Split(' ')
				.ToList()
				.ForEach(x =>
				{
					if(x[0] == 'M')
					{
						mList.Add(x);
					}
					else if(x[0] == 'K')
					{
						kList.Add(x);
					}
					else
					{
						pList.Add(x);
					}
				});

			mList.AddRange(kList);
			mList.AddRange(pList);

			Console.WriteLine(string.Join(" ", mList));
		}
	}
}
