using System;
using System.Linq;

class Link
{
	public int Value { get; private set; }

	public Link Left { get; private set; }
	public Link Right { get; private set; }

	public Link(Link end, int x)
	{
		this.Value = x;

		this.Left = end;
		this.Right = null;

		if(end != null)
		{
			end.Right = this;
		}
	}

	public static void Detach(Link x)
	{
		if(x.Left != null)
		{
			x.Left.Right = null;
		}
		if(x.Right != null)
		{
			x.Right.Left = null;
		}

		x.Left = null;
		x.Right = null;
	}

	public static void Attach(Link l, Link r)
	{
		if(l == r)
		{
			return;
		}

		l.Right = r;
		r.Left = l;
	}
}

class Program
{
	static void Main()
	{
		int n = int.Parse(Console.ReadLine());
		var swaps = Console.ReadLine()
			.Split(' ')
			.Select(int.Parse)
			.ToArray();

		var links = new Link[n + 1];
		for(int i = 1; i <= n; ++i)
		{
			links[i] = new Link(links[i - 1], i);
		}

		var leftEnd = links[1];
		var rightEnd = links[n];

		foreach(int x in swaps)
		{
			var middle = links[x];
			var newRight = middle.Left;
			var newLeft = middle.Right;

			Link.Detach(middle);
			Link.Attach(rightEnd, middle);
			Link.Attach(middle, leftEnd);

			leftEnd = newLeft ?? middle;
			rightEnd = newRight ?? middle;
		}

		var numbers = new int[n];
		for(int i = 0; i < n; ++i)
		{
			numbers[i] = leftEnd.Value;
			leftEnd = leftEnd.Right;
		}

		Console.WriteLine(string.Join(" ", numbers));
	}
}
