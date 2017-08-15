using System;

namespace CardGame
{
    struct Result
    {
        public int Player1;
        public int Player2;
    }

    class Program
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var line = Console.ReadLine();

            var cards = new int[n];
            bool isNegative = false;
            for (int i = 0, j = 0; j < line.Length; ++j)
            {
                if (line[j] == ' ')
                {
                    if (isNegative)
                    {
                        cards[i] = -cards[i];
                        isNegative = false;
                    }
                    ++i;
                    continue;
                }

                if (line[j] == '-')
                {
                    isNegative = true;
                    continue;
                }

                cards[i] = cards[i] * 10 + (line[j] - '0');
            }
            if (isNegative)
            {
                cards[n - 1] = -cards[n - 1];
                isNegative = false;
            }

            var bestResultForInterval = new Result[n, n + 1];
            for (int i = 0; i < n; ++i)
            {
                bestResultForInterval[i, 1] = new Result { Player1 = cards[i], Player2 = 0 };
            }

            for (int length = 2; length <= n; ++length)
            {
                for (int i = 0; i <= n - length; ++i)
                {
                    int j = i + length - 1;

                    var bestResult1 = bestResultForInterval[i + 1, length - 1].Player2 + cards[i];
                    var bestResult2 = bestResultForInterval[i, length - 1].Player2 + cards[j];

                    bestResultForInterval[i, length] = bestResult1 > bestResult2
                        ? new Result { Player1 = bestResult1, Player2 = bestResultForInterval[i + 1, length - 1].Player1 }
                        : new Result { Player1 = bestResult2, Player2 = bestResultForInterval[i, length - 1].Player1 };

                    //Console.WriteLine($"{i} {length} - {bestResultForInterval[i, length].Item1} {bestResultForInterval[i, length].Item2}");
                }
            }

            Console.WriteLine("{0} {1}",
                bestResultForInterval[0, n].Player1,
                bestResultForInterval[0, n].Player2);
        }
    }
}
