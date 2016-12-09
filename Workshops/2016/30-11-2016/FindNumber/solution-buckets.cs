using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
	static void Main()
	{
		var k = int.Parse(Console.ReadLine().Split(' ')[1]);
		var strings = Console.ReadLine()
			.Split(' ')
			.ToList();

		for(int index = 0; index < 10 && strings.Count > 1; ++index)
		{
			var buckets = new List<string>[128];

			foreach(var str in strings)
			{
				int bucket = index < str.Length ? str[index] : 0;
				if(buckets[bucket] == null)
				{
					buckets[bucket] = new List<string>();
				}
				buckets[bucket].Add(str);
			}

			for(int i = 0; i < buckets.Length; ++i)
			{
				if(buckets[i] == null)
				{
					continue;
				}

				if(k < buckets[i].Count)
				{
					strings = buckets[i];
					break;
				}
				
				k -= buckets[i].Count;
			}
		}

		Console.WriteLine(strings[0]);
	}
}
