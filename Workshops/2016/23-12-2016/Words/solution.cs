using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Words
{
    class Program
    {
        static void Main()
        {
            string word = Console.ReadLine();
            string text = Console.ReadLine();

            var prefixMatches = new int[word.Length + 1];
            Kmp(word, text, prefixMatches);

            word = new string(word.Reverse().ToArray());
            text = new string(text.Reverse().ToArray());

            var suffixMatches = new int[word.Length + 1];
            Kmp(word, text, suffixMatches);

            int total = prefixMatches[word.Length];
            for(int i = 1; i < word.Length; ++i)
            {
                total += prefixMatches[i] * suffixMatches[word.Length - i];
            }

            Console.WriteLine(total);
        }

        static void Kmp(string pattern, string text, int[] prefixMatches)
        {
            var faillink = new int[pattern.Length + 1];
            faillink[0] = -1;
            faillink[1] = 0;

            for (int i = 1; i < pattern.Length; i++)
            {
                int j = faillink[i];
                while(j >= 0 && pattern[i] != pattern[j])
                {
                    j = faillink[j];
                }

                ++j;

                faillink[i + 1] = j;
            }

            int matched = 0;
            for (int i = 0; i < text.Length; ++i)
            {
                while(matched >= 0 && text[i] != pattern[matched])
                {
                    matched = faillink[matched];
                }

                ++matched;

                for(int j = matched; j > 0; j = faillink[j])
                {
                    prefixMatches[j]++;
                }

                if(matched == pattern.Length)
                {
                    matched = faillink[matched];
                }
            }
        }
    }
}
