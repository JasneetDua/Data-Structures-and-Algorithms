using System;

namespace WoodenBoard
{
	class ReversedString
	{
		private string str;

		public ReversedString(string str)
		{
			this.str = str;
		}

		public char this[int index]
		{
			get
			{
				return this.str[this.str.Length - 1 - index];
			}
		}
	}
	class Program
	{
		static void Main()
		{
			var str = Console.ReadLine();
			var reversedStr = new ReversedString(str);

			var failLink = new int[str.Length + 1];
			failLink[0] = -1;
			failLink[1] = 0;
			for(int i = 1; i < str.Length; ++i)
			{
				int j = failLink[i];
				while(j >= 0 && reversedStr[i] != reversedStr[j])
				{
					j = failLink[j];
				}
				failLink[i + 1] = j;
			}

			int matched = 0;
			for(int i = 0; i < str.Length; ++i)
			{
				while(matched >= 0 && str[i] != reversedStr[matched])
				{
					matched = failLink[matched];
				}
				matched += 1;
			}

			Console.WriteLine(str.Length - matched);
		}
	}
}
