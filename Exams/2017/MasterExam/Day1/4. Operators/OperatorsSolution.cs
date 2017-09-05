using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Operators
{
	class OperatorsSolution
	{
		static void FakeInput()
		{
			var input = @"1 8 6 3 8 7 8 1 2 7
20";

			Console.SetIn(new StringReader(input));
		}

		static string BuildExpression(char[] path, int len)
		{
			var builder = new StringBuilder();
			for (int i = 0; i < len; i++)
			{
				builder.Append(path[i]);
			}
			return builder.ToString();
		}

		static void Dfs(List<string> paths, char[] path, int len, int left, int current, int[] digits, int pos, int target)
		{
			if (pos == digits.Length)
			{
				if (left + current == target)
				{
					paths.Add(BuildExpression(path, len));
				}
				return;
			}

			var n = 0;
			var j = len + 1;

			for (var i = pos; i < digits.Length; i++)
			{
				n = n * 10 + digits[i];
				path[j++] = (char)(digits[i] + '0');
				path[len] = '+';
				Dfs(paths, path, j, left + current, n, digits, i + 1, target);
				path[len] = '-';
				Dfs(paths, path, j, left + current, -n, digits, i + 1, target);
				path[len] = '*';
				Dfs(paths, path, j, left, current * n, digits, i + 1, target);
				if (digits[pos] == 0)
				{
					break;
				}
			}
		}

		static List<string> CalculateValidOperators(int[] digits, int target)
		{
			var paths = new List<string>();

			var path = new char[digits.Length * 2 - 1];

			var current = 0;

			for (int i = 0; i < digits.Length; i++)
			{
				current = 10 * current + digits[i];

				path[i] = (char)(digits[i] + '0');
				Dfs(paths, path, i + 1, 0, current, digits, i + 1, target);
				if (current == 0)
				{
					break;
				}
			}

			return paths;
		}

		public static void Main()
		{
			//FakeInput();
			var digits = Console.ReadLine()
								.Select(ch => ch - '0')
								.ToArray();

			var sum = int.Parse(Console.ReadLine());

			var result = CalculateValidOperators(digits, sum);

			Console.WriteLine(result.Count);
			result.ForEach(Console.WriteLine);
		}

	}
}
