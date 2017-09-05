using System;

namespace ColoredBeads
{
	enum ColorIndex
	{
		None = 0,
		Blue = 1,
		Green = 2,
		Red = 3,
	}

	class Program
	{
		static void Main()
		{
			var strs = Console.ReadLine().Split(' ');
			var redCount = int.Parse(strs[0]);
			var greenCount = int.Parse(strs[1]);
			var blueCount = int.Parse(strs[2]);

			var index = ulong.Parse(Console.ReadLine());

			// B < G < R
			var dp = new ulong[blueCount + 1, greenCount + 1, redCount + 1, 4];
			for(int i = 0; i < 4; ++i)
			{
				dp[0, 0, 0, i] = 1;
			}

			for(int bi = 0; bi <= blueCount; ++bi)
			{
				for(int gi = 0; gi <= greenCount; ++gi)
				{
					for(int ri = 0; ri <= redCount; ++ri)
					{
						if(bi + gi + ri == 0)
						{
							continue;
						}

						var getBlue = bi > 0 ? dp[bi - 1, gi, ri, (int)ColorIndex.Blue] : 0;
						var getGreen = gi > 0 ? dp[bi, gi - 1, ri, (int)ColorIndex.Green] : 0;
						var getRed = ri > 0 ? dp[bi, gi, ri - 1, (int)ColorIndex.Red] : 0;

						dp[bi, gi, ri, (int)ColorIndex.None] = getBlue + getGreen + getRed;
						dp[bi, gi, ri, (int)ColorIndex.Blue] = getGreen + getRed;
						dp[bi, gi, ri, (int)ColorIndex.Green] = getBlue + getRed;
						dp[bi, gi, ri, (int)ColorIndex.Red] = getBlue + getGreen;
					}
				}
			}

			//Console.WriteLine(dp[blueCount, greenCount, redCount, (int)ColorIndex.None]);

			var result = new char[blueCount + greenCount + redCount];
			var last = ColorIndex.None;

			for(int i = 0; i < result.Length; ++i)
			{
				if(last != ColorIndex.Blue && blueCount > 0)
				{
					var count = dp[blueCount - 1, greenCount, redCount, (int)ColorIndex.Blue];
					if(index < count)
					{
						result[i] = 'B';
						--blueCount;
						last = ColorIndex.Blue;
						continue;
					}
					index -= count;
				}

				if(last != ColorIndex.Green && greenCount > 0)
				{
					var count = dp[blueCount, greenCount - 1, redCount, (int)ColorIndex.Green];
					if(index < count)
					{
						result[i] = 'G';
						--greenCount;
						last = ColorIndex.Green;
						continue;
					}
					index -= count;
				}

				if(last != ColorIndex.Red && redCount > 0)
				{
					var count = dp[blueCount, greenCount, redCount - 1, (int)ColorIndex.Red];
					if(index < count)
					{
						result[i] = 'R';
						--redCount;
						last = ColorIndex.Red;
						continue;
					}
					index -= count;
				}

				throw new ArgumentException("index is too large");
			}

			Console.WriteLine(result);
		}
	}
}
