using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SwappingLinkedLists
{
	class ListNode : IEnumerable<int>
	{
		private int value;
		public ListNode Left { get; private set; }
		public ListNode Right { get; private set; }

		public ListNode(int v)
		{
			value = v;
			Left = null;
			Right = null;
		}

		public void Link(ListNode r)
		{
			Right = r;
			r.Left = this;
		}

		public void Detach()
		{
			if (this.Left != null)
			{
				this.Left.Right = null;
				this.Left = null;
			}
			if (this.Right != null)
			{
				this.Right.Left = null;
				this.Right = null;
			}
		}

		public IEnumerator<int> GetEnumerator()
		{
			//yield return value;
			//foreach (var next in right)
			//{
			//	yield return next;
			//}

			var node = this;
			while (node != null)
			{
				yield return node.value;
				node = node.Right;
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}

	class MainClass
	{
		public static void Main()
		{
			var n = int.Parse(Console.ReadLine());
			var nodes = Enumerable.Range(0, n + 1)
					  .Select(x => new ListNode(x))
					  .ToArray();

			for (int i = 1; i < n; i++)
			{
				nodes[i].Link(nodes[i + 1]);
			}

			var first = nodes[1];
			var last = nodes[n];

			Console.ReadLine()
				   .Split(' ')
				   .Select(int.Parse)
				   .ToList()
				   .ForEach(num =>
			{
				var newLast = nodes[num].Left;
				var newFirst = nodes[num].Right;

				nodes[num].Detach();

				if (last != nodes[num])
				{
					last.Link(nodes[num]);
				}
				else
				{
					newFirst = nodes[num];
				}

				if (first != nodes[num])
				{
					nodes[num].Link(first);
				}
				else
				{
					newLast = nodes[num];
				}

				first = newFirst;
				last = newLast;
			});

			//Console.WriteLine(first.Value);
			//Console.WriteLine(last.Value);
			//Console.WriteLine(last.Right);
			Console.WriteLine(string.Join(" ", first));
		}
	}
}
